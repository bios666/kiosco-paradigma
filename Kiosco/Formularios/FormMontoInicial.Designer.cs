// ============================================================================
// FormMontoInicial.Designer.cs
// Parte "diseño" del formulario FormMontoInicial: diálogo que pide el monto inicial al abrir la caja.
//
// Este archivo lo genera y mantiene el Diseñador de Windows Forms de Visual Studio:
// define qué controles tiene la pantalla (posición, tamaño, texto y eventos).
// Si se edita el formulario con el Diseñador, Visual Studio lo reescribe, por eso
// no se comentan los controles uno por uno. Los nombres siguen un prefijo por tipo:
// lbl = Label, txt = TextBox, cmb = ComboBox, btn = Button, dgv = DataGridView,
// nud = NumericUpDown, dtp = DateTimePicker, rb = RadioButton, pic = PictureBox.
// La lógica (eventos, validaciones y acceso a los datos) está en FormMontoInicial.cs.
// ============================================================================

namespace Kiosco
{
    partial class FormMontoInicial
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
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            //
            // lblMonto
            //
            this.lblMonto.Location = new System.Drawing.Point(25, 20);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(290, 45);
            this.lblMonto.Text = "Monto inicial de la caja ($):";
            //
            // txtMonto
            //
            this.txtMonto.Location = new System.Drawing.Point(25, 68);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(290, 25);
            this.txtMonto.Tag = "Decimal";
            this.txtMonto.Text = "0";
            //
            // btnAceptar
            //
            this.btnAceptar.Location = new System.Drawing.Point(25, 115);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(140, 38);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(175, 115);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 38);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // errorProvider
            //
            this.errorProvider.ContainerControl = this;
            //
            // FormMontoInicial
            //
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(340, 175);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMontoInicial";
            this.Text = "Abrir caja";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
