namespace Kiosco
{
    /// <summary>
    /// Clase base abstracta que representa a una persona del sistema (administrador o empleado).
    /// </summary>
    [Serializable]
    public abstract class Persona
    {
        private readonly List<Asistencia> asistencias = new List<Asistencia>();

        /// <summary>Nombres de la persona.</summary>
        public string Nombres { get; set; }

        /// <summary>Apellidos de la persona.</summary>
        public string Apellidos { get; set; }

        /// <summary>Documento Nacional de Identidad.</summary>
        public int Dni { get; set; }

        /// <summary>Fecha de nacimiento.</summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>Edad calculada a partir de la fecha de nacimiento.</summary>
        public int Edad
        {
            get
            {
                DateTime hoy = DateTime.Today;
                int edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        /// <summary>Nombre en formato "Apellidos, Nombres".</summary>
        public string NombreCompleto => $"{Apellidos}, {Nombres}";

        /// <summary>Registros de asistencia (turnos trabajados).</summary>
        public IReadOnlyList<Asistencia> Asistencias => asistencias;

        /// <summary>
        /// Crea una persona con sus datos básicos.
        /// </summary>
        protected Persona(string nombres, string apellidos, int dni, DateTime fechaNacimiento)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            Dni = dni;
            FechaNacimiento = fechaNacimiento;
        }

        /// <summary>Indica si la persona ya marcó asistencia el día de hoy.</summary>
        public bool TieneAsistenciaHoy()
        {
            return asistencias.Any(a => a.Fecha == DateTime.Today);
        }

        /// <summary>
        /// Marca la asistencia del día de hoy. No duplica el registro si ya estaba marcada.
        /// </summary>
        /// <returns>true si se registró una asistencia nueva; false si ya existía la de hoy.</returns>
        public bool MarcarAsistencia()
        {
            if (TieneAsistenciaHoy()) return false;
            asistencias.Add(new Asistencia(DateTime.Now));
            return true;
        }

        /// <summary>
        /// Cuenta los días trabajados dentro de un rango de fechas (ambos extremos incluidos).
        /// </summary>
        public int DiasTrabajados(DateTime desde, DateTime hasta)
        {
            return asistencias
                .Select(a => a.Fecha)
                .Distinct()
                .Count(f => f >= desde.Date && f <= hasta.Date);
        }

        /// <summary>Cada clase hija describe a la persona de manera distinta (polimorfismo).</summary>
        public abstract override string ToString();
    }
}
