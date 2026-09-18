namespace Kiosco
{
    /// <summary>
    /// Resumen de un turno de caja ya cerrado.
    /// </summary>
    [Serializable]
    public class CierreCaja
    {
        /// <summary>Momento en que se abrió la caja.</summary>
        public DateTime FechaApertura { get; private set; }

        /// <summary>Momento en que se cerró la caja.</summary>
        public DateTime FechaCierre { get; private set; }

        /// <summary>Dinero con el que se abrió la caja.</summary>
        public decimal MontoInicial { get; private set; }

        /// <summary>Total cobrado en efectivo.</summary>
        public decimal TotalEfectivo { get; private set; }

        /// <summary>Total cobrado con tarjeta.</summary>
        public decimal TotalTarjeta { get; private set; }

        /// <summary>Cantidad de ventas del turno.</summary>
        public int CantidadVentas { get; private set; }

        /// <summary>Total vendido en el turno.</summary>
        public decimal TotalVendido => TotalEfectivo + TotalTarjeta;

        /// <summary>Efectivo que debería haber en la caja (monto inicial + ventas en efectivo).</summary>
        public decimal EfectivoEsperado => MontoInicial + TotalEfectivo;

        /// <summary>
        /// Crea el resumen de un cierre de caja.
        /// </summary>
        public CierreCaja(DateTime fechaApertura, DateTime fechaCierre, decimal montoInicial,
                          decimal totalEfectivo, decimal totalTarjeta, int cantidadVentas)
        {
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
            MontoInicial = montoInicial;
            TotalEfectivo = totalEfectivo;
            TotalTarjeta = totalTarjeta;
            CantidadVentas = cantidadVentas;
        }

        /// <summary>Texto resumen del cierre.</summary>
        public override string ToString()
        {
            return $"Apertura: {FechaApertura:dd/MM/yyyy HH:mm}\n" +
                   $"Cierre: {FechaCierre:dd/MM/yyyy HH:mm}\n" +
                   $"Ventas: {CantidadVentas}\n" +
                   $"Efectivo: ${TotalEfectivo:0.00}\n" +
                   $"Tarjeta: ${TotalTarjeta:0.00}\n" +
                   $"Total vendido: ${TotalVendido:0.00}\n" +
                   $"Efectivo esperado en caja: ${EfectivoEsperado:0.00}";
        }
    }
}
