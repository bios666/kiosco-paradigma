using System.Text;

namespace Kiosco
{
    /// <summary>
    /// Listado de empleados con ficha de detalle, alta, baja y marcado de asistencia por el administrador.
    /// </summary>
    public partial class FormEmpleados : Form
    {
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el formulario de gestión de empleados.
        /// </summary>
        public FormEmpleados(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
            ConfigurarColumnas();
        }

        /// <summary>Define las columnas de la grilla.</summary>
        private void ConfigurarColumnas()
        {
            dgvEmpleados.Columns.Add("Nombre", "Apellido y nombre");
            dgvEmpleados.Columns.Add("Dni", "DNI");
            dgvEmpleados.Columns.Add("Edad", "Edad");
            dgvEmpleados.Columns.Add("Sueldo", "Sueldo por día");
            dgvEmpleados.Columns.Add("Dias", "Días trabajados (mes)");
            dgvEmpleados.Columns["Nombre"].FillWeight = 200;
            dgvEmpleados.Columns["Edad"].FillWeight = 60;
        }

        /// <summary>Carga la grilla al abrir el formulario.</summary>
        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        /// <summary>Vuelve a cargar los empleados en la grilla.</summary>
        private void CargarGrilla()
        {
            DateTime primerDia = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dgvEmpleados.Rows.Clear();
            foreach (Empleado emp in sistema.Empleados.OrderBy(x => x.Apellidos).ThenBy(x => x.Nombres))
            {
                int fila = dgvEmpleados.Rows.Add(
                    emp.NombreCompleto, emp.Dni, emp.Edad,
                    emp.SueldoPorDia.ToString("$0.00"), emp.DiasTrabajados(primerDia, DateTime.Today));
                dgvEmpleados.Rows[fila].Tag = emp;
            }
            dgvEmpleados.ClearSelection();
            MostrarFicha();
        }

        /// <summary>Devuelve el empleado seleccionado en la grilla (o null).</summary>
        private Empleado EmpleadoSeleccionado()
        {
            if (dgvEmpleados.CurrentRow == null || !dgvEmpleados.CurrentRow.Selected) return null;
            return dgvEmpleados.CurrentRow.Tag as Empleado;
        }

        /// <summary>Actualiza la ficha con los datos del empleado seleccionado.</summary>
        private void MostrarFicha()
        {
            Empleado emp = EmpleadoSeleccionado();
            if (emp == null)
            {
                txtFicha.Text = "Seleccione un empleado de la lista.";
                return;
            }

            DateTime primerDia = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(emp.NombreCompleto);
            sb.AppendLine();
            sb.AppendLine($"DNI: {emp.Dni}");
            sb.AppendLine($"Nacimiento: {emp.FechaNacimiento:dd/MM/yyyy} ({emp.Edad} años)");
            sb.AppendLine($"Sueldo por día: ${emp.SueldoPorDia:0.00}");
            sb.AppendLine();
            sb.AppendLine($"Días trabajados este mes: {emp.DiasTrabajados(primerDia, DateTime.Today)}");
            sb.AppendLine($"Sueldo a pagar (mes actual): ${sistema.Caja.CalcularSueldo(emp, primerDia, DateTime.Today):0.00}");
            sb.AppendLine($"Vendido este mes: ${sistema.Caja.TotalVendidoPorEmpleado(emp.Dni, primerDia, DateTime.Today):0.00}");
            sb.AppendLine($"Asistencia de hoy: {(emp.TieneAsistenciaHoy() ? "marcada" : "sin marcar")}");
            sb.AppendLine();
            sb.AppendLine("Últimas asistencias:");
            foreach (Asistencia a in emp.Asistencias.Reverse().Take(8))
                sb.AppendLine("  " + a);
            txtFicha.Text = sb.ToString();
        }

        /// <summary>Al cambiar la selección se actualiza la ficha.</summary>
        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            MostrarFicha();
        }

        /// <summary>Abre el alta de un empleado nuevo.</summary>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (FormAltaEmpleado alta = new FormAltaEmpleado(sistema))
            {
                if (alta.ShowDialog() == DialogResult.OK) CargarGrilla();
            }
        }

        /// <summary>Da de baja al empleado seleccionado, previa confirmación.</summary>
        private void btnBaja_Click(object sender, EventArgs e)
        {
            Empleado emp = EmpleadoSeleccionado();
            if (emp == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de dar de baja a {emp.NombreCompleto}?\nSus ventas anteriores se conservan en el historial.",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            sistema.Administrador.BajaEmpleado(sistema, emp);
            sistema.Guardar();
            CargarGrilla();
            MessageBox.Show("Empleado dado de baja.", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>El administrador marca la asistencia de hoy del empleado seleccionado.</summary>
        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            Empleado emp = EmpleadoSeleccionado();
            if (emp == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sistema.Administrador.MarcarAsistenciaEmpleado(emp))
            {
                sistema.Guardar();
                MessageBox.Show($"Asistencia de hoy registrada para {emp.NombreCompleto}.", "Asistencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                string dni = emp.Dni.ToString();
                CargarGrilla();
                SeleccionarPorDni(dni);
            }
            else
            {
                MessageBox.Show($"{emp.NombreCompleto} ya tiene la asistencia de hoy marcada.", "Asistencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Vuelve a seleccionar en la grilla al empleado con el DNI indicado.</summary>
        private void SeleccionarPorDni(string dni)
        {
            foreach (DataGridViewRow fila in dgvEmpleados.Rows)
            {
                if (fila.Tag is Empleado emp && emp.Dni.ToString() == dni)
                {
                    fila.Selected = true;
                    dgvEmpleados.CurrentCell = fila.Cells[0];
                    return;
                }
            }
        }

        /// <summary>Vuelve al panel del administrador.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
