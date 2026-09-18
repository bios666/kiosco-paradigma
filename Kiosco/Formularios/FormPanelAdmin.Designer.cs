namespace Kiosco
{
    partial class FormPanelAdmin
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
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnPromociones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(420, 45);
            this.lblTitulo.Text = "Panel de Administrador";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblResumen
            //
            this.lblResumen.Location = new System.Drawing.Point(20, 70);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(380, 45);
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnEmpleados
            //
            this.btnEmpleados.Location = new System.Drawing.Point(60, 130);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(300, 45);
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            //
            // btnProductos
            //
            this.btnProductos.Location = new System.Drawing.Point(60, 185);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(300, 45);
            this.btnProductos.Text = "Productos";
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            //
            // btnPromociones
            //
            this.btnPromociones.Location = new System.Drawing.Point(60, 240);
            this.btnPromociones.Name = "btnPromociones";
            this.btnPromociones.Size = new System.Drawing.Size(300, 45);
            this.btnPromociones.Text = "Precios y promociones";
            this.btnPromociones.Click += new System.EventHandler(this.btnPromociones_Click);
            //
            // btnReportes
            //
            this.btnReportes.Location = new System.Drawing.Point(60, 295);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(300, 45);
            this.btnReportes.Text = "Reportes y cierre de caja";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.Location = new System.Drawing.Point(60, 360);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(300, 38);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            //
            // FormPanelAdmin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 420);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnPromociones);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnCerrarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPanelAdmin";
            this.Text = "Kiosco - Panel de Administrador";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnPromociones;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
