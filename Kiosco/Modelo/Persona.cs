namespace Kiosco
{
    /// <summary>
    /// Clase base abstracta que representa a una persona del sistema (administrador o empleado).
    /// </summary>
    [Serializable]
    public abstract class Persona
    {
        /// <summary>Asistencias registradas. Es privada para que solo se modifique con MarcarAsistencia.</summary>
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
                // Si todavía no llegó el cumpleaños de este año, aún no cumplió esa edad.
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
        /// <param name="nombres">Nombres de la persona.</param>
        /// <param name="apellidos">Apellidos de la persona.</param>
        /// <param name="dni">Documento Nacional de Identidad.</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento (de ahí se calcula la edad).</param>
        protected Persona(string nombres, string apellidos, int dni, DateTime fechaNacimiento)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            Dni = dni;
            FechaNacimiento = fechaNacimiento;
        }

        /// <summary>Indica si la persona ya marcó asistencia el día de hoy.</summary>
        /// <returns>true si existe una asistencia con la fecha de hoy.</returns>
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
        /// Si hubo más de una asistencia el mismo día, ese día cuenta una sola vez.
        /// </summary>
        /// <param name="desde">Primer día del rango (se ignora la hora).</param>
        /// <param name="hasta">Último día del rango (se ignora la hora).</param>
        /// <returns>Cantidad de días distintos con asistencia dentro del rango.</returns>
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
