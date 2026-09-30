// ============================================================================
// FormAltaProducto.Designer.cs
// Parte "diseño" del formulario FormAltaProducto: alta y edición de productos.
//
// Este archivo lo genera y mantiene el Diseñador de Windows Forms de Visual Studio:
// define qué controles tiene la pantalla (posición, tamaño, texto y eventos).
// Si se edita el formulario con el Diseñador, Visual Studio lo reescribe, por eso
// no se comentan los controles uno por uno. Los nombres siguen un prefijo por tipo:
// lbl = Label, txt = TextBox, cmb = ComboBox, btn = Button, dgv = DataGridView,
// nud = NumericUpDown, dtp = DateTimePicker, rb = RadioButton, pic = PictureBox.
// La lógica (eventos, validaciones y acceso a los datos) está en FormAltaProducto.cs.
// ============================================================================

namespace Kiosco
{
    partial class FormAltaProducto
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Libera los recursos que usa el formulario.
        /// </summary>
        /// <param name="disposing">true si se deben liberar también los recursos administrados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Crea y configura los controles del formulario. No editar a mano: lo regenera el Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblMargen = new System.Windows.Forms.Label();
            this.txtMargen = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(420, 40);
            this.lblTitulo.Text = "Alta de producto";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblCodigo
            //
            this.lblCodigo.Location = new System.Drawing.Point(30, 70);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(170, 23);
            this.lblCodigo.Text = "Código:";
            //
            // txtCodigo
            //
            this.txtCodigo.Location = new System.Drawing.Point(205, 67);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Tag = "Números";
            this.txtCodigo.Size = new System.Drawing.Size(185, 25);
            //
            // lblDescripcion
            //
            this.lblDescripcion.Location = new System.Drawing.Point(30, 110);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(170, 23);
            this.lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            this.txtDescripcion.Location = new System.Drawing.Point(205, 107);
            this.txtDescripcion.MaxLength = 40;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Tag = "Texto";
            this.txtDescripcion.Size = new System.Drawing.Size(185, 25);
            //
            // lblMarca
            //
            this.lblMarca.Location = new System.Drawing.Point(30, 150);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(170, 23);
            this.lblMarca.Text = "Marca:";
            //
            // cmbMarca
            //
            this.cmbMarca.Location = new System.Drawing.Point(205, 147);
            this.cmbMarca.MaxLength = 30;
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Tag = "Texto";
            this.cmbMarca.Size = new System.Drawing.Size(185, 25);
            //
            // lblCategoria
            //
            this.lblCategoria.Location = new System.Drawing.Point(30, 190);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(170, 23);
            this.lblCategoria.Text = "Categoría:";
            //
            // cmbCategoria
            //
            this.cmbCategoria.Location = new System.Drawing.Point(205, 187);
            this.cmbCategoria.MaxLength = 30;
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Tag = "Texto";
            this.cmbCategoria.Size = new System.Drawing.Size(185, 25);
            //
            // lblUnidad
            //
            this.lblUnidad.Location = new System.Drawing.Point(30, 230);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(170, 23);
            this.lblUnidad.Text = "Unidad de medida:";
            //
            // cmbUnidad
            //
            this.cmbUnidad.Location = new System.Drawing.Point(205, 227);
            this.cmbUnidad.MaxLength = 15;
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Tag = "Texto";
            this.cmbUnidad.Size = new System.Drawing.Size(185, 25);
            //
            // lblCosto
            //
            this.lblCosto.Location = new System.Drawing.Point(30, 270);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(170, 23);
            this.lblCosto.Text = "Costo ($):";
            //
            // txtCosto
            //
            this.txtCosto.Location = new System.Drawing.Point(205, 267);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Tag = "Decimal";
            this.txtCosto.Size = new System.Drawing.Size(185, 25);
            this.txtCosto.TextChanged += new System.EventHandler(this.CalculoPrecio_Changed);
            //
            // lblMargen
            //
            this.lblMargen.Location = new System.Drawing.Point(30, 310);
            this.lblMargen.Name = "lblMargen";
            this.lblMargen.Size = new System.Drawing.Size(170, 23);
            this.lblMargen.Text = "Margen de ganancia (%):";
            //
            // txtMargen
            //
            this.txtMargen.Location = new System.Drawing.Point(205, 307);
            this.txtMargen.Name = "txtMargen";
            this.txtMargen.Tag = "Decimal";
            this.txtMargen.Size = new System.Drawing.Size(185, 25);
            this.txtMargen.TextChanged += new System.EventHandler(this.CalculoPrecio_Changed);
            //
            // lblPrecio
            //
            this.lblPrecio.Location = new System.Drawing.Point(30, 350);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(170, 23);
            this.lblPrecio.Text = "Precio de venta ($):";
            //
            // txtPrecio
            //
            this.txtPrecio.Location = new System.Drawing.Point(205, 347);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.TabStop = false;
            this.txtPrecio.Size = new System.Drawing.Size(185, 25);
            //
            // lblStock
            //
            this.lblStock.Location = new System.Drawing.Point(30, 390);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(170, 23);
            this.lblStock.Text = "Stock:";
            //
            // txtStock
            //
            this.txtStock.Location = new System.Drawing.Point(205, 387);
            this.txtStock.MaxLength = 6;
            this.txtStock.Name = "txtStock";
            this.txtStock.Tag = "Números";
            this.txtStock.Size = new System.Drawing.Size(185, 25);
            //
            // lblProveedor
            //
            this.lblProveedor.Location = new System.Drawing.Point(30, 430);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(170, 23);
            this.lblProveedor.Text = "Proveedor (opcional):";
            //
            // txtProveedor
            //
            this.txtProveedor.Location = new System.Drawing.Point(205, 427);
            this.txtProveedor.MaxLength = 40;
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(185, 25);
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(30, 480);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(175, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(215, 480);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(175, 40);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // errorProvider
            //
            this.errorProvider.ContainerControl = this;
            //
            // FormAltaProducto
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(420, 545);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.cmbUnidad);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblMargen);
            this.Controls.Add(this.txtMargen);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAltaProducto";
            this.Text = "Kiosco - Producto";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblMargen;
        private System.Windows.Forms.TextBox txtMargen;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
