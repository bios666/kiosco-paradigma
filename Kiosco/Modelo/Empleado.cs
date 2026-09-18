namespace Kiosco
{
    /// <summary>
    /// Empleado del kiosco: realiza ventas y marca su propia asistencia.
    /// </summary>
    [Serializable]
    public class Empleado : Persona
    {
        private readonly List<Venta> ventas = new List<Venta>();

        /// <summary>Contraseña propia del empleado.</summary>
        public string Contrasena { get; set; }

        /// <summary>Sueldo que se paga por cada día trabajado.</summary>
        public decimal SueldoPorDia { get; set; }

        /// <summary>Ventas realizadas por el empleado.</summary>
        public IReadOnlyList<Venta> Ventas => ventas;

        /// <summary>
        /// Crea un empleado.
        /// </summary>
        public Empleado(string nombres, string apellidos, int dni, DateTime fechaNacimiento,
                        string contrasena, decimal sueldoPorDia)
            : base(nombres, apellidos, dni, fechaNacimiento)
        {
            Contrasena = contrasena;
            SueldoPorDia = sueldoPorDia;
        }

        /// <summary>Verifica la contraseña ingresada.</summary>
        public bool ValidarContrasena(string contrasena)
        {
            return Contrasena == contrasena;
        }

        /// <summary>
        /// Confirma una venta: verifica la caja y el stock, descuenta el stock,
        /// registra la venta en la caja y en el historial del empleado.
        /// </summary>
        /// <param name="venta">Venta armada (carrito).</param>
        /// <param name="medioPago">Medio de pago elegido.</param>
        /// <param name="sistema">Sistema que contiene la caja y los productos.</param>
        /// <exception cref="InvalidOperationException">Si la caja está cerrada, el carrito está vacío o falta stock.</exception>
        public void RealizarVenta(Venta venta, MedioPago medioPago, Sistema sistema)
        {
            if (venta.Items.Count == 0)
                throw new InvalidOperationException("La venta no tiene productos.");
            if (!sistema.Caja.Abierta)
                throw new InvalidOperationException("La caja está cerrada. Debe abrirla antes de vender.");

            // Primero se verifica todo el stock para no dejar la venta a medias.
            foreach (ItemVenta item in venta.Items)
            {
                Producto producto = sistema.BuscarProducto(item.Codigo);
                if (producto == null)
                    throw new InvalidOperationException($"El producto {item.Nombre} ya no existe.");
                if (producto.Stock < item.Cantidad)
                    throw new InvalidOperationException($"Stock insuficiente de {item.Nombre}. Disponible: {producto.Stock}.");
            }

            foreach (ItemVenta item in venta.Items)
                sistema.BuscarProducto(item.Codigo).DescontarStock(item.Cantidad);

            venta.Confirmar(medioPago);
            sistema.Caja.RegistrarVenta(venta);
            ventas.Add(venta);
        }

        /// <summary>Ventas realizadas por el empleado durante el día de hoy.</summary>
        public IEnumerable<Venta> VentasDelDia()
        {
            return ventas.Where(v => v.FechaHora.Date == DateTime.Today);
        }

        /// <summary>Ventas realizadas por el empleado desde que se abrió la caja actual.</summary>
        public IEnumerable<Venta> VentasDelTurno(Caja caja)
        {
            if (!caja.Abierta) return Enumerable.Empty<Venta>();
            return ventas.Where(v => v.FechaHora >= caja.FechaApertura);
        }

        /// <summary>Descripción del empleado.</summary>
        public override string ToString()
        {
            return $"Empleado: {NombreCompleto} (DNI {Dni})";
        }
    }
}
