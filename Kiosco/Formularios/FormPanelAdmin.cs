namespace Kiosco
{
    /// <summary>
    /// Panel principal de Administración: acceso al ABM de empleados y productos
    /// (desde Productos se llega a precios y promociones) y a los reportes.
    /// </summary>
    public partial class FormPanelAdmin : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el panel del administrador.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
        public FormPanelAdmin(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
            Estilo.CentrarContenido(this);
        }

        /// <summary>Abre un formulario hijo ocultando este panel mientras tanto.</summary>
        private void AbrirFormulario(Form formulario)
        {
            Hide();
            using (formulario)
            {
                formulario.ShowDialog();
            }
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
