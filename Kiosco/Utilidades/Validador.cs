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
        /// <remarks>Los controles sin Tag (o con Tag vacío) no se validan.</remarks>
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
        /// <param name="contenedor">Formulario o panel a limpiar.</param>
        /// <param name="errores">ErrorProvider donde se muestran los errores.</param>
        public static void LimpiarErrores(Control contenedor, ErrorProvider errores)
        {
            foreach (Control control in ObtenerControles(contenedor))
                errores.SetError(control, string.Empty);
        }

        /// <summary>Devuelve el mensaje de error del control, o null si es válido.</summary>
        /// <param name="control">Control a validar.</param>
        /// <param name="tipo">Tipo de validación, tomado del Tag del control.</param>
        /// <returns>El mensaje que se muestra junto al control, o null si el valor es correcto.</returns>
        private static string ObtenerError(Control control, string tipo)
        {
            string texto = control.Text.Trim();

            switch (tipo)
            {
                // "Números": obligatorio y solo dígitos (sin signos ni decimales). Se usa en DNI, código y stock.
                case "Números":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (!texto.All(char.IsDigit)) return "Solo se permiten números enteros.";
                    return null;

                // "Letras": obligatorio; se aceptan letras (con tildes y ñ), espacios, apóstrofe y guion.
                case "Letras":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (!texto.All(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-'))
                        return "Solo se permiten letras.";
                    return null;

                // "Contraseña": obligatoria y de al menos LargoMinimoContrasena caracteres.
                case "Contraseña":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (texto.Length < LargoMinimoContrasena)
                        return $"Debe tener al menos {LargoMinimoContrasena} caracteres.";
                    return null;

                // "Decimal": obligatorio y número no negativo (acepta coma o punto según la configuración regional).
                // Los formularios que necesitan un valor mayor a cero (precio, sueldo) lo controlan aparte.
                case "Decimal":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    if (!decimal.TryParse(texto, out decimal valor) || valor < 0)
                        return "Ingrese un importe válido (número positivo).";
                    return null;

                // "Texto": solo exige que no esté vacío (nombre de producto, categoría).
                case "Texto":
                    if (texto.Length == 0) return "Campo obligatorio.";
                    return null;

                // "Selección": para combos; hay que haber elegido una opción de la lista.
                case "Selección":
                    if (control is ComboBox combo && combo.SelectedIndex < 0)
                        return "Seleccione una opción.";
                    return null;

                // Tag desconocido: no se valida nada.
                default:
                    return null;
            }
        }

        /// <summary>Recorre recursivamente todos los controles hijos.</summary>
        /// <param name="contenedor">Control cuyos descendientes se recorren (no se incluye a sí mismo).</param>
        /// <returns>Todos los controles hijos, nietos, etc.</returns>
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
