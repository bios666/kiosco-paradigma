// ============================================================================
// FormAltaEmpleado.Designer.cs
// Parte "diseño" del formulario FormAltaEmpleado: alta de un empleado nuevo.
//
// Este archivo lo genera y mantiene el Diseñador de Windows Forms de Visual Studio:
// define qué controles tiene la pantalla (posición, tamaño, texto y eventos).
// Si se edita el formulario con el Diseñador, Visual Studio lo reescribe, por eso
// no se comentan los controles uno por uno. Los nombres siguen un prefijo por tipo:
// lbl = Label, txt = TextBox, cmb = ComboBox, btn = Button, dgv = DataGridView,
// nud = NumericUpDown, dtp = DateTimePicker, rb = RadioButton, pic = PictureBox.
// La lógica (eventos, validaciones y acceso a los datos) está en FormAltaEmpleado.cs.
// ============================================================================

namespace Kiosco
{
    partial class FormAltaEmpleado
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
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblSueldo = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
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
            this.lblTitulo.Text = "Alta de empleado";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblNombres
            //
            this.lblNombres.Location = new System.Drawing.Point(30, 70);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(130, 23);
            this.lblNombres.Text = "Nombres:";
            //
            // txtNombres
            //
            this.txtNombres.Location = new System.Drawing.Point(170, 67);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(220, 25);
            this.txtNombres.Tag = "Letras";
            //
            // lblApellidos
            //
            this.lblApellidos.Location = new System.Drawing.Point(30, 110);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(130, 23);
            this.lblApellidos.Text = "Apellidos:";
            //
            // txtApellidos
            //
            this.txtApellidos.Location = new System.Drawing.Point(170, 107);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(220, 25);
            this.txtApellidos.Tag = "Letras";
            //
            // lblDni
            //
            this.lblDni.Location = new System.Drawing.Point(30, 150);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(130, 23);
            this.lblDni.Text = "DNI:";
            //
            // txtDni
            //
            this.txtDni.Location = new System.Drawing.Point(170, 147);
            this.txtDni.MaxLength = 8;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(220, 25);
            this.txtDni.Tag = "Números";
            //
            // lblFechaNacimiento
            //
            this.lblFechaNacimiento.Location = new System.Drawing.Point(30, 190);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(140, 23);
            this.lblFechaNacimiento.Text = "Fecha de nacimiento:";
            //
            // cmbDia
            //
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.Location = new System.Drawing.Point(170, 187);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(55, 25);
            this.cmbDia.Tag = "Selección";
            //
            // cmbMes
            //
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Location = new System.Drawing.Point(232, 187);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(85, 25);
            this.cmbMes.Tag = "Selección";
            //
            // cmbAnio
            //
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.Location = new System.Drawing.Point(324, 187);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(66, 25);
            this.cmbAnio.Tag = "Selección";
            //
            // lblContrasena
            //
            this.lblContrasena.Location = new System.Drawing.Point(30, 230);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(130, 23);
            this.lblContrasena.Text = "Contraseña:";
            //
            // txtContrasena
            //
            this.txtContrasena.Location = new System.Drawing.Point(170, 227);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(220, 25);
            this.txtContrasena.Tag = "Contraseña";
            //
            // lblSueldo
            //
            this.lblSueldo.Location = new System.Drawing.Point(30, 270);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new System.Drawing.Size(130, 23);
            this.lblSueldo.Text = "Sueldo por día ($):";
            //
            // txtSueldo
            //
            this.txtSueldo.Location = new System.Drawing.Point(170, 267);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new System.Drawing.Size(220, 25);
            this.txtSueldo.Tag = "Decimal";
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(30, 320);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(175, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(215, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(175, 40);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // errorProvider
            //
            this.errorProvider.ContainerControl = this;
            //
            // FormAltaEmpleado
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(420, 385);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblApellidos);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.cmbDia);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblSueldo);
            this.Controls.Add(this.txtSueldo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAltaEmpleado";
            this.Text = "Kiosco - Alta de empleado";
            this.Load += new System.EventHandler(this.FormAltaEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblSueldo;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
