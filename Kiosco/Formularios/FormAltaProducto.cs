namespace Kiosco
{
    /// <summary>
    /// Alta de un producto nuevo o edición de uno existente (el código no se puede modificar).
    /// </summary>
    public partial class FormAltaProducto : Form
    {
        private static readonly string[] CategoriasBase =
            { "Golosinas", "Bebidas", "Snacks", "Cigarrillos", "Lácteos", "Panificados", "Limpieza", "Otros" };

        private readonly Sistema sistema;
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
            Estilo.Aplicar(this);
            CargarCategorias();

            if (productoEditado != null) CargarDatosParaEdicion();
        }

        /// <summary>Carga las categorías base más las que ya usan los productos existentes.</summary>
        private void CargarCategorias()
        {
            IEnumerable<string> categorias = CategoriasBase
                .Concat(sistema.Productos.Select(p => p.Categoria))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(c => c);
            cmbCategoria.Items.AddRange(categorias.Cast<object>().ToArray());
        }

        /// <summary>Completa los campos con los datos del producto que se edita.</summary>
        private void CargarDatosParaEdicion()
        {
            lblTitulo.Text = "Editar producto";
            Text = "Kiosco - Editar producto";
            txtCodigo.Text = productoEditado.Codigo;
            txtCodigo.Enabled = false;
            txtNombre.Text = productoEditado.Nombre;
            cmbCategoria.Text = productoEditado.Categoria;
            txtPrecio.Text = productoEditado.Precio.ToString("0.00");
            txtStock.Text = productoEditado.Stock.ToString();
            txtProveedor.Text = productoEditado.Proveedor;
        }

        /// <summary>Valida los datos y guarda el producto (alta o edición).</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validador.ValidarControles(this, errorProvider)) return;

            decimal.TryParse(txtPrecio.Text, out decimal precio);
            if (precio <= 0)
            {
                errorProvider.SetError(txtPrecio, "El precio debe ser mayor a cero.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                errorProvider.SetError(txtStock, "Stock demasiado grande.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string categoria = cmbCategoria.Text.Trim();
            string proveedor = txtProveedor.Text.Trim();

            if (productoEditado == null)
            {
                Producto nuevo = new Producto(txtCodigo.Text.Trim(), nombre, categoria, precio, stock, proveedor);
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
                productoEditado.Categoria = categoria;
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
