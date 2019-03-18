using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPresentacion;

using System.Windows.Forms;
using System.Globalization;
using MaterialSkin.Controls;

namespace CapaPresentacion.Validacion
{
    public class Validacion
    {

        #region INSTANCIACION

        private static Validacion _Instancia;

        public static Validacion Instancia
        {
            get
            {
                return _Instancia;
            }

            set
            {
                _Instancia = value;
            }
        }

        public static Validacion GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Validacion();
            }
            return Instancia;
        }

        public void Dispose()
        {
            Instancia = null;
        }

        #endregion

        #region DESACTIVACIÓN DE TECLAS Y COMBINACIONES DE TECLAS

        public void Desactivar(KeyEventArgs kea)
        {
            DesactivarCopiadoPegado(kea);
            DesactivarTeclasDireccionales(kea);
            DesactivarTeclasEdicion(kea);
        }

        public void DesactivarTeclasDireccionales(KeyEventArgs e)
        {
            if ((e.KeyCode.Equals(Keys.Left)) || (e.KeyCode.Equals(Keys.Right)) || (e.KeyCode.Equals(Keys.Up)) || (e.KeyCode.Equals(Keys.Down)))
            {
                e.Handled = true;
            }
        }

        public void DesactivarTeclasEdicion(KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Shift))
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.Home))
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.End))
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.Insert))
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.Delete))
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.PageUp))
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.PageDown))
            {
                e.Handled = true;
            }
        }

        public void DesactivarCopiadoPegado(KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region SOLO TEXTO
        public void IngresarTexto(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region SOLO NUMEROS ENTEROS
        public void IngresarNumeroEntero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region SOLO NUMEROS DECIMALES
        public void IngresarNumeroDecimal(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region FORMATEO DE DECIMALES EN TIEMPO REAL

        CultureInfo miCultureConfig = new CultureInfo("en");
        bool finalDeCampo = false;
        int enDecimal = -1;
        char ultimoCaracterPresionado;

        public void LimpiarVariablesDeFormateoDecimal()
        {
            finalDeCampo = false;
            enDecimal = -1;
        }
        public bool ValidarDecimal(object sender, KeyPressEventArgs e)
        {
            bool ok = true;
            ultimoCaracterPresionado = e.KeyChar;
            TextBox control = (TextBox)sender;
            control.MaxLength = 19;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                ok = false;
            }
            else if ((e.KeyChar == '.' && control.Text == string.Empty) || (e.KeyChar == '.') && (control.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                //enDecimal = 1;
                switch (enDecimal)
                {
                    case -1:
                        enDecimal = 1;
                        break;
                    default:
                        enDecimal++;
                        break;
                }
                control.Select(control.Text.IndexOf('.') + 1, 1);
                ok = false;
            }
            else if (finalDeCampo && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                ok = false;
            }
            else if (finalDeCampo && e.KeyChar == (char)Keys.Back)
            {
                //if (enDecimal == 3)
                //{
                //    enDecimal = 2;
                //}
                //else if (enDecimal == 2)
                //{
                //    enDecimal = 1;
                //}
                ////enDecimal = 1;
                ////enDecimal--;
                finalDeCampo = false;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (enDecimal > -1)
                {
                    enDecimal--;
                }
            }
            //else if (enDecimal == 2 && e.KeyChar == (char)Keys.Back)
            //{
            //    enDecimal = 1;
            //}
            else if (enDecimal == 1 && e.KeyChar == (char)Keys.Back)
            {
                enDecimal = 0;
            }
            else if (enDecimal == 0 && e.KeyChar == (char)Keys.Back)
            {
                enDecimal = -1;
                e.Handled = true;
                control.Select(control.Text.IndexOf('.'), 0);
            }

            //if (e.KeyChar == '0' && enDecimal > 0 && !finalDeCampo)
            //{
            //    e.Handled = true;
            //    control.Select(control.Text.IndexOf('.') + enDecimal, 1);
            //}
            
            //if (control.Text.IndexOf(e.KeyChar) > control.Text.IndexOf('.'))
            //{
            //    int indiceDespuesDelPunto = control.Text.IndexOf()
            //}
            //if (enDecimal == 0 && e.KeyChar == '0')
            //{
            //    e.Handled = true;
            //    control.Select(control.Text.IndexOf('.') + 1, 1);
            //}
            //else if (enDecimal == 1 && e.KeyChar == '0')
            //{
            //    e.Handled = true;
            //    control.Select(control.Text.IndexOf('.') + 2, 1);
            //}
            //else if (enDecimal == 2 && e.KeyChar == '0')
            //{
            //    e.Handled = true;
            //    control.Select(control.Text.IndexOf('.') + 3, 1);
            //}
            //else if (enDecimal == 0)
            //{
            //    enDecimal = 1;
            //    control.Select(control.Text.IndexOf('.') + 1, 0);
            //}
            return ok;
        }

        public decimal FormatearDecimal(object sender, string formato)
        {
            TextBox control = (TextBox)sender;
            decimal valor;
            switch (formato)
            {
                case "Moneda":
                    valor = Moneda(control);
                    break;
                case "TresDecimales":
                     valor = TresDecimales(control);
                    break;
                default:
                    return 0.00m;
            }
            return valor;
        }

        private decimal Moneda(object sender)
        {
            decimal valor;
            TextBox control = (TextBox)sender;
            if (control.Text == string.Empty)
            {
                valor = 0.00m;
                enDecimal = -1;
            }
            else if (control.Text.Contains("$"))
            {
                valor = Convert.ToDecimal(control.Text.Substring(1, control.Text.Length - 1), miCultureConfig);
            }
            else
            {
                valor = Convert.ToDecimal(control.Text, miCultureConfig);
            }

            control.Text = valor.ToString("$#0.#0", miCultureConfig);

            if (enDecimal < 0)
            {
                control.Select(DeterminarPosicionDecimal(sender, 2), 0);
            }
            else
            {
                control.Select(DeterminarPosicionDecimal(sender, 2), 1);
            }

            DetectarFinalDeCampo(sender, ultimoCaracterPresionado, 2);

            //DefaultPosition(sender, valor, 2);

            return valor;
        }

        private decimal TresDecimales(object sender)
        {
            decimal valor;
            TextBox control = (TextBox)sender;
            if (control.Text == string.Empty)
            {
                valor = 0.000m;
                enDecimal = -1;
            }
            else if (control.Text.Contains("Kg") || control.Text.Contains("KG"))
            {
                valor = Convert.ToDecimal(control.Text.Substring(0, control.Text.Length - 2), miCultureConfig);
            }
            else
            {
                valor = Convert.ToDecimal(control.Text, miCultureConfig);
            }

            control.Text = valor.ToString("#0.#00", miCultureConfig);

            if (enDecimal <= 0)
            {
                control.Select(DeterminarPosicionDecimal(sender, 3), 0);
            }
            else
            {
                control.Select(DeterminarPosicionDecimal(sender, 3), 1);
            }

            DetectarFinalDeCampo(sender, ultimoCaracterPresionado, 3);

            //DefaultPosition(sender, valor, 3);

            return valor;
        }

        //private bool Seleccionar(char caracterSiguiente, char caracterAnterior, KeyPressEventArgs e)
        //{
        //    bool seleccionar = false;
        //    if (e.KeyChar != '.' && caracterSiguiente != '.')
        //    {
        //        seleccionar = true;
        //    }
        //    else
        //    {
        //        seleccionar = false;
        //    }
        //    //if (e.KeyChar == (char)Keys.Back && caracterAnterior != '.')
        //    //{
        //    //    seleccionar = true;
        //    //}
        //    //else
        //    //{
        //    //    seleccionar = false;
        //    //}
        //    return seleccionar;
        //}

        public void DefaultPosition(object sender, decimal valor, int cantidadDecimales)
        {
            TextBox control = (TextBox)sender;
            if (finalDeCampo)
            {
                if (cantidadDecimales == 3)
                {
                    if (Convert.ToDecimal(control.Text) == 0)// || valor == 0)//(Convert.ToDecimal(control.Text.Substring(0, control.TextLength - 1)) == 0.00m || valor == 0.00m)
                    {
                        control.Select(0, 1); // (control.Text.Length - 4, 0);
                    }
                }
                else if (cantidadDecimales == 2)
                {
                    if (Convert.ToDecimal(control.Text.Substring(1, control.TextLength - 1)) == 0.00m)// || valor == 0.00m)
                    {
                        control.Select(control.Text.Length - 4, 1);
                    }
                }
            }
        }
        
        private int DeterminarPosicionDecimal(object sender, int cantidadDecimales)
        {
            TextBox control = (TextBox)sender;
            int posicion = 0;
            
            if (enDecimal == 1 && cantidadDecimales == 2 && ultimoCaracterPresionado == Convert.ToChar(control.Text.Substring(control.Text.Length - 1, 1)))
            {
                enDecimal = 2;
            }
            if (enDecimal == 1 && cantidadDecimales == 3 && ultimoCaracterPresionado == Convert.ToChar(control.Text.Substring(control.Text.Length - 3, 1)))
            {
                enDecimal = 2;
            }
            else if (enDecimal == 2 && cantidadDecimales == 3 && ultimoCaracterPresionado == Convert.ToChar(control.Text.Substring(control.Text.Length - 2, 1)))
            {
                enDecimal = 3;
            }
            if (cantidadDecimales == 2)
            {
                switch (enDecimal)
                {
                    case 0:
                        posicion = control.Text.Length - 2;
                        break;
                    case 1:
                        posicion = control.Text.Length - 1;
                        break;
                    case 2:
                        posicion = control.Text.Length - 1;
                        break;
                    default:
                        posicion = control.Text.Length - (cantidadDecimales + 1);
                        break;
                }
            }
            else if (cantidadDecimales == 3)
            {
                switch (enDecimal)
                {
                    case 0:
                        posicion = control.Text.Length - 4;
                        break;
                    case 1:
                        posicion = control.Text.Length - 3;
                        break;
                    case 2:
                        posicion = control.Text.Length - 2;
                        break;
                    case 3:

                        posicion = control.Text.Length - 1;
                        //if (finalDeCampo)
                        //{
                        //    posicion = control.TextLength;
                        //}
                        //else
                        //{
                        //    posicion = control.Text.Length - 1;
                        //}
                        break;
                    default:
                        posicion = control.Text.Length - (cantidadDecimales + 1);
                        break;
                }
            }

            if (ultimoCaracterPresionado == '0' && enDecimal > 0 && !finalDeCampo)
            {
                posicion = control.Text.IndexOf('.') + enDecimal;
            }

            return posicion;
        }

        private void DetectarFinalDeCampo(object sender, char ultimoCaracter, int cantidadDecimales)
        {
            TextBox control = (TextBox)sender;
            if (cantidadDecimales == 2)
            {
                if ((control.Text.Length == control.Text.LastIndexOf(ultimoCaracter) + 1) && (enDecimal == 2))
                {
                    finalDeCampo = true;
                }
            }
            else if (cantidadDecimales == 3)
            {
                if ((control.Text.Length == control.Text.LastIndexOf(ultimoCaracter) + 1) && (enDecimal == 3))
                {
                    finalDeCampo = true;
                }
            }
        }
        #endregion

        #region LONGITUDES MÁXIMAS DE CAMPOS

        // CAMPO MATERIALSINGLELINEtEXTFIELD
        public void LongitudMaximaDeCampo(MaterialSingleLineTextField control, int maxCaracteres, KeyPressEventArgs e)
        {
            if (control.TextLength > maxCaracteres)
            {
                if (Char.IsControl(e.KeyChar) || control.SelectedText.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                control.SelectionStart = control.TextLength;
            }
        }

        // CAMPO TEXTBOX
        public void LongitudMaximaDeCampo(TextBox control, int maxCaracteres, KeyPressEventArgs e)
        {
            if (control.TextLength > maxCaracteres)
            {
                if (Char.IsControl(e.KeyChar) || control.SelectedText.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                control.SelectionStart = control.TextLength;
            }
        }

        // CAMPO RICHTEXTBOX
        public void LongitudMaximaDeCampo(RichTextBox control, int maxCaracteres, KeyPressEventArgs e)
        {
            if (control.TextLength > maxCaracteres)
            {
                if (Char.IsControl(e.KeyChar) || control.SelectedText.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                control.SelectionStart = control.TextLength;
            }
        }
        #endregion

        #region VALIDACIONES ESPECÍFICAS
        // VALIDACIÓN USADA EN FORMULARIO DE INGRESO DE VENTAS PARA ESTABLECER EL MÍNIMO EN EL CAMPO NUMÉRICO QUE INDICA LA CANTIDAD DE ARTÍCULOS QUE SE
        // AGREGARÁN AL CARRITO
        public void CantidadMinima(TextBox control, EventArgs e)
        {
            if (control.Text == string.Empty || control.Text == 0.ToString())
            {
                control.Text = 1.ToString();
            }
        }
        #endregion
        
    }
}