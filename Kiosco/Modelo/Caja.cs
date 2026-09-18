namespace Kiosco
{
    /// <summary>
    /// Caja del kiosco: controla apertura y cierre, guarda el historial de ventas
    /// y calcula totales y sueldos.
    /// </summary>
    [Serializable]
    public class Caja
    {
        /// <summary>Historial completo de ventas de todos los turnos.</summary>
        private readonly List<Venta> ventas = new List<Venta>();
        /// <summary>Resúmenes de los turnos ya cerrados.</summary>
        private readonly List<CierreCaja> cierres = new List<CierreCaja>();
        /// <summary>Último número de venta asignado. RegistrarVenta lo incrementa para que la numeración sea correlativa.</summary>
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
        /// <param name="montoInicial">Dinero con el que se abre la caja (puede ser 0).</param>
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

            // Se toma una "foto" de las ventas del turno antes de cerrar (después de cerrar,
            // VentasDelTurno() devuelve vacío) y se separan los totales por medio de pago.
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
        /// <param name="venta">Venta ya confirmada (con medio de pago y fecha).</param>
        /// <exception cref="InvalidOperationException">Si la caja está cerrada.</exception>
        public void RegistrarVenta(Venta venta)
        {
            if (!Abierta)
                throw new InvalidOperationException("La caja está cerrada.");
            // La numeración es correlativa y nunca se reutiliza, aunque se den de baja empleados o productos.
            venta.Numero = ++ultimoNumeroVenta;
            ventas.Add(venta);
        }

        /// <summary>Ventas realizadas desde la apertura de la caja actual.</summary>
        /// <returns>Las ventas del turno; vacío si la caja está cerrada.</returns>
        public IEnumerable<Venta> VentasDelTurno()
        {
            if (!Abierta) return Enumerable.Empty<Venta>();
            return ventas.Where(v => v.FechaHora >= FechaApertura);
        }

        /// <summary>Total del turno actual, opcionalmente filtrado por medio de pago.</summary>
        /// <param name="medioPago">Medio de pago a sumar; null suma todos.</param>
        /// <returns>Suma de los totales de las ventas del turno.</returns>
        public decimal TotalDelTurno(MedioPago? medioPago = null)
        {
            return VentasDelTurno()
                .Where(v => medioPago == null || v.MedioPago == medioPago)
                .Sum(v => v.Total);
        }

        /// <summary>Ventas entre dos fechas (ambas incluidas).</summary>
        /// <param name="desde">Primer día (desde las 00:00).</param>
        /// <param name="hasta">Último día (hasta las 23:59:59).</param>
        /// <returns>Las ventas cuya fecha cae dentro del rango.</returns>
        public IEnumerable<Venta> VentasEntre(DateTime desde, DateTime hasta)
        {
            DateTime fin = hasta.Date.AddDays(1);
            return ventas.Where(v => v.FechaHora >= desde.Date && v.FechaHora < fin);
        }

        /// <summary>Total vendido entre dos fechas.</summary>
        /// <param name="desde">Primer día del rango.</param>
        /// <param name="hasta">Último día del rango.</param>
        /// <returns>Suma de los totales de las ventas del rango.</returns>
        public decimal TotalVendidoEntre(DateTime desde, DateTime hasta)
        {
            return VentasEntre(desde, hasta).Sum(v => v.Total);
        }

        /// <summary>Total vendido por un empleado (identificado por DNI) entre dos fechas.</summary>
        /// <param name="dni">DNI del empleado (se busca en la copia guardada en cada venta).</param>
        /// <param name="desde">Primer día del rango.</param>
        /// <param name="hasta">Último día del rango.</param>
        /// <returns>Suma de los totales de las ventas de ese empleado en el rango.</returns>
        public decimal TotalVendidoPorEmpleado(int dni, DateTime desde, DateTime hasta)
        {
            return VentasEntre(desde, hasta).Where(v => v.EmpleadoDni == dni).Sum(v => v.Total);
        }

        /// <summary>
        /// Calcula el sueldo a pagar a un empleado: días trabajados en el rango por su sueldo diario.
        /// </summary>
        /// <param name="empleado">Empleado a liquidar.</param>
        /// <param name="desde">Primer día del período.</param>
        /// <param name="hasta">Último día del período.</param>
        /// <returns>Días trabajados multiplicado por el sueldo por día.</returns>
        public decimal CalcularSueldo(Empleado empleado, DateTime desde, DateTime hasta)
        {
            return empleado.DiasTrabajados(desde, hasta) * empleado.SueldoPorDia;
        }
    }
}
