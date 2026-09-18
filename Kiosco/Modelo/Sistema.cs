using System.Runtime.Serialization.Formatters.Binary;

namespace Kiosco
{
    /// <summary>
    /// Rutas de las carpetas y archivos que utiliza el sistema (dentro de Mis Documentos).
    /// </summary>
    public static class Rutas
    {
        /// <summary>Carpeta base. Por defecto es Mis Documentos.</summary>
        public static string CarpetaBase { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>Carpeta donde se guarda el archivo del sistema.</summary>
        public static string CarpetaArchivos => Path.Combine(CarpetaBase, "ArchivosKiosco");

        /// <summary>Carpeta donde se exportan los tickets de venta.</summary>
        public static string CarpetaTickets => Path.Combine(CarpetaBase, "TicketsKiosco");

        /// <summary>Archivo binario con todo el estado del sistema.</summary>
        public static string ArchivoSistema => Path.Combine(CarpetaArchivos, "sistema.dat");
    }

    /// <summary>
    /// Clase raíz del sistema: contiene al administrador, la caja, los empleados y los productos,
    /// y se encarga de guardarlos y abrirlos de disco por serialización binaria.
    /// </summary>
    [Serializable]
    public class Sistema
    {
        /// <summary>Administrador del sistema.</summary>
        public Administrador Administrador { get; private set; }

        /// <summary>Caja del kiosco.</summary>
        public Caja Caja { get; private set; }

        /// <summary>Empleados registrados.</summary>
        public List<Empleado> Empleados { get; private set; }

        /// <summary>Productos registrados.</summary>
        public List<Producto> Productos { get; private set; }

        /// <summary>
        /// Crea un sistema vacío con el administrador por defecto.
        /// </summary>
        public Sistema()
        {
            Administrador = new Administrador();
            Caja = new Caja();
            Empleados = new List<Empleado>();
            Productos = new List<Producto>();
        }

        /// <summary>Busca un empleado por DNI. Devuelve null si no existe.</summary>
        public Empleado BuscarEmpleado(int dni)
        {
            return Empleados.Find(e => e.Dni == dni);
        }

        /// <summary>Busca un producto por código. Devuelve null si no existe.</summary>
        public Producto BuscarProducto(string codigo)
        {
            return Productos.Find(p => p.Codigo == codigo);
        }

        /// <summary>
        /// Guarda todo el sistema en el archivo binario. Escribe primero un archivo temporal
        /// para no dañar el archivo anterior si algo falla a mitad de la escritura.
        /// </summary>
        public void Guardar()
        {
            Directory.CreateDirectory(Rutas.CarpetaArchivos);
            string temporal = Rutas.ArchivoSistema + ".tmp";

            using (FileStream flujo = new FileStream(temporal, FileMode.Create, FileAccess.Write))
            {
                new BinaryFormatter().Serialize(flujo, this);
            }
            File.Move(temporal, Rutas.ArchivoSistema, true);
        }

        /// <summary>
        /// Abre el sistema guardado en disco. Si todavía no existe el archivo
        /// (primera ejecución) devuelve un sistema nuevo.
        /// </summary>
        public static Sistema Abrir()
        {
            try
            {
                using (FileStream flujo = new FileStream(Rutas.ArchivoSistema, FileMode.Open, FileAccess.Read))
                {
                    return (Sistema)new BinaryFormatter().Deserialize(flujo);
                }
            }
            catch (FileNotFoundException)
            {
                return new Sistema();
            }
            catch (DirectoryNotFoundException)
            {
                return new Sistema();
            }
        }
    }
}
