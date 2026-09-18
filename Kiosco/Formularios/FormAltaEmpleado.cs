using System.Globalization;

namespace Kiosco
{
    /// <summary>
    /// Alta de un empleado nuevo con validación de todos los campos.
    /// </summary>
    public partial class FormAltaEmpleado : Form
    {
        private const int EdadMinima = 16;
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el formulario de alta de empleado.
        /// </summary>
        public FormAltaEmpleado(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        /// <summary>Carga los combos de día, mes y año de nacimiento.</summary>
        private void FormAltaEmpleado_Load(object sender, EventArgs e)
        {
            for (int dia = 1; dia <= 31; dia++)
                cmbDia.Items.Add(dia);

            string[] meses = CultureInfo.GetCultureInfo("es-AR").DateTimeFormat.MonthNames;
            for (int mes = 0; mes < 12; mes++)
                cmbMes.Items.Add(char.ToUpper(meses[mes][0]) + meses[mes].Substring(1));

            int anioActual = DateTime.Today.Year;
            for (int anio = anioActual - EdadMinima; anio >= anioActual - 80; anio--)
                cmbAnio.Items.Add(anio);
        }

        /// <summary>Valida los datos y da de alta al empleado.</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validador.ValidarControles(this, errorProvider)) return;

            // Fecha de nacimiento: la combinación de día, mes y año tiene que existir (ej. no vale 31/02).
            int dia = (int)cmbDia.SelectedItem;
            int mes = cmbMes.SelectedIndex + 1;
            int anio = (int)cmbAnio.SelectedItem;
            if (dia > DateTime.DaysInMonth(anio, mes))
            {
                errorProvider.SetError(cmbDia, "La fecha no existe.");
                MessageBox.Show("La fecha de nacimiento no es válida.", "Datos incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime fechaNacimiento = new DateTime(anio, mes, dia);

            if (txtDni.Text.Length < 7 || !int.TryParse(txtDni.Text, out int dni) || dni <= 0)
            {
                errorProvider.SetError(txtDni, "El DNI debe tener 7 u 8 dígitos.");
                return;
            }

            decimal.TryParse(txtSueldo.Text, out decimal sueldo);
            if (sueldo <= 0)
            {
                errorProvider.SetError(txtSueldo, "El sueldo debe ser mayor a cero.");
                return;
            }

            Empleado empleado = new Empleado(
                txtNombres.Text.Trim(), txtApellidos.Text.Trim(), dni, fechaNacimiento,
                txtContrasena.Text.Trim(), sueldo);

            if (!sistema.Administrador.AltaEmpleado(sistema, empleado))
            {
                errorProvider.SetError(txtDni, "Ya existe un empleado con ese DNI.");
                MessageBox.Show("Ya existe un empleado registrado con ese DNI.", "Empleado duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sistema.Guardar();
            MessageBox.Show($"Empleado {empleado.NombreCompleto} registrado correctamente.", "Alta exitosa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        /// <summary>Cierra el formulario sin guardar.</summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
