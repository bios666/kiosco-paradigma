namespace Kiosco
{
    /// <summary>
    /// Administrador del kiosco: da de alta y baja empleados y productos, y marca asistencias de empleados.
    /// </summary>
    [Serializable]
    public class Administrador : Persona
    {
        /// <summary>Contraseña por defecto de ejemplo.</summary>
        public const string ContrasenaPorDefecto = "123123";

        /// <summary>Contraseña del administrador.</summary>
        public string Contrasena { get; private set; }

        /// <summary>
        /// Crea el administrador con datos y contraseña por defecto.
        /// </summary>
        public Administrador()
            : base("Administrador", "General", 0, new DateTime(1990, 1, 1))
        {
            Contrasena = ContrasenaPorDefecto;
        }

        /// <summary>Verifica la contraseña ingresada.</summary>
        public bool ValidarContrasena(string contrasena)
        {
            return Contrasena == contrasena;
        }

        /// <summary>
        /// Da de alta un empleado en el sistema.
        /// </summary>
        /// <returns>false si ya existe un empleado con el mismo DNI.</returns>
        public bool AltaEmpleado(Sistema sistema, Empleado empleado)
        {
            if (sistema.BuscarEmpleado(empleado.Dni) != null) return false;
            sistema.Empleados.Add(empleado);
            return true;
        }

        /// <summary>Da de baja (elimina) un empleado del sistema.</summary>
        public bool BajaEmpleado(Sistema sistema, Empleado empleado)
        {
            return sistema.Empleados.Remove(empleado);
        }

        /// <summary>
        /// Da de alta un producto en el sistema.
        /// </summary>
        /// <returns>false si ya existe un producto con el mismo código.</returns>
        public bool AltaProducto(Sistema sistema, Producto producto)
        {
            if (sistema.BuscarProducto(producto.Codigo) != null) return false;
            sistema.Productos.Add(producto);
            return true;
        }

        /// <summary>Da de baja (elimina) un producto del sistema.</summary>
        public bool BajaProducto(Sistema sistema, Producto producto)
        {
            return sistema.Productos.Remove(producto);
        }

        /// <summary>Marca la asistencia de hoy de un empleado. Devuelve false si ya estaba marcada.</summary>
        public bool MarcarAsistenciaEmpleado(Empleado empleado)
        {
            return empleado.MarcarAsistencia();
        }

        /// <summary>Descripción del administrador.</summary>
        public override string ToString()
        {
            return "Administrador del sistema";
        }
    }
}
