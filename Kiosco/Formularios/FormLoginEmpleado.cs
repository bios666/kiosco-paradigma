namespace Kiosco
{
    /// <summary>
    /// Login del empleado: se elige el empleado de la lista y se ingresa su contraseña.
    /// Al ingresar correctamente se marca su asistencia del día.
    /// </summary>
    public partial class FormLoginEmpleado : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;

        /// <summary>Empleado que ingresó correctamente (disponible cuando el resultado es OK).</summary>
        public Empleado EmpleadoIngresado { get; private set; }

        /// <summary>
        /// Crea el formulario de login del empleado.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
        public FormLoginEmpleado(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this, pantallaCompleta: false);
        }

        /// <summary>Carga la lista de empleados registrados.</summary>
        private void FormLoginEmpleado_Load(object sender, EventArgs e)
        {
            foreach (Empleado empleado in sistema.Empleados.OrderBy(x => x.Apellidos).ThenBy(x => x.Nombres))
                cmbEmpleados.Items.Add(empleado);
        }

        /// <summary>Valida los campos, verifica la contraseña y marca la asistencia.</summary>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!Validador.ValidarControles(this, errorProvider)) return;

            Empleado empleado = (Empleado)cmbEmpleados.SelectedItem;
            if (!empleado.ValidarContrasena(txtContrasena.Text))
            {
                MessageBox.Show("Contraseña incorrecta.", "Error de ingreso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtContrasena.Focus();
                return;
            }

            if (empleado.MarcarAsistencia())
            {
                sistema.Guardar();
                MessageBox.Show($"Asistencia registrada: {DateTime.Now:dd/MM/yyyy HH:mm}",
                    "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            EmpleadoIngresado = empleado;
            DialogResult = DialogResult.OK;
        }

        /// <summary>Vuelve a la pantalla inicial.</summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
