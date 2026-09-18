namespace Kiosco
{
    /// <summary>
    /// Reportes del administrador: historial de ventas, ventas y sueldos por empleado, y cierre de caja.
    /// </summary>
    public partial class FormReportes : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el formulario de reportes.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
        public FormReportes(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
            ConfigurarColumnas();
        }

        /// <summary>Define las columnas de las tres grillas.</summary>
        private void ConfigurarColumnas()
        {
            dgvVentas.Columns.Add("Numero", "Nº");
            dgvVentas.Columns.Add("Fecha", "Fecha y hora");
            dgvVentas.Columns.Add("Empleado", "Empleado");
            dgvVentas.Columns.Add("Items", "Ítems");
            dgvVentas.Columns.Add("Total", "Total");
            dgvVentas.Columns.Add("Medio", "Medio de pago");
            dgvVentas.Columns["Numero"].FillWeight = 50;
            dgvVentas.Columns["Items"].FillWeight = 50;

            dgvPorEmpleado.Columns.Add("Empleado", "Empleado");
            dgvPorEmpleado.Columns.Add("Dni", "DNI");
            dgvPorEmpleado.Columns.Add("Ventas", "Ventas");
            dgvPorEmpleado.Columns.Add("Total", "Total vendido");
            dgvPorEmpleado.Columns.Add("Dias", "Días trabajados");
            dgvPorEmpleado.Columns.Add("Sueldo", "Sueldo a pagar");
            dgvPorEmpleado.Columns["Empleado"].FillWeight = 160;

            dgvCierres.Columns.Add("Apertura", "Apertura");
            dgvCierres.Columns.Add("Cierre", "Cierre");
            dgvCierres.Columns.Add("Inicial", "Monto inicial");
            dgvCierres.Columns.Add("Efectivo", "Efectivo");
            dgvCierres.Columns.Add("Tarjeta", "Tarjeta");
            dgvCierres.Columns.Add("Total", "Total vendido");
            dgvCierres.Columns.Add("Cantidad", "Ventas");
            dgvCierres.Columns["Cantidad"].FillWeight = 50;
        }

        /// <summary>Por defecto se muestra el mes en curso.</summary>
        private void FormReportes_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;
            ActualizarTodo();
        }

        /// <summary>Recalcula todos los reportes.</summary>
        private void ActualizarTodo()
        {
            CargarHistorial();
            CargarPorEmpleado();
            CargarCaja();
        }

        /// <summary>Historial de ventas del rango de fechas.</summary>
        private void CargarHistorial()
        {
            dgvVentas.Rows.Clear();
            List<Venta> ventas = sistema.Caja.VentasEntre(dtpDesde.Value, dtpHasta.Value)
                .OrderByDescending(v => v.FechaHora).ToList();

            foreach (Venta v in ventas)
            {
                int fila = dgvVentas.Rows.Add(
                    v.Numero.ToString("000000"), v.FechaHora.ToString("dd/MM/yyyy HH:mm"), v.EmpleadoNombre,
                    v.Items.Sum(i => i.Cantidad), v.Total.ToString("$0.00"), v.MedioPago);
                dgvVentas.Rows[fila].Tag = v;
            }
            dgvVentas.ClearSelection();

            decimal efectivo = ventas.Where(v => v.MedioPago == MedioPago.Efectivo).Sum(v => v.Total);
            decimal tarjeta = ventas.Where(v => v.MedioPago == MedioPago.Tarjeta).Sum(v => v.Total);
            lblTotalVentas.Text = $"{ventas.Count} venta(s)  |  Total: {(efectivo + tarjeta):$0.00}  " +
                                  $"(efectivo {efectivo:$0.00} - tarjeta {tarjeta:$0.00})";
        }

        /// <summary>Ventas, días trabajados y sueldo a pagar por empleado en el rango de fechas.</summary>
        private void CargarPorEmpleado()
        {
            dgvPorEmpleado.Rows.Clear();
            DateTime desde = dtpDesde.Value;
            DateTime hasta = dtpHasta.Value;
            List<Venta> ventas = sistema.Caja.VentasEntre(desde, hasta).ToList();
            decimal totalSueldos = 0;

            // Empleados actuales (con o sin ventas).
            foreach (Empleado emp in sistema.Empleados.OrderBy(x => x.Apellidos).ThenBy(x => x.Nombres))
            {
                List<Venta> suyas = ventas.Where(v => v.EmpleadoDni == emp.Dni).ToList();
                decimal sueldo = sistema.Caja.CalcularSueldo(emp, desde, hasta);
                totalSueldos += sueldo;
                dgvPorEmpleado.Rows.Add(emp.NombreCompleto, emp.Dni, suyas.Count,
                    suyas.Sum(v => v.Total).ToString("$0.00"), emp.DiasTrabajados(desde, hasta), sueldo.ToString("$0.00"));
            }

            // Empleados dados de baja que tienen ventas en el período: ya no están en la lista de empleados,
            // pero sus ventas siguen en el historial, así que se agrupan por el DNI guardado en cada venta.
            // No muestran días ni sueldo porque se pierden sus asistencias al darlos de baja.
            foreach (var grupo in ventas.Where(v => sistema.BuscarEmpleado(v.EmpleadoDni) == null)
                                        .GroupBy(v => v.EmpleadoDni))
            {
                dgvPorEmpleado.Rows.Add(grupo.First().EmpleadoNombre + " (baja)", grupo.Key, grupo.Count(),
                    grupo.Sum(v => v.Total).ToString("$0.00"), "-", "-");
            }

            dgvPorEmpleado.ClearSelection();
            lblTotalSueldos.Text = $"Total de sueldos a pagar en el período: {totalSueldos:$0.00}";
        }

        /// <summary>Estado de la caja actual e historial de cierres.</summary>
        private void CargarCaja()
        {
            Caja caja = sistema.Caja;
            if (caja.Abierta)
            {
                lblEstadoCaja.Text =
                    $"Caja ABIERTA desde {caja.FechaApertura:dd/MM/yyyy HH:mm}\n" +
                    $"Monto inicial: {caja.MontoInicial:$0.00}\n" +
                    $"Ventas del turno: {caja.VentasDelTurno().Count()}  |  Total: {caja.TotalDelTurno():$0.00}\n" +
                    $"Efectivo: {caja.TotalDelTurno(MedioPago.Efectivo):$0.00}  |  Tarjeta: {caja.TotalDelTurno(MedioPago.Tarjeta):$0.00}\n" +
                    $"Efectivo esperado en caja: {(caja.MontoInicial + caja.TotalDelTurno(MedioPago.Efectivo)):$0.00}";
            }
            else
            {
                lblEstadoCaja.Text = "La caja está CERRADA.\nUn empleado debe abrirla para comenzar a vender.";
            }
            btnCierreCaja.Enabled = caja.Abierta;

            dgvCierres.Rows.Clear();
            foreach (CierreCaja c in caja.Cierres.Reverse())
            {
                dgvCierres.Rows.Add(
                    c.FechaApertura.ToString("dd/MM/yyyy HH:mm"), c.FechaCierre.ToString("dd/MM/yyyy HH:mm"),
                    c.MontoInicial.ToString("$0.00"), c.TotalEfectivo.ToString("$0.00"),
                    c.TotalTarjeta.ToString("$0.00"), c.TotalVendido.ToString("$0.00"), c.CantidadVentas);
            }
            dgvCierres.ClearSelection();
        }

        /// <summary>Aplica el rango de fechas a los reportes.</summary>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha \"Desde\" no puede ser posterior a la fecha \"Hasta\".", "Rango inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActualizarTodo();
        }

        /// <summary>Muestra el ticket de la venta seleccionada.</summary>
        private void btnVerTicket_Click(object sender, EventArgs e)
        {
            MostrarTicketSeleccionado();
        }

        /// <summary>Doble clic sobre una venta: muestra su ticket.</summary>
        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) MostrarTicketSeleccionado();
        }

        /// <summary>Muestra el texto del ticket de la venta seleccionada en la grilla (o avisa si no hay selección).</summary>
        private void MostrarTicketSeleccionado()
        {
            if (dgvVentas.CurrentRow == null || !dgvVentas.CurrentRow.Selected ||
                !(dgvVentas.CurrentRow.Tag is Venta venta))
            {
                MessageBox.Show("Seleccione una venta.", "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show(venta.ArmarTicket(), $"Ticket {venta.Numero:000000}", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>Cierra la caja abierta, previa confirmación, y muestra el resumen.</summary>
        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Cerrar la caja ahora? Se guardará el resumen del turno.", "Cierre de caja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            CierreCaja cierre = sistema.Caja.Cerrar();
            sistema.Guardar();
            MessageBox.Show(cierre.ToString(), "Caja cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarCaja();
        }

        /// <summary>Vuelve al panel del administrador.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
