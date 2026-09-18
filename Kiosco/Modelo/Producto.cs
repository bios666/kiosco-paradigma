namespace Kiosco
{
    /// <summary>
    /// Producto que se vende en el kiosco.
    /// </summary>
    [Serializable]
    public class Producto
    {
        /// <summary>Código único del producto (ej. código de barras).</summary>
        public string Codigo { get; private set; }

        /// <summary>Nombre del producto.</summary>
        public string Nombre { get; set; }

        /// <summary>Categoría (ej. Golosinas, Bebidas).</summary>
        public string Categoria { get; set; }

        /// <summary>Precio de lista.</summary>
        public decimal Precio { get; set; }

        /// <summary>Unidades disponibles.</summary>
        public int Stock { get; set; }

        /// <summary>Proveedor (opcional).</summary>
        public string Proveedor { get; set; }

        /// <summary>Porcentaje de descuento vigente (0 = sin promoción).</summary>
        public decimal PorcentajePromocion { get; set; }

        /// <summary>Precio que se cobra, con la promoción aplicada.</summary>
        public decimal PrecioFinal => Math.Round(Precio * (1 - PorcentajePromocion / 100m), 2);

        /// <summary>
        /// Crea un producto. No tiene promoción al crearse (PorcentajePromocion = 0).
        /// </summary>
        /// <param name="codigo">Código único del producto.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="categoria">Categoría (ej. Golosinas).</param>
        /// <param name="precio">Precio de lista.</param>
        /// <param name="stock">Unidades disponibles.</param>
        /// <param name="proveedor">Proveedor (puede quedar vacío).</param>
        public Producto(string codigo, string nombre, string categoria, decimal precio, int stock, string proveedor)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
            Proveedor = proveedor;
        }

        /// <summary>
        /// Descuenta stock al vender.
        /// </summary>
        /// <param name="cantidad">Unidades vendidas (mayor a cero).</param>
        /// <exception cref="ArgumentException">Si la cantidad es cero o negativa.</exception>
        /// <exception cref="InvalidOperationException">Si no hay stock suficiente.</exception>
        public void DescontarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (cantidad > Stock)
                throw new InvalidOperationException($"Stock insuficiente de {Nombre}. Disponible: {Stock}.");
            Stock -= cantidad;
        }

        /// <summary>Descripción del producto.</summary>
        public override string ToString()
        {
            return $"{Codigo} - {Nombre} (${PrecioFinal:0.00})";
        }
    }
}
