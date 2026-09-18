namespace Kiosco
{
    partial class FormReportes
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
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.tabReportes = new System.Windows.Forms.TabControl();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.btnVerTicket = new System.Windows.Forms.Button();
            this.tabEmpleados = new System.Windows.Forms.TabPage();
            this.dgvPorEmpleado = new System.Windows.Forms.DataGridView();
            this.lblTotalSueldos = new System.Windows.Forms.Label();
            this.tabCaja = new System.Windows.Forms.TabPage();
            this.lblEstadoCaja = new System.Windows.Forms.Label();
            this.btnCierreCaja = new System.Windows.Forms.Button();
            this.lblCierres = new System.Windows.Forms.Label();
            this.dgvCierres = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tabReportes.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.tabEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorEmpleado)).BeginInit();
            this.tabCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierres)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 40);
            this.lblTitulo.Text = "Reportes";
            //
            // lblDesde
            //
            this.lblDesde.Location = new System.Drawing.Point(300, 17);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(55, 23);
            this.lblDesde.Text = "Desde:";
            this.lblDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dtpDesde
            //
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(360, 15);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 25);
            //
            // lblHasta
            //
            this.lblHasta.Location = new System.Drawing.Point(490, 17);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(55, 23);
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dtpHasta
            //
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(550, 15);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 25);
            //
            // btnFiltrar
            //
            this.btnFiltrar.Location = new System.Drawing.Point(690, 10);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(110, 34);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            //
            // tabReportes
            //
            this.tabReportes.Controls.Add(this.tabHistorial);
            this.tabReportes.Controls.Add(this.tabEmpleados);
            this.tabReportes.Controls.Add(this.tabCaja);
            this.tabReportes.Location = new System.Drawing.Point(20, 60);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.SelectedIndex = 0;
            this.tabReportes.Size = new System.Drawing.Size(860, 430);
            //
            // tabHistorial
            //
            this.tabHistorial.BackColor = System.Drawing.Color.White;
            this.tabHistorial.Controls.Add(this.dgvVentas);
            this.tabHistorial.Controls.Add(this.lblTotalVentas);
            this.tabHistorial.Controls.Add(this.btnVerTicket);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Text = "Historial de ventas";
            //
            // dgvVentas
            //
            this.dgvVentas.Location = new System.Drawing.Point(10, 10);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(836, 320);
            this.dgvVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellDoubleClick);
            //
            // lblTotalVentas
            //
            this.lblTotalVentas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalVentas.Location = new System.Drawing.Point(10, 345);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(600, 30);
            this.lblTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnVerTicket
            //
            this.btnVerTicket.Location = new System.Drawing.Point(676, 342);
            this.btnVerTicket.Name = "btnVerTicket";
            this.btnVerTicket.Size = new System.Drawing.Size(170, 36);
            this.btnVerTicket.Text = "Ver ticket";
            this.btnVerTicket.Click += new System.EventHandler(this.btnVerTicket_Click);
            //
            // tabEmpleados
            //
            this.tabEmpleados.BackColor = System.Drawing.Color.White;
            this.tabEmpleados.Controls.Add(this.dgvPorEmpleado);
            this.tabEmpleados.Controls.Add(this.lblTotalSueldos);
            this.tabEmpleados.Name = "tabEmpleados";
            this.tabEmpleados.Text = "Ventas y sueldos por empleado";
            //
            // dgvPorEmpleado
            //
            this.dgvPorEmpleado.Location = new System.Drawing.Point(10, 10);
            this.dgvPorEmpleado.Name = "dgvPorEmpleado";
            this.dgvPorEmpleado.Size = new System.Drawing.Size(836, 320);
            //
            // lblTotalSueldos
            //
            this.lblTotalSueldos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalSueldos.Location = new System.Drawing.Point(10, 345);
            this.lblTotalSueldos.Name = "lblTotalSueldos";
            this.lblTotalSueldos.Size = new System.Drawing.Size(836, 30);
            this.lblTotalSueldos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // tabCaja
            //
            this.tabCaja.BackColor = System.Drawing.Color.White;
            this.tabCaja.Controls.Add(this.lblEstadoCaja);
            this.tabCaja.Controls.Add(this.btnCierreCaja);
            this.tabCaja.Controls.Add(this.lblCierres);
            this.tabCaja.Controls.Add(this.dgvCierres);
            this.tabCaja.Name = "tabCaja";
            this.tabCaja.Text = "Cierre de caja";
            //
            // lblEstadoCaja
            //
            this.lblEstadoCaja.Location = new System.Drawing.Point(10, 10);
            this.lblEstadoCaja.Name = "lblEstadoCaja";
            this.lblEstadoCaja.Size = new System.Drawing.Size(600, 105);
            //
            // btnCierreCaja
            //
            this.btnCierreCaja.Location = new System.Drawing.Point(646, 15);
            this.btnCierreCaja.Name = "btnCierreCaja";
            this.btnCierreCaja.Size = new System.Drawing.Size(200, 45);
            this.btnCierreCaja.Text = "Cerrar caja ahora";
            this.btnCierreCaja.Click += new System.EventHandler(this.btnCierreCaja_Click);
            //
            // lblCierres
            //
            this.lblCierres.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCierres.Location = new System.Drawing.Point(10, 122);
            this.lblCierres.Name = "lblCierres";
            this.lblCierres.Size = new System.Drawing.Size(400, 23);
            this.lblCierres.Text = "Historial de cierres:";
            //
            // dgvCierres
            //
            this.dgvCierres.Location = new System.Drawing.Point(10, 148);
            this.dgvCierres.Name = "dgvCierres";
            this.dgvCierres.Size = new System.Drawing.Size(836, 240);
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(730, 500);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // FormReportes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 555);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.tabReportes);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportes";
            this.Text = "Kiosco - Reportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.tabReportes.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.tabEmpleados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorEmpleado)).EndInit();
            this.tabCaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierres)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Button btnVerTicket;
        private System.Windows.Forms.TabPage tabEmpleados;
        private System.Windows.Forms.DataGridView dgvPorEmpleado;
        private System.Windows.Forms.Label lblTotalSueldos;
        private System.Windows.Forms.TabPage tabCaja;
        private System.Windows.Forms.Label lblEstadoCaja;
        private System.Windows.Forms.Button btnCierreCaja;
        private System.Windows.Forms.Label lblCierres;
        private System.Windows.Forms.DataGridView dgvCierres;
        private System.Windows.Forms.Button btnCerrar;
    }
}
