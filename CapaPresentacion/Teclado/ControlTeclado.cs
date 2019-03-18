using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion.Teclado
{
    public class ControlTeclado
    {


        #region KEYDOWN TECLA ESCAPE
        //EVENTOS QUE SE EJECUTARÁN AL PRESIONAR LA TECLA ESCAPE

        public void CerrarForm(KeyEventArgs e, Form form)
        {
            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
            }
        }
        #endregion

        #region TECLA ENTER EN CONTROL
        public void DireccionarEventoDeControl(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)(Keys.Enter):
                    DireccionarTeclaEnterKeyPressEventArgs(sender, e);
                    break;
                default:
                    break;
            }
        }

        public bool DireccionarEventoDeControl(object sender, KeyEventArgs e)
        {
            bool ejecutar = false;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ejecutar = DireccionarTeclaEnterKeyEventArgs(sender, e);
                    break;
                default:
                    break;
            }
            return ejecutar;
        }

        private void DireccionarTeclaEnterKeyPressEventArgs(object sender, KeyPressEventArgs e)
        {
            string nombreTipoDeControl = sender.GetType().Name;
            switch (nombreTipoDeControl)
            {
                case "TextBox":
                    TextBox TextBoxControl = (TextBox)sender;
                    PasarAlControlSiguiente(TextBoxControl, e);
                    break;
                case "BaseTextBox": // "MaterialSingleLineTextField":
                    TextBox TxtBoxControl = (TextBox)sender; // MaterialSingleLineTextField MaterialControl = (MaterialSingleLineTextField)sender;
                    PasarAlControlSiguiente(TxtBoxControl, e);  // PasarAlControlSiguiente(MaterialControl, e);
                    break;
                case "ComboBox":
                    ComboBox ComboBoxControl = (ComboBox)sender;
                    PasarAlControlSiguiente(ComboBoxControl, e);
                    break;
                case "CheckBox":
                    CheckBox CheckBoxControl = (CheckBox)sender;
                    PasarAlControlSiguiente(CheckBoxControl, e);
                    break;
                case "MaterialCheckBox":
                    CheckBox MaterialCheckBoxControl = (CheckBox)sender;
                    PasarAlControlSiguiente(MaterialCheckBoxControl, e);
                    break;
                default:
                    break;
            }
        }

        private bool DireccionarTeclaEnterKeyEventArgs(object sender, KeyEventArgs e)
        {
            bool ejecutar = false;
            string nombreTipoDeControl = sender.GetType().Name;
            switch (nombreTipoDeControl)
            {
                case "DataGridView":
                    DataGridView DataGridViewControl = (DataGridView)sender;
                    ejecutar = TeclaEnterEnDataGridView(DataGridViewControl, e);
                    break;
                default:
                    break;
            }
            return ejecutar;
        }

        private void PasarAlControlSiguiente(TextBox control, KeyPressEventArgs e)
        {
            EnviarTabulacion(e);
        }

        private void PasarAlControlSiguiente(MaterialSingleLineTextField control, KeyPressEventArgs e)
        {
            EnviarTabulacion(e);
            EnviarTabulacion(e);
        }

        private void PasarAlControlSiguiente(ComboBox control, KeyPressEventArgs e)
        {
            EnviarTabulacion(e);
        }

        private void PasarAlControlSiguiente(CheckBox control, KeyPressEventArgs e)
        {
            EnviarTabulacion(e);
        }

        private void EnviarTabulacion(KeyPressEventArgs e)
        {
            e.Handled = true;
            SendKeys.Send("{TAB}");
        }

        //private void EnviarTabulacion(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = true;
        //    SendKeys.Send("{TAB}");
        //}
        #endregion

        #region DATAGRIDVIEW
        public bool TeclaEnterEnDataGridView(DataGridView datagrid, KeyEventArgs e)
        {
            bool ejecutar = false;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Anula la acción por defecto de la tecla Enter, es decir,
                // que la selección de la fila no se desplaza a la siguiente al presionarla.
                ejecutar = true;
                //datagrid.Focus(); // Entrega el foco - No es necesaria ya que el control ya está en foco.
                //if (datagrid.Rows.Count >= 1) // Comprueba si la consulta devolvió alguna fila
                //{
                //    //datagrid.Rows[0].Selected = true; // Selecciona el primer registro del DataGridView
                //    // Tampoco es necesaria ya que el control ya está en foco.
                //    //ClickdgvListado(); // Asigna variables por medio de este método
                //}
            }
            return ejecutar;
        }
        #endregion

        #region ANULAR CTRL + V
        public void DeshabilitarPegado(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) && e.KeyChar == 22) // 22 = tecla v, es decir si se presiona la tecla ctrl + v, la función
                                                              // de pegado se deshabilitará
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
