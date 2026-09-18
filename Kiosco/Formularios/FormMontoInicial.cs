namespace Kiosco
{
    /// <summary>
    /// Pequeño diálogo que pide el monto inicial con el que se abre la caja.
    /// </summary>
    public partial class FormMontoInicial : Form
    {
        /// <summary>Monto ingresado (válido cuando el resultado es OK).</summary>
        public decimal Monto { get; private set; }

        /// <summary>
        /// Crea el diálogo de monto inicial.
        /// </summary>
        public FormMontoInicial()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
        }

        /// <summary>Valida el monto y cierra con resultado OK.</summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validador.ValidarControles(this, errorProvider)) return;

            Monto = decimal.Parse(txtMonto.Text);
            DialogResult = DialogResult.OK;
        }

        /// <summary>Cancela la apertura de caja.</summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
