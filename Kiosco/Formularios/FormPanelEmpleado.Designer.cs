namespace Kiosco
{
    partial class FormPanelEmpleado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.btnMisVentas = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(420, 45);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEstado
            //
            this.lblEstado.Location = new System.Drawing.Point(20, 70);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(380, 70);
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnNuevaVenta
            //
            this.btnNuevaVenta.Location = new System.Drawing.Point(60, 155);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(300, 48);
            this.btnNuevaVenta.Text = "Nueva venta";
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            //
            // btnMisVentas
            //
            this.btnMisVentas.Location = new System.Drawing.Point(60, 213);
            this.btnMisVentas.Name = "btnMisVentas";
            this.btnMisVentas.Size = new System.Drawing.Size(300, 48);
            this.btnMisVentas.Text = "Mis ventas";
            this.btnMisVentas.Click += new System.EventHandler(this.btnMisVentas_Click);
            //
            // btnCaja
            //
            this.btnCaja.Location = new System.Drawing.Point(60, 271);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(300, 48);
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.Location = new System.Drawing.Point(60, 340);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(300, 38);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            //
            // FormPanelEmpleado
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 400);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnNuevaVenta);
            this.Controls.Add(this.btnMisVentas);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnCerrarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPanelEmpleado";
            this.Text = "Kiosco - Panel de Empleado";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Button btnMisVentas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
