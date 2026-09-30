namespace Kiosco
{
    /// <summary>
    /// Alta de un producto nuevo o edición de uno existente (el código no se puede modificar).
    /// El precio de venta no se escribe: se calcula a partir del costo y el margen de ganancia.
    /// </summary>
    public partial class FormAltaProducto : Form
    {
        /// <summary>Categorías sugeridas en el combo. Se les suman las que ya usan los productos cargados.</summary>
        private static readonly string[] CategoriasBase =
            { "Golosinas", "Bebidas", "Snacks", "Cigarrillos", "Lácteos", "Panificados", "Limpieza", "Otros" };
        /// <summary>Unidades de medida sugeridas en el combo. Se les suman las que ya usan los productos cargados.</summary>
        private static readonly string[] UnidadesBase =
            { "Unidad", "g", "kg", "ml", "l", "cc", "Paquete" };

        /// <summary>Sistema con todos los datos (empleados, productos y caja). Se recibe por constructor.</summary>
        private readonly Sistema sistema;
        /// <summary>Producto que se está editando. Es null cuando el formulario se usa para un alta.</summary>
        private readonly Producto productoEditado;

        /// <summary>
        /// Crea el formulario de producto.
        /// </summary>
        /// <param name="sistema">Sistema con la lista de productos.</param>
        /// <param name="productoEditado">Producto a editar, o null para dar de alta uno nuevo.</param>
        public FormAltaProducto(Sistema sistema, Producto productoEditado = null)
        {
            this.sistema = sistema;
            this.productoEditado = productoEditado;
            InitializeComponent();
            Estilo.Aplicar(this, pantallaCompleta: false);
            CargarListas();

            if (productoEditado != null) CargarDatosParaEdicion();
        }

        /// <summary>Carga las categorías, marcas y unidades sugeridas más las que ya usan los productos existentes.</summary>
        private void CargarListas()
        {
            CargarCombo(cmbCategoria, CategoriasBase.Concat(sistema.Productos.Select(p => p.Categoria)));
            CargarCombo(cmbMarca, sistema.Productos.Select(p => p.Marca));
            CargarCombo(cmbUnidad, UnidadesBase.Concat(sistema.Productos.Select(p => p.UnidadMedida)));
        }

        /// <summary>Carga en el combo los valores no vacíos, sin repetir (sin distinguir mayúsculas y minúsculas) y ordenados.</summary>
        /// <param name="combo">Combo editable a completar.</param>
        /// <param name="valores">Valores sugeridos.</param>
        private static void CargarCombo(ComboBox combo, IEnumerable<string> valores)
        {
            combo.Items.AddRange(valores
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Distinct(StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(v => v)
                .Cast<object>().ToArray());
        }

        /// <summary>
        /// Recalcula el precio de venta cada vez que cambia el costo o el margen de ganancia.
        /// Si alguno de los dos todavía no es un número válido, el precio queda vacío.
        /// </summary>
        private void CalculoPrecio_Changed(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCosto.Text, out decimal costo) && costo >= 0 &&
                decimal.TryParse(txtMargen.Text, out decimal margen) && margen >= 0)
                txtPrecio.Text = Producto.CalcularPrecio(costo, margen).ToString("0.00");
            else
                txtPrecio.Text = string.Empty;
        }

        /// <summary>Completa los campos con los datos del producto que se edita.</summary>
        private void CargarDatosParaEdicion()
        {
            lblTitulo.Text = "Editar producto";
            Text = "Kiosco - Editar producto";
            txtCodigo.Text = productoEditado.Codigo;
            txtCodigo.Enabled = false;
            txtDescripcion.Text = productoEditado.Nombre;
            cmbMarca.Text = productoEditado.Marca;
            cmbCategoria.Text = productoEditado.Categoria;
            cmbUnidad.Text = productoEditado.UnidadMedida;
            // Los productos cargados antes de existir el costo tienen Costo = 0: se dejan vacíos costo y margen
            // (hay que completarlos al guardar) y se muestra el precio que tenían.
            if (productoEditado.Costo > 0)
            {
                txtCosto.Text = productoEditado.Costo.ToString("0.00");
                txtMargen.Text = productoEditado.MargenGanancia.ToString("0.##");
            }
            txtPrecio.Text = productoEditado.Precio.ToString("0.00");
            txtStock.Text = productoEditado.Stock.ToString();
            txtProveedor.Text = productoEditado.Proveedor;
        }

        /// <summary>Valida los datos y guarda el producto (alta o edición).</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validador.ValidarControles(this, errorProvider)) return;

            decimal.TryParse(txtCosto.Text, out decimal costo);
            if (costo <= 0)
            {
                errorProvider.SetError(txtCosto, "El costo debe ser mayor a cero.");
                return;
            }
            decimal.TryParse(txtMargen.Text, out decimal margen);
            decimal precio = Producto.CalcularPrecio(costo, margen);

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                errorProvider.SetError(txtStock, "Stock demasiado grande.");
                return;
            }

            string nombre = txtDescripcion.Text.Trim();
            string marca = cmbMarca.Text.Trim();
            string categoria = cmbCategoria.Text.Trim();
            string unidad = cmbUnidad.Text.Trim();
            string proveedor = txtProveedor.Text.Trim();

            if (productoEditado == null)
            {
                Producto nuevo = new Producto(txtCodigo.Text.Trim(), nombre, categoria, precio, stock, proveedor)
                {
                    Marca = marca,
                    UnidadMedida = unidad,
                    Costo = costo,
                    MargenGanancia = margen
                };
                if (!sistema.Administrador.AltaProducto(sistema, nuevo))
                {
                    errorProvider.SetError(txtCodigo, "Ya existe un producto con ese código.");
                    MessageBox.Show("Ya existe un producto con ese código.", "Producto duplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                productoEditado.Nombre = nombre;
                productoEditado.Marca = marca;
                productoEditado.Categoria = categoria;
                productoEditado.UnidadMedida = unidad;
                productoEditado.Costo = costo;
                productoEditado.MargenGanancia = margen;
                productoEditado.Precio = precio;
                productoEditado.Stock = stock;
                productoEditado.Proveedor = proveedor;
            }

            sistema.Guardar();
            MessageBox.Show(productoEditado == null ? "Producto registrado correctamente." : "Producto actualizado.",
                "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        /// <summary>Cierra el formulario sin guardar.</summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
