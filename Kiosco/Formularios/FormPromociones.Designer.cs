// ============================================================================
// FormPromociones.Designer.cs
// Parte "diseño" del formulario FormPromociones: promociones por producto y ajuste de precio por marca.
//
// Este archivo lo genera y mantiene el Diseñador de Windows Forms de Visual Studio:
// define qué controles tiene la pantalla (posición, tamaño, texto y eventos).
// Si se edita el formulario con el Diseñador, Visual Studio lo reescribe, por eso
// no se comentan los controles uno por uno. Los nombres siguen un prefijo por tipo:
// lbl = Label, txt = TextBox, cmb = ComboBox, btn = Button, dgv = DataGridView,
// nud = NumericUpDown, dtp = DateTimePicker, rb = RadioButton, pic = PictureBox.
// La lógica (eventos, validaciones y acceso a los datos) está en FormPromociones.cs.
// ============================================================================

namespace Kiosco
{
    partial class FormPromociones
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.grpPromocion = new System.Windows.Forms.GroupBox();
            this.lblPromo = new System.Windows.Forms.Label();
            this.nudPromocion = new System.Windows.Forms.NumericUpDown();
            this.btnAplicarPromocion = new System.Windows.Forms.Button();
            this.btnQuitarPromociones = new System.Windows.Forms.Button();
            this.grpMarca = new System.Windows.Forms.GroupBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblAjuste = new System.Windows.Forms.Label();
            this.nudAjuste = new System.Windows.Forms.NumericUpDown();
            this.btnAplicarAjuste = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPromocion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAjuste)).BeginInit();
            this.grpPromocion.SuspendLayout();
            this.grpMarca.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 40);
            this.lblTitulo.Text = "Precios y promociones";
            //
            // lblBuscar
            //
            this.lblBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblBuscar.Location = new System.Drawing.Point(560, 20);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(70, 23);
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtBuscar
            //
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Location = new System.Drawing.Point(636, 20);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(244, 25);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // dgvProductos
            //
            this.dgvProductos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProductos.Location = new System.Drawing.Point(20, 60);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(560, 420);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            //
            // grpPromocion
            //
            this.grpPromocion.Controls.Add(this.lblPromo);
            this.grpPromocion.Controls.Add(this.nudPromocion);
            this.grpPromocion.Controls.Add(this.btnAplicarPromocion);
            this.grpPromocion.Controls.Add(this.btnQuitarPromociones);
            this.grpPromocion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.grpPromocion.Location = new System.Drawing.Point(600, 60);
            this.grpPromocion.Name = "grpPromocion";
            this.grpPromocion.Size = new System.Drawing.Size(280, 190);
            this.grpPromocion.Text = "Promoción del producto seleccionado";
            //
            // lblPromo
            //
            this.lblPromo.Location = new System.Drawing.Point(15, 32);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(160, 23);
            this.lblPromo.Text = "Descuento (%):";
            //
            // nudPromocion
            //
            this.nudPromocion.Location = new System.Drawing.Point(180, 30);
            this.nudPromocion.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            this.nudPromocion.Name = "nudPromocion";
            this.nudPromocion.Size = new System.Drawing.Size(80, 25);
            //
            // btnAplicarPromocion
            //
            this.btnAplicarPromocion.Location = new System.Drawing.Point(15, 75);
            this.btnAplicarPromocion.Name = "btnAplicarPromocion";
            this.btnAplicarPromocion.Size = new System.Drawing.Size(245, 40);
            this.btnAplicarPromocion.Text = "Aplicar promoción";
            this.btnAplicarPromocion.Click += new System.EventHandler(this.btnAplicarPromocion_Click);
            //
            // btnQuitarPromociones
            //
            this.btnQuitarPromociones.Location = new System.Drawing.Point(15, 125);
            this.btnQuitarPromociones.Name = "btnQuitarPromociones";
            this.btnQuitarPromociones.Size = new System.Drawing.Size(245, 40);
            this.btnQuitarPromociones.Text = "Quitar todas las promociones";
            this.btnQuitarPromociones.Click += new System.EventHandler(this.btnQuitarPromociones_Click);
            //
            // grpMarca
            //
            this.grpMarca.Controls.Add(this.lblMarca);
            this.grpMarca.Controls.Add(this.cmbMarca);
            this.grpMarca.Controls.Add(this.lblAjuste);
            this.grpMarca.Controls.Add(this.nudAjuste);
            this.grpMarca.Controls.Add(this.btnAplicarAjuste);
            this.grpMarca.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.grpMarca.Location = new System.Drawing.Point(600, 265);
            this.grpMarca.Name = "grpMarca";
            this.grpMarca.Size = new System.Drawing.Size(280, 165);
            this.grpMarca.Text = "Ajuste de precio por Marca";
            //
            // lblMarca
            //
            this.lblMarca.Location = new System.Drawing.Point(15, 30);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(80, 23);
            this.lblMarca.Text = "Marca:";
            //
            // cmbMarca
            //
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Location = new System.Drawing.Point(100, 27);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(160, 25);
            //
            // lblAjuste
            //
            this.lblAjuste.Location = new System.Drawing.Point(15, 65);
            this.lblAjuste.Name = "lblAjuste";
            this.lblAjuste.Size = new System.Drawing.Size(160, 23);
            this.lblAjuste.Text = "Ajuste (%, ± ):";
            //
            // nudAjuste
            //
            this.nudAjuste.Location = new System.Drawing.Point(180, 63);
            this.nudAjuste.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.nudAjuste.Minimum = new decimal(new int[] { 50, 0, 0, -2147483648 });
            this.nudAjuste.Name = "nudAjuste";
            this.nudAjuste.Size = new System.Drawing.Size(80, 25);
            //
            // btnAplicarAjuste
            //
            this.btnAplicarAjuste.Location = new System.Drawing.Point(15, 105);
            this.btnAplicarAjuste.Name = "btnAplicarAjuste";
            this.btnAplicarAjuste.Size = new System.Drawing.Size(245, 40);
            this.btnAplicarAjuste.Text = "Aplicar ajuste a la Marca";
            this.btnAplicarAjuste.Click += new System.EventHandler(this.btnAplicarAjuste_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Location = new System.Drawing.Point(730, 440);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // FormPromociones
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.grpPromocion);
            this.Controls.Add(this.grpMarca);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPromociones";
            this.Text = "Kiosco - Precios y promociones";
            this.Load += new System.EventHandler(this.FormPromociones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPromocion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAjuste)).EndInit();
            this.grpPromocion.ResumeLayout(false);
            this.grpMarca.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox grpPromocion;
        private System.Windows.Forms.Label lblPromo;
        private System.Windows.Forms.NumericUpDown nudPromocion;
        private System.Windows.Forms.Button btnAplicarPromocion;
        private System.Windows.Forms.Button btnQuitarPromociones;
        private System.Windows.Forms.GroupBox grpMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lblAjuste;
        private System.Windows.Forms.NumericUpDown nudAjuste;
        private System.Windows.Forms.Button btnAplicarAjuste;
        private System.Windows.Forms.Button btnCerrar;
    }
}
