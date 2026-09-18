namespace Kiosco
{
    /// <summary>
    /// Pantalla de venta: se buscan productos, se arma el carrito, se elige el medio de pago
    /// y se confirma la venta (descuenta stock, registra la venta y genera el ticket .txt).
    /// </summary>
    public partial class FormVenta : Form
    {
        private readonly Sistema sistema;
        private readonly Empleado empleado;
        private Venta ventaActual;

        /// <summary>
        /// Crea la pantalla de venta.
        /// </summary>
        public FormVenta(Sistema sistema, Empleado empleado)
        {
            this.sistema = sistema;
            this.empleado = empleado;
            InitializeComponent();
            Estilo.Aplicar(this);
            ConfigurarColumnas();
            ventaActual = new Venta(empleado);
        }

        /// <summary>Define las columnas de las grillas de productos y de carrito.</summary>
        private void ConfigurarColumnas()
        {
            dgvProductos.Columns.Add("Codigo", "Código");
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns["Nombre"].FillWeight = 160;
            dgvProductos.Columns["Stock"].FillWeight = 50;

            dgvCarrito.Columns.Add("Cantidad", "Cant.");
            dgvCarrito.Columns.Add("Producto", "Producto");
            dgvCarrito.Columns.Add("PrecioUnitario", "P. unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");
            dgvCarrito.Columns["Cantidad"].FillWeight = 40;
            dgvCarrito.Columns["Producto"].FillWeight = 150;
        }

        /// <summary>Carga los medios de pago y los productos disponibles.</summary>
        private void FormVenta_Load(object sender, EventArgs e)
        {
            cmbMedioPago.Items.AddRange(new object[] { MedioPago.Efectivo, MedioPago.Tarjeta });
            CargarProductos();
            CargarCarrito();
        }

        /// <summary>Muestra los productos con stock que coinciden con la búsqueda.</summary>
        private void CargarProductos()
        {
            string filtro = txtBuscar.Text.Trim();
            dgvProductos.Rows.Clear();

            IEnumerable<Producto> productos = sistema.Productos.Where(p => p.Stock > 0).OrderBy(p => p.Nombre);
            if (filtro.Length > 0)
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Codigo.Contains(filtro, StringComparison.CurrentCultureIgnoreCase) ||
                    p.Categoria.Contains(filtro, StringComparison.CurrentCultureIgnoreCase));
            }

            foreach (Producto p in productos)
            {
                int fila = dgvProductos.Rows.Add(p.Codigo, p.Nombre, p.Categoria, p.PrecioFinal.ToString("$0.00"), p.Stock);
                dgvProductos.Rows[fila].Tag = p;
                if (p.PorcentajePromocion > 0)
                    dgvProductos.Rows[fila].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
            dgvProductos.ClearSelection();
        }

        /// <summary>Muestra el carrito y el total.</summary>
        private void CargarCarrito()
        {
            dgvCarrito.Rows.Clear();
            foreach (ItemVenta item in ventaActual.Items)
            {
                int fila = dgvCarrito.Rows.Add(item.Cantidad, item.Nombre,
                    item.PrecioUnitario.ToString("$0.00"), item.Subtotal.ToString("$0.00"));
                dgvCarrito.Rows[fila].Tag = item;
            }
            dgvCarrito.ClearSelection();
            lblTotal.Text = $"Total: {ventaActual.Total:$0.00}";
        }

        /// <summary>Filtra los productos mientras se escribe.</summary>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        /// <summary>Doble clic sobre un producto: lo agrega al carrito.</summary>
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AgregarProductoSeleccionado();
        }

        /// <summary>Agrega el producto seleccionado con la cantidad indicada.</summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
        }

        private void AgregarProductoSeleccionado()
        {
            if (dgvProductos.CurrentRow == null || !dgvProductos.CurrentRow.Selected ||
                !(dgvProductos.CurrentRow.Tag is Producto producto))
            {
                MessageBox.Show("Seleccione un producto de la lista.", "Venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ventaActual.AgregarItem(producto, (int)nudCantidad.Value);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nudCantidad.Value = 1;
            CargarCarrito();
        }

        /// <summary>Quita del carrito el ítem seleccionado.</summary>
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null || !dgvCarrito.CurrentRow.Selected ||
                !(dgvCarrito.CurrentRow.Tag is ItemVenta item))
            {
                MessageBox.Show("Seleccione un ítem del carrito.", "Venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ventaActual.QuitarItem(item);
            CargarCarrito();
        }

        /// <summary>Confirma la venta: descuenta stock, la registra y genera el ticket.</summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ventaActual.Items.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Validador.ValidarControles(this, errorProvider)) return;

            MedioPago medio = (MedioPago)cmbMedioPago.SelectedItem;
            DialogResult respuesta = MessageBox.Show(
                $"Total a cobrar: {ventaActual.Total:$0.00}\nMedio de pago: {medio}\n\n¿Confirmar la venta?",
                "Confirmar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                empleado.RealizarVenta(ventaActual, medio, sistema);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo realizar la venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sistema.Guardar();

            string mensaje = $"Venta N° {ventaActual.Numero:000000} registrada por {ventaActual.Total:$0.00}.";
            MessageBoxIcon icono = MessageBoxIcon.Information;
            try
            {
                string ruta = ventaActual.GenerarTicket(Rutas.CarpetaTickets);
                mensaje += $"\n\nTicket generado:\n{ruta}";
            }
            catch (IOException ex)
            {
                mensaje += $"\n\nLa venta se registró, pero no se pudo generar el ticket:\n{ex.Message}";
                icono = MessageBoxIcon.Warning;
            }
            MessageBox.Show(mensaje, "Venta registrada", MessageBoxButtons.OK, icono);

            // Se prepara una venta nueva para el próximo cliente.
            ventaActual = new Venta(empleado);
            cmbMedioPago.SelectedIndex = -1;
            errorProvider.SetError(cmbMedioPago, string.Empty);
            CargarProductos();
            CargarCarrito();
        }

        /// <summary>Vuelve al panel del empleado.</summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>Si quedan ítems sin confirmar, pide confirmación antes de salir.</summary>
        private void FormVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ventaActual.Items.Count == 0) return;

            DialogResult respuesta = MessageBox.Show(
                "Hay productos en el carrito sin confirmar. Si sale se descartarán.\n¿Desea salir?",
                "Venta sin confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) e.Cancel = true;
        }
    }
}
