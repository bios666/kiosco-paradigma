namespace Kiosco
{
    /// <summary>
    /// Aspecto visual común de los formularios (colores de botones y grillas) y carga de imágenes decorativas.
    /// </summary>
    public static class Estilo
    {
        private static readonly Color ColorPrincipal = Color.FromArgb(0, 121, 107);
        private static readonly Color ColorSecundario = Color.FromArgb(96, 125, 139);
        private static readonly Color ColorFondo = Color.FromArgb(250, 247, 240);

        /// <summary>
        /// Aplica el estilo común a un formulario y a todos sus controles.
        /// </summary>
        public static void Aplicar(Form formulario)
        {
            formulario.BackColor = ColorFondo;
            formulario.Font = new Font("Segoe UI", 10F);
            formulario.StartPosition = FormStartPosition.CenterScreen;
            AplicarControles(formulario);
        }

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
