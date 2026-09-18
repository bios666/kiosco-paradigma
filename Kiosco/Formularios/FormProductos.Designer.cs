// ============================================================================
// FormProductos.Designer.cs
// Parte "diseño" del formulario FormProductos: listado de productos con búsqueda, alta, edición y baja.
//
// Este archivo lo genera y mantiene el Diseñador de Windows Forms de Visual Studio:
// define qué controles tiene la pantalla (posición, tamaño, texto y eventos).
// Si se edita el formulario con el Diseñador, Visual Studio lo reescribe, por eso
// no se comentan los controles uno por uno. Los nombres siguen un prefijo por tipo:
// lbl = Label, txt = TextBox, cmb = ComboBox, btn = Button, dgv = DataGridView,
// nud = NumericUpDown, dtp = DateTimePicker, rb = RadioButton, pic = PictureBox.
// La lógica (eventos, validaciones y acceso a los datos) está en FormProductos.cs.
// ============================================================================

namespace Kiosco
{
    partial class FormProductos
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
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.Text = "Productos";
            //
            // lblBuscar
            //
            this.lblBuscar.Location = new System.Drawing.Point(560, 20);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(70, 23);
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtBuscar
            //
            this.txtBuscar.Location = new System.Drawing.Point(636, 20);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(244, 25);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // dgvProductos
            //
            this.dgvProductos.Location = new System.Drawing.Point(20, 60);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(860, 360);
            //
            // lblAviso
            //
            this.lblAviso.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAviso.Location = new System.Drawing.Point(20, 425);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(860, 23);
            this.lblAviso.Text = "Las filas en rojo tienen stock bajo (5 unidades o menos).";
            //
            // btnAlta
            //
            this.btnAlta.Location = new System.Drawing.Point(20, 455);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(150, 40);
            this.btnAlta.Text = "Nuevo producto";
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            //
            // btnEditar
            //
            this.btnEditar.Location = new System.Drawing.Point(180, 455);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 40);
            this.btnEditar.Text = "Editar / stock";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            //
            // btnBaja
            //
            this.btnBaja.Location = new System.Drawing.Point(340, 455);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(150, 40);
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(730, 455);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // FormProductos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 515);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProductos";
            this.Text = "Kiosco - Productos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnCerrar;
    }
}
