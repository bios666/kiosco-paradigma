namespace Kiosco
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Abre el sistema guardado (o crea uno nuevo en la primera ejecución) y muestra la pantalla inicial.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Sistema sistema;
            try
            {
                sistema = Sistema.Abrir();
            }
            // Si el archivo existe pero no se puede leer, se avisa y se sale SIN crear uno nuevo:
            // al guardar de nuevo se pisarían datos que quizás se puedan recuperar.
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir el archivo del sistema:\n" + Rutas.ArchivoSistema + "\n\n" + ex.Message +
                    "\n\nPara no perder datos, la aplicación se cerrará sin modificar el archivo.",
                    "Error al abrir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FormInicio(sistema));
        }
    }
}
