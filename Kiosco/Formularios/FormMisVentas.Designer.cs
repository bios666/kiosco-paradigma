// ============================================================================
// FormMisVentas.Designer.cs
// Parte "diseño" del formulario FormMisVentas: historial de ventas del empleado (del día o del turno).
//
// Este archivo lo genera y mantiene el Diseñador de Windows Forms de Visual Studio:
// define qué controles tiene la pantalla (posición, tamaño, texto y eventos).
// Si se edita el formulario con el Diseñador, Visual Studio lo reescribe, por eso
// no se comentan los controles uno por uno. Los nombres siguen un prefijo por tipo:
// lbl = Label, txt = TextBox, cmb = ComboBox, btn = Button, dgv = DataGridView,
// nud = NumericUpDown, dtp = DateTimePicker, rb = RadioButton, pic = PictureBox.
// La lógica (eventos, validaciones y acceso a los datos) está en FormMisVentas.cs.
// ============================================================================

namespace Kiosco
{
    partial class FormMisVentas
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
            this.rbDia = new System.Windows.Forms.RadioButton();
            this.rbTurno = new System.Windows.Forms.RadioButton();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnVerTicket = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 40);
            this.lblTitulo.Text = "Mis ventas";
            //
            // rbDia
            //
            this.rbDia.Checked = true;
            this.rbDia.Location = new System.Drawing.Point(340, 18);
            this.rbDia.Name = "rbDia";
            this.rbDia.Size = new System.Drawing.Size(140, 27);
            this.rbDia.TabStop = true;
            this.rbDia.Text = "Del día de hoy";
            this.rbDia.CheckedChanged += new System.EventHandler(this.rbFiltro_CheckedChanged);
            //
            // rbTurno
            //
            this.rbTurno.Location = new System.Drawing.Point(490, 18);
            this.rbTurno.Name = "rbTurno";
            this.rbTurno.Size = new System.Drawing.Size(170, 27);
            this.rbTurno.Text = "Del turno (caja actual)";
            this.rbTurno.CheckedChanged += new System.EventHandler(this.rbFiltro_CheckedChanged);
            //
            // dgvVentas
            //
            this.dgvVentas.Location = new System.Drawing.Point(20, 60);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(640, 300);
            this.dgvVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellDoubleClick);
            //
            // lblTotal
            //
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 372);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(640, 30);
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnVerTicket
            //
            this.btnVerTicket.Location = new System.Drawing.Point(20, 415);
            this.btnVerTicket.Name = "btnVerTicket";
            this.btnVerTicket.Size = new System.Drawing.Size(170, 40);
            this.btnVerTicket.Text = "Ver ticket";
            this.btnVerTicket.Click += new System.EventHandler(this.btnVerTicket_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(510, 415);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // FormMisVentas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(680, 475);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.rbDia);
            this.Controls.Add(this.rbTurno);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnVerTicket);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMisVentas";
            this.Text = "Kiosco - Mis ventas";
            this.Load += new System.EventHandler(this.FormMisVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.RadioButton rbDia;
        private System.Windows.Forms.RadioButton rbTurno;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnVerTicket;
        private System.Windows.Forms.Button btnCerrar;
    }
}
