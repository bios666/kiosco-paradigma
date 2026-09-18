namespace Kiosco
{
    /// <summary>
    /// Pantalla inicial: permite elegir si se ingresa como Administrador o como Empleado.
    /// </summary>
    public partial class FormInicio : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;

        /// <summary>
        /// Crea la pantalla inicial.
        /// </summary>
        /// <param name="sistema">Sistema cargado desde disco.</param>
        public FormInicio(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
            picLogo.Image = Estilo.CargarLogo();
        }

        /// <summary>Abre el login de administrador y, si es correcto, su panel.</summary>
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            // Patrón de navegación: se oculta esta pantalla, se abren las siguientes con ShowDialog()
            // (bloquean hasta cerrarse) y al volver se la muestra de nuevo.
            Hide();
            using (FormLoginAdmin login = new FormLoginAdmin(sistema))
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    using (FormPanelAdmin panel = new FormPanelAdmin(sistema))
                    {
                        panel.ShowDialog();
                    }
                }
            }
            Show();
        }

        /// <summary>Abre el login de empleado y, si es correcto, su panel.</summary>
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            if (sistema.Empleados.Count == 0)
            {
                MessageBox.Show(
                    "Todavía no hay empleados registrados.\nIngrese como Administrador para darlos de alta.",
                    "Sin empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Hide();
            using (FormLoginEmpleado login = new FormLoginEmpleado(sistema))
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    using (FormPanelEmpleado panel = new FormPanelEmpleado(sistema, login.EmpleadoIngresado))
                    {
                        panel.ShowDialog();
                    }
                }
            }
            Show();
        }

        /// <summary>Cierra la aplicación.</summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
