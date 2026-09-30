namespace Kiosco
{
    /// <summary>
    /// Configuración de precios: promociones (descuento %) por producto, búsqueda y ajuste de precio por marca.
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
            dgvProductos.Columns.Add("Descripcion", "Descripción");
            dgvProductos.Columns.Add("Marca", "Marca");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Promo", "Promo %");
            dgvProductos.Columns.Add("PrecioFinal", "Precio final");
            dgvProductos.Columns["Descripcion"].FillWeight = 150;
            dgvProductos.Columns["Promo"].FillWeight = 60;
        }

        /// <summary>Carga la grilla y las marcas al abrir el formulario.</summary>
        private void FormPromociones_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarMarcas();
        }

        /// <summary>Carga en la grilla los productos que coinciden con el texto de búsqueda (código, descripción o marca).</summary>
        private void CargarGrilla()
        {
            string filtro = txtBuscar.Text.Trim();
            dgvProductos.Rows.Clear();

            IEnumerable<Producto> productos = sistema.Productos.OrderBy(x => x.Nombre);
            if (filtro.Length > 0)
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Codigo.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Marca.Contains(filtro, StringComparison.CurrentCultureIgnoreCase));
            }

            foreach (Producto p in productos)
            {
                int fila = dgvProductos.Rows.Add(
                    p.Codigo, p.Nombre, p.Marca, p.Precio.ToString("$0.00"),
                    p.PorcentajePromocion, p.PrecioFinal.ToString("$0.00"));
                dgvProductos.Rows[fila].Tag = p;
                if (p.PorcentajePromocion > 0)
                    dgvProductos.Rows[fila].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
            dgvProductos.ClearSelection();
        }

        /// <summary>Carga en el combo las marcas que tienen productos (sin repetir, sin distinguir mayúsculas y minúsculas).</summary>
        private void CargarMarcas()
        {
            cmbMarca.Items.Clear();
            cmbMarca.Items.AddRange(sistema.Productos
                .Select(p => p.Marca)
                .Where(m => m.Length > 0)
                .Distinct(StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(m => m)
                .Cast<object>().ToArray());
        }

        /// <summary>Filtra la grilla mientras se escribe.</summary>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Sube o baja el precio de todos los productos de una marca. Si el producto tiene costo cargado,
        /// se ajusta el costo y se recalcula el precio (el margen de ganancia se mantiene);
        /// si no, se ajusta directamente el precio de lista.
        /// </summary>
        private void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una marca.", "Ajuste de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nudAjuste.Value == 0)
            {
                MessageBox.Show("El ajuste es 0%: no hay nada para modificar.", "Ajuste de precios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string marca = (string)cmbMarca.SelectedItem;
            List<Producto> afectados = sistema.Productos
                .Where(p => string.Equals(p.Marca, marca, StringComparison.CurrentCultureIgnoreCase)).ToList();
            DialogResult respuesta = MessageBox.Show(
                $"Se modificará el precio de {afectados.Count} producto(s) de la marca \"{marca}\" en {nudAjuste.Value:+0;-0}%.\n¿Continuar?",
                "Confirmar ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            decimal factor = 1 + nudAjuste.Value / 100m;
            foreach (Producto p in afectados)
            {
                if (p.Costo > 0)
                {
                    p.Costo = Math.Round(p.Costo * factor, 2);
                    p.Precio = Producto.CalcularPrecio(p.Costo, p.MargenGanancia);
                }
                else
                {
                    p.Precio = Math.Round(p.Precio * factor, 2);
                }
            }

            sistema.Guardar();
            CargarGrilla();
            MessageBox.Show("Precios actualizados.", "Ajuste de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Vuelve a la pantalla de Productos.</summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
