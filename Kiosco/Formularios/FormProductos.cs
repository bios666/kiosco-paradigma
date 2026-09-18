namespace Kiosco
{
    /// <summary>
    /// Listado de productos con búsqueda, alta, edición de precio/stock y baja.
    /// </summary>
    public partial class FormProductos : Form
    {
        private const int StockBajo = 5;
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el formulario de gestión de productos.
        /// </summary>
        public FormProductos(Sistema sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            Estilo.Aplicar(this);
            ConfigurarColumnas();
        }

        /// <summary>Define las columnas de la grilla.</summary>
        private void ConfigurarColumnas()
        {
            dgvProductos.Columns.Add("Codigo", "Código");
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Promo", "Promo %");
            dgvProductos.Columns.Add("PrecioFinal", "Precio final");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Proveedor", "Proveedor");
            dgvProductos.Columns["Nombre"].FillWeight = 150;
            dgvProductos.Columns["Promo"].FillWeight = 60;
            dgvProductos.Columns["Stock"].FillWeight = 60;
        }

        /// <summary>Carga la grilla al abrir el formulario.</summary>
        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        /// <summary>Carga los productos que coinciden con el texto de búsqueda.</summary>
        private void CargarGrilla()
        {
            string filtro = txtBuscar.Text.Trim();
            dgvProductos.Rows.Clear();

            IEnumerable<Producto> productos = sistema.Productos.OrderBy(p => p.Nombre);
            if (filtro.Length > 0)
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Codigo.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Categoria.Contains(filtro, StringComparison.CurrentCultureIgnoreCase));
            }

            foreach (Producto p in productos)
            {
                int fila = dgvProductos.Rows.Add(
                    p.Codigo, p.Nombre, p.Categoria, p.Precio.ToString("$0.00"),
                    p.PorcentajePromocion, p.PrecioFinal.ToString("$0.00"), p.Stock, p.Proveedor);
                dgvProductos.Rows[fila].Tag = p;
                if (p.Stock <= StockBajo)
                    dgvProductos.Rows[fila].DefaultCellStyle.ForeColor = Color.Firebrick;
            }
            dgvProductos.ClearSelection();
        }

        /// <summary>Devuelve el producto seleccionado (o null).</summary>
        private Producto ProductoSeleccionado()
        {
            if (dgvProductos.CurrentRow == null || !dgvProductos.CurrentRow.Selected) return null;
            return dgvProductos.CurrentRow.Tag as Producto;
        }

        /// <summary>Filtra el listado mientras se escribe.</summary>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        /// <summary>Abre el alta de un producto nuevo.</summary>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (FormAltaProducto alta = new FormAltaProducto(sistema))
            {
                if (alta.ShowDialog() == DialogResult.OK) CargarGrilla();
            }
        }

        /// <summary>Abre la edición del producto seleccionado (precio, stock, etc.).</summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Producto producto = ProductoSeleccionado();
            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FormAltaProducto edicion = new FormAltaProducto(sistema, producto))
            {
                if (edicion.ShowDialog() == DialogResult.OK) CargarGrilla();
            }
        }

        /// <summary>Da de baja el producto seleccionado, previa confirmación.</summary>
        private void btnBaja_Click(object sender, EventArgs e)
        {
            Producto producto = ProductoSeleccionado();
            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto.", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de dar de baja el producto \"{producto.Nombre}\"?",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            sistema.Administrador.BajaProducto(sistema, producto);
            sistema.Guardar();
            CargarGrilla();
            MessageBox.Show("Producto dado de baja.", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Vuelve al panel del administrador.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
