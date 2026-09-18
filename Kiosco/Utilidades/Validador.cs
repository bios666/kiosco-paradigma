namespace Kiosco
{
    /// <summary>
    /// Validaciones de campos centralizadas. El tipo de validación de cada control se indica
    /// en su propiedad Tag: "Números", "Letras", "Contraseña", "Decimal", "Texto" o "Selección".
    /// Los errores se muestran con un ErrorProvider.
    /// </summary>
    public static class Validador
    {
        /// <summary>Largo mínimo aceptado para una contraseña.</summary>
        public const int LargoMinimoContrasena = 4;

        /// <summary>
        /// Valida todos los controles (con Tag) de un contenedor.
        /// </summary>
        /// <param name="contenedor">Formulario o panel a validar.</param>
        /// <param name="errores">ErrorProvider donde se muestran los errores.</param>
        /// <returns>true si todos los campos son válidos.</returns>
        public static bool ValidarControles(Control contenedor, ErrorProvider errores)
        {
            bool todoOk = true;
            foreach (Control control in ObtenerControles(contenedor))
            {
                string tipo = control.Tag as string;
                if (string.IsNullOrEmpty(tipo)) continue;

                string error = ObtenerError(control, tipo);
                errores.SetError(control, error ?? string.Empty);
                if (error != null) todoOk = false;
            }
            return todoOk;
        }

        /// <summary>Quita todos los errores mostrados en un contenedor.</summary>
        public static void LimpiarErrores(Control contenedor, ErrorProvider errores)
        {
            foreach (Control control in ObtenerControles(contenedor))
                errores.SetError(control, string.Empty);
        }

        /// <summary>Devuelve el mensaje de error del control, o null si es válido.</summary>
        private static string ObtenerError(Control control, string tipo)
        {
            string texto = control.Text.Trim();

            switch (tipo)
            {
                case "Números":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (!texto.All(char.IsDigit)) return "Solo se permiten números enteros.";
                    return null;

                case "Letras":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (!texto.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-'))
                        return "Solo se permiten letras.";
                    return null;

                case "Contraseña":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (texto.Length < LargoMinimoContrasena)
                        return $"Debe tener al menos {LargoMinimoContrasena} caracteres.";
                    return null;

                case "Decimal":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (!decimal.TryParse(texto, out decimal valor) || valor < 0)
                        return "Ingrese un importe válido (número positivo).";
                    return null;

                case "Texto":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    return null;

                case "Selección":
                    if (control is ComboBox combo && combo.SelectedIndex < 0)
                        return "Seleccione una opción.";
                    return null;

                default:
                    return null;
            }
        }

        /// <summary>Recorre recursivamente todos los controles hijos.</summary>
        private static IEnumerable<Control> ObtenerControles(Control contenedor)
        {
            foreach (Control hijo in contenedor.Controls)
            {
                yield return hijo;
                foreach (Control nieto in ObtenerControles(hijo))
                    yield return nieto;
            }
        }
    }
}
