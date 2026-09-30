using System.Runtime.Serialization;

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

        /// <summary>Descripción del producto (en pantalla se muestra como "Descripción").</summary>
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

        // Los campos siguientes se agregaron después de la primera versión. Se marcan con [OptionalField]
        // para que un sistema.dat guardado antes (que no los tiene) se pueda seguir abriendo.

        /// <summary>Marca del producto. Puede faltar en archivos viejos.</summary>
        [OptionalField]
        private string marca;
        /// <summary>Unidad de medida (Unidad, g, kg, ml, l, etc.). Puede faltar en archivos viejos.</summary>
        [OptionalField]
        private string unidadMedida;
        /// <summary>Costo de compra. 0 en productos cargados antes de existir este dato.</summary>
        [OptionalField]
        private decimal costo;
        /// <summary>Margen de ganancia (%) sobre el costo.</summary>
        [OptionalField]
        private decimal margenGanancia;

        /// <summary>Marca (ej. Arcor, Coca-Cola). Vacío si no se cargó.</summary>
        public string Marca
        {
            get => marca ?? string.Empty;
            set => marca = value;
        }

        /// <summary>Unidad de medida (ej. Unidad, g, kg, ml, l). Vacío si no se cargó.</summary>
        public string UnidadMedida
        {
            get => unidadMedida ?? string.Empty;
            set => unidadMedida = value;
        }

        /// <summary>Costo de compra del producto (0 = no cargado).</summary>
        public decimal Costo
        {
            get => costo;
            set => costo = value;
        }

        /// <summary>Margen de ganancia en porcentaje sobre el costo.</summary>
        public decimal MargenGanancia
        {
            get => margenGanancia;
            set => margenGanancia = value;
        }

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
        /// Calcula el precio de venta a partir del costo y el margen de ganancia.
        /// </summary>
        /// <param name="costo">Costo de compra.</param>
        /// <param name="margen">Margen de ganancia en porcentaje (ej. 30 = 30%).</param>
        /// <returns>Costo más el margen, redondeado a 2 decimales.</returns>
        public static decimal CalcularPrecio(decimal costo, decimal margen)
        {
            return Math.Round(costo * (1 + margen / 100m), 2);
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
