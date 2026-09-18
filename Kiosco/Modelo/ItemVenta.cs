namespace Kiosco
{
    /// <summary>
    /// Renglón de una venta. Guarda una copia de los datos del producto al momento de vender,
    /// de modo que el historial no cambia aunque el producto se modifique o se dé de baja.
    /// </summary>
    [Serializable]
    public class ItemVenta
    {
        /// <summary>Código del producto vendido.</summary>
        public string Codigo { get; private set; }

        /// <summary>Nombre del producto vendido.</summary>
        public string Nombre { get; private set; }

        /// <summary>Precio unitario cobrado.</summary>
        public decimal PrecioUnitario { get; private set; }

        /// <summary>Cantidad de unidades.</summary>
        public int Cantidad { get; set; }

        /// <summary>Precio unitario por cantidad.</summary>
        public decimal Subtotal => PrecioUnitario * Cantidad;

        /// <summary>
        /// Crea un renglón de venta.
        /// </summary>
        /// <param name="codigo">Código del producto vendido.</param>
        /// <param name="nombre">Nombre del producto al momento de la venta.</param>
        /// <param name="precioUnitario">Precio cobrado por unidad (ya con la promoción aplicada).</param>
        /// <param name="cantidad">Unidades vendidas.</param>
        public ItemVenta(string codigo, string nombre, decimal precioUnitario, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }
    }
}
