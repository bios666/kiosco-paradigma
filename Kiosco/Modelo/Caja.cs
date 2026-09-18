namespace Kiosco
{
    /// <summary>
    /// Caja del kiosco: controla apertura y cierre, guarda el historial de ventas
    /// y calcula totales y sueldos.
    /// </summary>
    [Serializable]
    public class Caja
    {
        private readonly List<Venta> ventas = new List<Venta>();
        private readonly List<CierreCaja> cierres = new List<CierreCaja>();
        private int ultimoNumeroVenta;

        /// <summary>Indica si la caja está abierta.</summary>
        public bool Abierta { get; private set; }

        /// <summary>Momento de apertura del turno actual.</summary>
        public DateTime FechaApertura { get; private set; }

        /// <summary>Monto inicial del turno actual.</summary>
        public decimal MontoInicial { get; private set; }

        /// <summary>Historial completo de ventas.</summary>
        public IReadOnlyList<Venta> Ventas => ventas;

        /// <summary>Historial de cierres de caja.</summary>
        public IReadOnlyList<CierreCaja> Cierres => cierres;

        /// <summary>Total vendido en todo el historial.</summary>
        public decimal TotalVendido => ventas.Sum(v => v.Total);

        /// <summary>
        /// Abre la caja con un monto inicial.
        /// </summary>
        /// <exception cref="InvalidOperationException">Si la caja ya estaba abierta.</exception>
        public void Abrir(decimal montoInicial)
        {
            if (Abierta)
                throw new InvalidOperationException("La caja ya está abierta.");
            Abierta = true;
            FechaApertura = DateTime.Now;
            MontoInicial = montoInicial;
        }

        /// <summary>
        /// Cierra la caja y guarda el resumen del turno.
        /// </summary>
        /// <returns>Resumen del cierre.</returns>
        /// <exception cref="InvalidOperationException">Si la caja ya estaba cerrada.</exception>
        public CierreCaja Cerrar()
        {
            if (!Abierta)
                throw new InvalidOperationException("La caja ya está cerrada.");

            List<Venta> delTurno = VentasDelTurno().ToList();
            CierreCaja cierre = new CierreCaja(
                FechaApertura,
                DateTime.Now,
                MontoInicial,
                delTurno.Where(v => v.MedioPago == MedioPago.Efectivo).Sum(v => v.Total),
                delTurno.Where(v => v.MedioPago == MedioPago.Tarjeta).Sum(v => v.Total),
                delTurno.Count);

            cierres.Add(cierre);
            Abierta = false;
            return cierre;
        }

        /// <summary>
        /// Registra una venta confirmada y le asigna su número correlativo.
        /// </summary>
        /// <exception cref="InvalidOperationException">Si la caja está cerrada.</exception>
        public void RegistrarVenta(Venta venta)
        {
            if (!Abierta)
                throw new InvalidOperationException("La caja está cerrada.");
            venta.Numero = ++ultimoNumeroVenta;
            ventas.Add(venta);
        }

        /// <summary>Ventas realizadas desde la apertura de la caja actual.</summary>
        public IEnumerable<Venta> VentasDelTurno()
        {
            if (!Abierta) return Enumerable.Empty<Venta>();
            return ventas.Where(v => v.FechaHora >= FechaApertura);
        }

        /// <summary>Total del turno actual, opcionalmente filtrado por medio de pago.</summary>
        public decimal TotalDelTurno(MedioPago? medioPago = null)
        {
            return VentasDelTurno()
                .Where(v => medioPago == null || v.MedioPago == medioPago)
                .Sum(v => v.Total);
        }

        /// <summary>Ventas entre dos fechas (ambas incluidas).</summary>
        public IEnumerable<Venta> VentasEntre(DateTime desde, DateTime hasta)
        {
            DateTime fin = hasta.Date.AddDays(1);
            return ventas.Where(v => v.FechaHora >= desde.Date && v.FechaHora < fin);
        }

        /// <summary>Total vendido entre dos fechas.</summary>
        public decimal TotalVendidoEntre(DateTime desde, DateTime hasta)
        {
            return VentasEntre(desde, hasta).Sum(v => v.Total);
        }

        /// <summary>Total vendido por un empleado (identificado por DNI) entre dos fechas.</summary>
        public decimal TotalVendidoPorEmpleado(int dni, DateTime desde, DateTime hasta)
        {
            return VentasEntre(desde, hasta).Where(v => v.EmpleadoDni == dni).Sum(v => v.Total);
        }

        /// <summary>
        /// Calcula el sueldo a pagar a un empleado: días trabajados en el rango por su sueldo diario.
        /// </summary>
        public decimal CalcularSueldo(Empleado empleado, DateTime desde, DateTime hasta)
        {
            return empleado.DiasTrabajados(desde, hasta) * empleado.SueldoPorDia;
        }
    }
}
