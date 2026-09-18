namespace Kiosco
{
    /// <summary>
    /// Medios de pago aceptados por el kiosco.
    /// </summary>
    public enum MedioPago
    {
        /// <summary>Pago con billetes: suma al efectivo esperado en la caja.</summary>
        Efectivo,
        /// <summary>Pago con tarjeta: se registra en la venta pero no suma al efectivo de la caja.</summary>
        Tarjeta
    }
}
