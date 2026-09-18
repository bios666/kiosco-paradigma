using System.Text;

namespace Kiosco
{
    /// <summary>
    /// Venta (ticket) del kiosco. Mientras se arma funciona como carrito;
    /// al confirmarse queda registrada con fecha, número y medio de pago.
    /// </summary>
    [Serializable]
    public class Venta
    {
        private const int AnchoTicket = 44;
        private readonly List<ItemVenta> items = new List<ItemVenta>();

        /// <summary>Número correlativo de la venta (lo asigna la caja).</summary>
        public int Numero { get; set; }

        /// <summary>Fecha y hora en que se confirmó la venta.</summary>
        public DateTime FechaHora { get; private set; }

        /// <summary>Nombre del empleado que realizó la venta.</summary>
        public string EmpleadoNombre { get; private set; }

        /// <summary>DNI del empleado que realizó la venta.</summary>
        public int EmpleadoDni { get; private set; }

        /// <summary>Medio de pago elegido.</summary>
        public MedioPago MedioPago { get; private set; }

        /// <summary>Renglones de la venta.</summary>
        public IReadOnlyList<ItemVenta> Items => items;

        /// <summary>Total de la venta.</summary>
        public decimal Total => items.Sum(i => i.Subtotal);

        /// <summary>
        /// Crea una venta vacía (carrito) para un empleado.
        /// </summary>
        public Venta(Empleado empleado)
        {
            EmpleadoNombre = empleado.NombreCompleto;
            EmpleadoDni = empleado.Dni;
        }

        /// <summary>
        /// Agrega un producto al carrito. Si ya estaba, suma la cantidad.
        /// </summary>
        /// <exception cref="InvalidOperationException">Si la cantidad total supera el stock.</exception>
        public void AgregarItem(Producto producto, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            ItemVenta existente = items.Find(i => i.Codigo == producto.Codigo);
            int enCarrito = existente?.Cantidad ?? 0;
            if (enCarrito + cantidad > producto.Stock)
                throw new InvalidOperationException(
                    $"Stock insuficiente de {producto.Nombre}. Disponible: {producto.Stock - enCarrito}.");

            if (existente != null)
                existente.Cantidad += cantidad;
            else
                items.Add(new ItemVenta(producto.Codigo, producto.Nombre, producto.PrecioFinal, cantidad));
        }

        /// <summary>Quita un renglón del carrito.</summary>
        public void QuitarItem(ItemVenta item)
        {
            items.Remove(item);
        }

        /// <summary>
        /// Confirma la venta: fija el medio de pago y la fecha y hora.
        /// </summary>
        public void Confirmar(MedioPago medioPago)
        {
            MedioPago = medioPago;
            FechaHora = DateTime.Now;
        }

        /// <summary>
        /// Arma el texto del ticket de la venta.
        /// </summary>
        public string ArmarTicket()
        {
            string linea = new string('=', AnchoTicket);
            string guiones = new string('-', AnchoTicket);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(linea);
            sb.AppendLine("KIOSCO - TICKET DE VENTA".PadLeft((AnchoTicket + 24) / 2));
            sb.AppendLine(linea);
            sb.AppendLine($"Nº de venta : {Numero:000000}");
            sb.AppendLine($"Fecha       : {FechaHora:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Empleado    : {EmpleadoNombre}");
            sb.AppendLine($"Medio pago  : {MedioPago}");
            sb.AppendLine(guiones);
            sb.AppendLine($"{"Cant",-5}{"Producto",-20}{"P.Unit",9}{"Subtotal",10}");
            sb.AppendLine(guiones);
            foreach (ItemVenta item in items)
            {
                string nombre = item.Nombre.Length > 19 ? item.Nombre.Substring(0, 19) : item.Nombre;
                sb.AppendLine($"{item.Cantidad,-5}{nombre,-20}{item.PrecioUnitario,9:0.00}{item.Subtotal,10:0.00}");
            }
            sb.AppendLine(guiones);
            sb.AppendLine($"{"TOTAL: $" + Total.ToString("0.00"),AnchoTicket}");
            sb.AppendLine(linea);
            sb.AppendLine("Gracias por su compra!".PadLeft((AnchoTicket + 22) / 2));
            return sb.ToString();
        }

        /// <summary>
        /// Genera el archivo de texto del ticket en la carpeta indicada.
        /// </summary>
        /// <returns>Ruta completa del archivo generado.</returns>
        public string GenerarTicket(string carpeta)
        {
            Directory.CreateDirectory(carpeta);
            string ruta = Path.Combine(carpeta, $"Ticket_{Numero:000000}_{FechaHora:yyyyMMdd_HHmmss}.txt");
            File.WriteAllText(ruta, ArmarTicket(), Encoding.UTF8);
            return ruta;
        }

        /// <summary>Descripción resumida de la venta.</summary>
        public override string ToString()
        {
            return $"Venta {Numero:000000} - {FechaHora:dd/MM/yyyy HH:mm} - ${Total:0.00}";
        }
    }
}
