namespace Kiosco
{
    /// <summary>
    /// Configuración de precios: promociones (descuento %) por producto y ajuste de precios por categoría.
    /// </summary>
    public partial class FormPromociones : Form
    {
        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;

        /// <summary>
        /// Crea el formulario de precios y promociones.
        /// </summary>
        /// <param name="sistema">Sistema con los datos del kiosco (empleados, productos y caja).</param>
        public FormPromociones(Sistema sistema)
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
            dgvProductos.Columns["Nombre"].FillWeight = 150;
            dgvProductos.Columns["Promo"].FillWeight = 60;
        }

        /// <summary>Carga la grilla y las categorías al abrir el formulario.</summary>
        private void FormPromociones_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarCategorias();
        }

        /// <summary>Carga los productos en la grilla.</summary>
        private void CargarGrilla()
        {
            dgvProductos.Rows.Clear();
            foreach (Producto p in sistema.Productos.OrderBy(x => x.Nombre))
            {
                int fila = dgvProductos.Rows.Add(
                    p.Codigo, p.Nombre, p.Categoria, p.Precio.ToString("$0.00"),
                    p.PorcentajePromocion, p.PrecioFinal.ToString("$0.00"));
                dgvProductos.Rows[fila].Tag = p;
                if (p.PorcentajePromocion > 0)
                    dgvProductos.Rows[fila].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
            dgvProductos.ClearSelection();
        }

        /// <summary>Carga en el combo las categorías que tienen productos.</summary>
        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(
                sistema.Productos.Select(p => p.Categoria).Distinct().OrderBy(c => c).Cast<object>().ToArray());
        }

        /// <summary>Devuelve el producto seleccionado (o null).</summary>
        private Producto ProductoSeleccionado()
        {
            // ClearSelection() deja CurrentRow apuntando a una fila que ya no está seleccionada,
            // por eso también se pregunta por Selected.
            if (dgvProductos.CurrentRow == null || !dgvProductos.CurrentRow.Selected) return null;
            return dgvProductos.CurrentRow.Tag as Producto;
        }

        /// <summary>Al seleccionar un producto se muestra su promoción actual.</summary>
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Producto producto = ProductoSeleccionado();
            if (producto != null) nudPromocion.Value = producto.PorcentajePromocion;
        }

        /// <summary>Aplica el porcentaje de descuento al producto seleccionado.</summary>
        private void btnAplicarPromocion_Click(object sender, EventArgs e)
        {
            Producto producto = ProductoSeleccionado();
            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto.", "Promoción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            producto.PorcentajePromocion = nudPromocion.Value;
            sistema.Guardar();
            CargarGrilla();
            MessageBox.Show(
                $"Promoción aplicada a {producto.Nombre}: {producto.PorcentajePromocion}% de descuento.\n" +
                $"Nuevo precio: ${producto.PrecioFinal:0.00}",
                "Promoción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Quita las promociones de todos los productos, previa confirmación.</summary>
        private void btnQuitarPromociones_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Quitar la promoción de TODOS los productos?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            foreach (Producto p in sistema.Productos) p.PorcentajePromocion = 0;
            sistema.Guardar();
            CargarGrilla();
        }

        /// <summary>Sube o baja el precio de lista de todos los productos de una categoría.</summary>
        private void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Ajuste de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nudAjuste.Value == 0)
            {
                MessageBox.Show("El ajuste es 0%: no hay nada para modificar.", "Ajuste de precios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string categoria = (string)cmbCategoria.SelectedItem;
            List<Producto> afectados = sistema.Productos.Where(p => p.Categoria == categoria).ToList();
            DialogResult respuesta = MessageBox.Show(
                $"Se modificará el precio de {afectados.Count} producto(s) de \"{categoria}\" en {nudAjuste.Value:+0;-0}%.\n¿Continuar?",
                "Confirmar ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            foreach (Producto p in afectados)
                p.Precio = Math.Round(p.Precio * (1 + nudAjuste.Value / 100m), 2);

            sistema.Guardar();
            CargarGrilla();
            MessageBox.Show("Precios actualizados.", "Ajuste de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Vuelve al panel del administrador.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
