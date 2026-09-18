namespace Kiosco
{
    /// <summary>
    /// Panel principal del administrador: acceso al ABM de empleados y productos,
    /// promociones y reportes.
    /// </summary>
    public partial class FormPanelAdmin : Form
    {
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el panel del administrador.
        /// </summary>
        public FormPanelAdmin(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
            ActualizarResumen();
        }

        /// <summary>Muestra un resumen rápido del estado del sistema.</summary>
        private void ActualizarResumen()
        {
            lblResumen.Text = $"Empleados: {sistema.Empleados.Count}   |   Productos: {sistema.Productos.Count}\n" +
                              $"Caja: {(sistema.Caja.Abierta ? "abierta" : "cerrada")}";
        }

        /// <summary>Abre un formulario hijo ocultando este panel mientras tanto.</summary>
        private void AbrirFormulario(Form formulario)
        {
            Hide();
            using (formulario)
            {
                formulario.ShowDialog();
            }
            ActualizarResumen();
            Show();
        }

        /// <summary>Abre la gestión de empleados.</summary>
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormEmpleados(sistema));
        }

        /// <summary>Abre la gestión de productos.</summary>
        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormProductos(sistema));
        }

        /// <summary>Abre la configuración de precios y promociones.</summary>
        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormPromociones(sistema));
        }

        /// <summary>Abre los reportes y el cierre de caja.</summary>
        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes(sistema));
        }

        /// <summary>Cierra la sesión y vuelve a la pantalla inicial.</summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
