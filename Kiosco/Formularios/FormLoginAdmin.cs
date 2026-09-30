namespace Kiosco
{
    /// <summary>
    /// Login del administrador: pide la contraseña y la valida contra la del sistema.
    /// </summary>
    public partial class FormLoginAdmin : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el formulario de login del administrador.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
        public FormLoginAdmin(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this, pantallaCompleta: false);
        }

        /// <summary>Valida el campo y, si la contraseña es correcta, cierra con resultado OK.</summary>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!Validador.ValidarControles(this, errorProvider)) return;

            if (!sistema.Administrador.ValidarContrasena(txtContrasena.Text))
            {
                MessageBox.Show("Contraseña incorrecta.", "Error de ingreso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtContrasena.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>Vuelve a la pantalla inicial.</summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
