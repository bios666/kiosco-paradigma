namespace Kiosco
{
    /// <summary>
    /// Registro de asistencia (turno trabajado) de una persona en un día determinado.
    /// </summary>
    [Serializable]
    public class Asistencia
    {
        /// <summary>Fecha y hora exacta en que se marcó la asistencia.</summary>
        public DateTime FechaHora { get; private set; }

        /// <summary>Solo la fecha (sin hora) de la asistencia.</summary>
        public DateTime Fecha => FechaHora.Date;

        /// <summary>
        /// Crea un registro de asistencia.
        /// </summary>
        /// <param name="fechaHora">Momento en que se marca la asistencia.</param>
        public Asistencia(DateTime fechaHora)
        {
            FechaHora = fechaHora;
        }

        /// <summary>Devuelve la asistencia en formato legible.</summary>
        public override string ToString()
        {
            return FechaHora.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
