namespace Kiosco
{
    /// <summary>
    /// Aspecto visual común de los formularios (colores de botones y grillas) y carga de imágenes decorativas.
    /// </summary>
    public static class Estilo
    {
        /// <summary>Verde azulado de los botones principales y de los encabezados de las grillas.</summary>
        private static readonly Color ColorPrincipal = Color.FromArgb(0, 121, 107);
        /// <summary>Gris azulado de los botones secundarios (Volver, Cancelar, Cerrar, Salir).</summary>
        private static readonly Color ColorSecundario = Color.FromArgb(96, 125, 139);
        /// <summary>Color de fondo de todos los formularios.</summary>
        private static readonly Color ColorFondo = Color.FromArgb(250, 247, 240);

        /// <summary>
        /// Aplica el estilo común a un formulario y a todos sus controles.
        /// Todas las ventanas se pueden minimizar; las pantallas principales además se abren
        /// en pantalla completa (maximizadas) y se pueden restaurar y volver a expandir.
        /// </summary>
        /// <param name="formulario">Formulario a estilizar. Se llama justo después de InitializeComponent().</param>
        /// <param name="pantallaCompleta">
        /// true (por defecto) para pantallas principales; false para diálogos chicos
        /// (logins, altas, monto inicial) que mantienen su tamaño fijo.
        /// </param>
        public static void Aplicar(Form formulario, bool pantallaCompleta = true)
        {
            formulario.BackColor = ColorFondo;
            formulario.Font = new Font("Segoe UI", 10F);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            // Con el padre oculto, la barra de tareas es la única forma de volver a una ventana minimizada.
            formulario.MinimizeBox = true;
            formulario.ShowInTaskbar = true;

            if (pantallaCompleta)
            {
                formulario.FormBorderStyle = FormBorderStyle.Sizable;
                formulario.MaximizeBox = true;
                // Al restaurar no se puede achicar por debajo del tamaño de diseño (los controles no entrarían).
                formulario.MinimumSize = formulario.Size;
                formulario.WindowState = FormWindowState.Maximized;
            }

            AplicarControles(formulario);
        }

        /// <summary>
        /// Mantiene todos los controles del formulario centrados como un bloque cuando la ventana
        /// cambia de tamaño. Se usa en las pantallas de menú (inicio y paneles), que tienen
        /// pocos botones y quedarían pegados a la esquina al maximizar.
        /// </summary>
        /// <param name="formulario">Formulario cuyos controles se centran.</param>
        public static void CentrarContenido(Form formulario)
        {
            formulario.Load += (s, e) => Centrar(formulario);
            formulario.Resize += (s, e) => Centrar(formulario);
        }

        /// <summary>
        /// Mueve todos los controles juntos para que el rectángulo que los contiene quede en el centro.
        /// Se calcula a partir de las posiciones actuales, así que se puede llamar las veces que haga falta.
        /// </summary>
        /// <param name="formulario">Formulario cuyos controles se mueven.</param>
        private static void Centrar(Form formulario)
        {
            if (formulario.Controls.Count == 0 || formulario.WindowState == FormWindowState.Minimized) return;

            Rectangle bloque = formulario.Controls[0].Bounds;
            foreach (Control control in formulario.Controls)
                bloque = Rectangle.Union(bloque, control.Bounds);

            int dx = (formulario.ClientSize.Width - bloque.Width) / 2 - bloque.Left;
            int dy = (formulario.ClientSize.Height - bloque.Height) / 2 - bloque.Top;
            if (dx == 0 && dy == 0) return;

            formulario.SuspendLayout();
            foreach (Control control in formulario.Controls)
                control.Location = new Point(control.Left + dx, control.Top + dy);
            formulario.ResumeLayout();
        }

        /// <summary>
        /// Recorre recursivamente los controles del contenedor y da estilo a los botones y a las grillas.
        /// Un botón es "secundario" (gris) si su nombre empieza con btnVolver, btnCancelar, btnCerrar o btnSalir.
        /// </summary>
        /// <param name="contenedor">Formulario o control cuyos hijos se estilizan.</param>
        private static void AplicarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is Button boton)
                {
                    bool secundario = boton.Name.StartsWith("btnVolver") || boton.Name.StartsWith("btnCancelar")
                        || boton.Name.StartsWith("btnCerrar") || boton.Name.StartsWith("btnSalir");
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.BackColor = secundario ? ColorSecundario : ColorPrincipal;
                    boton.ForeColor = Color.White;
                    boton.Cursor = Cursors.Hand;
                }
                else if (control is DataGridView grilla)
                {
                    grilla.EnableHeadersVisualStyles = false;
                    grilla.ColumnHeadersDefaultCellStyle.BackColor = ColorPrincipal;
                    grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grilla.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorPrincipal;
                    grilla.BackgroundColor = Color.White;
                    grilla.BorderStyle = BorderStyle.None;
                    grilla.RowHeadersVisible = false;
                    grilla.AllowUserToAddRows = false;
                    grilla.AllowUserToDeleteRows = false;
                    grilla.AllowUserToResizeRows = false;
                    grilla.ReadOnly = true;
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                if (control.HasChildren) AplicarControles(control);
            }
        }

        /// <summary>
        /// Carga la imagen decorativa (Resources/logo.png). Devuelve null si no se encuentra.
        /// </summary>
        /// <returns>La imagen, o null si el archivo falta o no se puede leer (el programa sigue funcionando sin ella).</returns>
        public static Image CargarLogo()
        {
            try
            {
                string ruta = Path.Combine(AppContext.BaseDirectory, "Resources", "logo.png");
                if (!File.Exists(ruta)) return null;
                using (Image original = Image.FromFile(ruta))
                {
                    // Se copia para no dejar el archivo bloqueado.
                    return new Bitmap(original);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
