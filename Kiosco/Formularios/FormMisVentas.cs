namespace Kiosco
{
    /// <summary>
    /// Historial de ventas del empleado que inició sesión, del día de hoy o del turno de caja actual.
    /// </summary>
    public partial class FormMisVentas : Form
    {
        private readonly Sistema sistema;
        private readonly Empleado empleado;

        /// <summary>
        /// Crea el formulario de historial del empleado.
        /// </summary>
        public FormMisVentas(Sistema sistema, Empleado empleado)
        {
            this.sistema = sistema;
            this.empleado = empleado;
            InitializeComponent();
            Estilo.Aplicar(this);
            ConfigurarColumnas();
        }

        /// <summary>Define las columnas de la grilla.</summary>
        private void ConfigurarColumnas()
        {
            dgvVentas.Columns.Add("Numero", "Nº");
            dgvVentas.Columns.Add("Hora", "Fecha y hora");
            dgvVentas.Columns.Add("Items", "Ítems");
            dgvVentas.Columns.Add("Total", "Total");
            dgvVentas.Columns.Add("Medio", "Medio de pago");
            dgvVentas.Columns["Numero"].FillWeight = 50;
            dgvVentas.Columns["Items"].FillWeight = 50;
        }

        /// <summary>Carga las ventas al abrir el formulario.</summary>
        private void FormMisVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        /// <summary>Carga las ventas según el filtro elegido (día o turno).</summary>
        private void CargarVentas()
        {
            dgvVentas.Rows.Clear();
            List<Venta> ventas = (rbDia.Checked ? empleado.VentasDelDia() : empleado.VentasDelTurno(sistema.Caja))
                .OrderByDescending(v => v.FechaHora).ToList();

            foreach (Venta v in ventas)
            {
                int fila = dgvVentas.Rows.Add(v.Numero.ToString("000000"), v.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                    v.Items.Sum(i => i.Cantidad), v.Total.ToString("$0.00"), v.MedioPago);
                dgvVentas.Rows[fila].Tag = v;
            }
            dgvVentas.ClearSelection();

            lblTotal.Text = $"{ventas.Count} venta(s)  |  Total: {ventas.Sum(v => v.Total):$0.00}";
            if (rbTurno.Checked && !sistema.Caja.Abierta)
                lblTotal.Text = "La caja está cerrada: no hay un turno en curso.";
        }

        /// <summary>Al cambiar el filtro se recarga la lista.</summary>
        private void rbFiltro_CheckedChanged(object sender, EventArgs e)
        {
            CargarVentas();
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

        /// <summary>Vuelve al panel del empleado.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
