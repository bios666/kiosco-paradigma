namespace Kiosco
{
    /// <summary>
    /// Panel principal del empleado: abrir y cerrar la caja, realizar ventas y ver sus ventas.
    /// </summary>
    public partial class FormPanelEmpleado : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;
        /// <summary>Empleado que inició sesión.</summary>
        private readonly Empleado empleado;

        /// <summary>
        /// Crea el panel del empleado.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
        /// <param name="empleado">Empleado que inició sesión.</param>
        public FormPanelEmpleado(Sistema sistema, Empleado empleado)
        {
            this.sistema = sistema;
            this.empleado = empleado;
            InitializeComponent();
            Estilo.Aplicar(this);
            Estilo.CentrarContenido(this);
            lblTitulo.Text = $"Hola, {empleado.Nombres}";
            ActualizarEstado();
        }

        /// <summary>Actualiza el estado de la caja y el texto del botón de caja.</summary>
        private void ActualizarEstado()
        {
            Caja caja = sistema.Caja;
            if (caja.Abierta)
            {
                lblEstado.Text = $"Caja abierta desde {caja.FechaApertura:dd/MM HH:mm}\n" +
                                 $"Mis ventas del día: {empleado.VentasDelDia().Count()}";
                btnCaja.Text = "Cerrar caja";
            }
            else
            {
                lblEstado.Text = "La caja está cerrada.\nÁbrala para comenzar a vender.";
                btnCaja.Text = "Abrir caja";
            }
        }

        /// <summary>Abre la pantalla de venta.</summary>
        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            if (!sistema.Caja.Abierta)
            {
                MessageBox.Show("La caja está cerrada. Debe abrirla antes de vender.", "Caja cerrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Hide();
            using (FormVenta venta = new FormVenta(sistema, empleado))
            {
                venta.ShowDialog();
            }
            ActualizarEstado();
            Show();
        }

        /// <summary>Abre el historial de ventas del empleado.</summary>
        private void btnMisVentas_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormMisVentas misVentas = new FormMisVentas(sistema, empleado))
            {
                misVentas.ShowDialog();
            }
            Show();
        }

        /// <summary>Abre o cierra la caja según su estado actual.</summary>
        private void btnCaja_Click(object sender, EventArgs e)
        {
            if (sistema.Caja.Abierta)
                CerrarCaja();
            else
                AbrirCaja();
            ActualizarEstado();
        }

        /// <summary>Pide el monto inicial y abre la caja.</summary>
        private void AbrirCaja()
        {
            using (FormMontoInicial dialogo = new FormMontoInicial())
            {
                if (dialogo.ShowDialog() != DialogResult.OK) return;

                sistema.Caja.Abrir(dialogo.Monto);
                sistema.Guardar();
                MessageBox.Show($"Caja abierta con {dialogo.Monto:$0.00}.", "Caja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Cierra la caja, previa confirmación, y muestra el resumen del turno.</summary>
        private void CerrarCaja()
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Cerrar la caja ahora? Se guardará el resumen del turno.", "Cierre de caja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            CierreCaja cierre = sistema.Caja.Cerrar();
            sistema.Guardar();
            MessageBox.Show(cierre.ToString(), "Caja cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Cierra la sesión y vuelve a la pantalla inicial.</summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
