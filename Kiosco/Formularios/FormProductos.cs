namespace Kiosco
{
    /// <summary>
    /// Listado de productos con búsqueda, filtros (proveedor, categoría y promo), alta, edición, baja
    /// y acceso a precios y promociones.
    /// </summary>
    public partial class FormProductos : Form
    {
        /// <summary>Cantidad de unidades hasta la cual (inclusive) el producto se marca en rojo como "bajo stock".</summary>
        private const int StockBajo = 10;
        /// <summary>Primera opción de cada combo de filtro: no filtra.</summary>
        private const string OpcionTodos = "Todos";
        /// <summary>Opción del filtro de promo: solo productos con descuento.</summary>
        private const string OpcionConPromo = "Con promo";
        /// <summary>Opción del filtro de promo: solo productos sin descuento.</summary>
        private const string OpcionSinPromo = "Sin promo";

        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;
        /// <summary>true mientras se rellenan los combos de filtro, para no recargar la grilla en cada cambio.</summary>
        private bool cargandoFiltros;

        /// <summary>
        /// Crea el formulario de gestión de productos.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
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
            dgvProductos.Columns.Add("Descripcion", "Descripción");
            dgvProductos.Columns.Add("Marca", "Marca");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("Unidad", "Unidad");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("PrecioFinal", "Precio final");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Proveedor", "Proveedor");
            dgvProductos.Columns["Descripcion"].FillWeight = 150;
            dgvProductos.Columns["Unidad"].FillWeight = 60;
            dgvProductos.Columns["Stock"].FillWeight = 60;
        }

        /// <summary>Carga los filtros y la grilla al abrir el formulario.</summary>
        private void FormProductos_Load(object sender, EventArgs e)
        {
            cmbPromo.Items.AddRange(new object[] { OpcionTodos, OpcionConPromo, OpcionSinPromo });
            cmbPromo.SelectedIndex = 0;
            CargarFiltros();
            CargarGrilla();
        }

        /// <summary>
        /// Rellena los combos de proveedor y categoría con los valores que usan los productos
        /// (sin repetir y sin distinguir mayúsculas y minúsculas). Conserva la opción elegida si sigue existiendo.
        /// </summary>
        private void CargarFiltros()
        {
            cargandoFiltros = true;
            RellenarCombo(cmbProveedor, sistema.Productos.Select(p => p.Proveedor));
            RellenarCombo(cmbCategoria, sistema.Productos.Select(p => p.Categoria));
            cargandoFiltros = false;
        }

        /// <summary>Carga en un combo la opción "Todos" y los valores distintos no vacíos.</summary>
        /// <param name="combo">Combo a rellenar.</param>
        /// <param name="valores">Valores tomados de los productos.</param>
        private static void RellenarCombo(ComboBox combo, IEnumerable<string> valores)
        {
            string elegido = combo.SelectedItem as string;
            combo.Items.Clear();
            combo.Items.Add(OpcionTodos);
            combo.Items.AddRange(valores
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Distinct(StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(v => v)
                .Cast<object>().ToArray());

            int indice = elegido == null ? -1 : combo.FindStringExact(elegido);
            combo.SelectedIndex = indice >= 0 ? indice : 0;
        }

        /// <summary>Indica si el valor coincide con la opción elegida en el combo ("Todos" deja pasar todo).</summary>
        /// <param name="combo">Combo de filtro.</param>
        /// <param name="valor">Valor del producto.</param>
        private static bool CoincideFiltro(ComboBox combo, string valor)
        {
            string elegido = combo.SelectedItem as string;
            return elegido == null || elegido == OpcionTodos ||
                   string.Equals(elegido, valor, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>Carga los productos que coinciden con el texto de búsqueda y con los filtros elegidos.</summary>
        private void CargarGrilla()
        {
            string filtro = txtBuscar.Text.Trim();
            string promo = cmbPromo.SelectedItem as string;
            dgvProductos.Rows.Clear();

            IEnumerable<Producto> productos = sistema.Productos
                .Where(p => CoincideFiltro(cmbProveedor, p.Proveedor) && CoincideFiltro(cmbCategoria, p.Categoria))
                .Where(p => promo == OpcionConPromo ? p.PorcentajePromocion > 0
                          : promo == OpcionSinPromo ? p.PorcentajePromocion == 0
                          : true)
                .OrderBy(p => p.Nombre);
            if (filtro.Length > 0)
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Codigo.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Marca.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Categoria.Contains(filtro, StringComparison.CurrentCultureIgnoreCase));
            }

            foreach (Producto p in productos)
            {
                int fila = dgvProductos.Rows.Add(
                    p.Codigo, p.Nombre, p.Marca, p.Categoria, p.UnidadMedida, p.Precio.ToString("$0.00"),
                    p.PrecioFinal.ToString("$0.00"), p.Stock, p.Proveedor);
                dgvProductos.Rows[fila].Tag = p;
                if (p.Stock <= StockBajo)
                {
                    dgvProductos.Rows[fila].DefaultCellStyle.ForeColor = Color.Red;
                    dgvProductos.Rows[fila].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
            dgvProductos.ClearSelection();
        }

        /// <summary>Recarga los filtros (pueden aparecer proveedores o categorías nuevas) y la grilla.</summary>
        private void Recargar()
        {
            CargarFiltros();
            CargarGrilla();
        }

        /// <summary>Devuelve el producto seleccionado (o null).</summary>
        private Producto ProductoSeleccionado()
        {
            // ClearSelection() deja CurrentRow apuntando a una fila que ya no está seleccionada,
            // por eso también se pregunta por Selected.
            if (dgvProductos.CurrentRow == null || !dgvProductos.CurrentRow.Selected) return null;
            return dgvProductos.CurrentRow.Tag as Producto;
        }

        /// <summary>Filtra el listado mientras se escribe o al cambiar un filtro.</summary>
        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (!cargandoFiltros) CargarGrilla();
        }

        /// <summary>Abre el alta de un producto nuevo.</summary>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (FormAltaProducto alta = new FormAltaProducto(sistema))
            {
                if (alta.ShowDialog() == DialogResult.OK) Recargar();
            }
        }

        /// <summary>Abre la edición del producto seleccionado (descripción, marca, costo, margen, stock, etc.).</summary>
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
                if (edicion.ShowDialog() == DialogResult.OK) Recargar();
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
            Recargar();
            MessageBox.Show("Producto dado de baja.", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Abre la configuración de precios y promociones y, al volver, actualiza el listado.</summary>
        private void btnPromociones_Click(object sender, EventArgs e)
        {
            using (FormPromociones promociones = new FormPromociones(sistema))
            {
                promociones.ShowDialog();
            }
            Recargar();
        }

        /// <summary>Vuelve al panel de Administración.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
