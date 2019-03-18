using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using CapaNegocio;

using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmIngresarCliente : MaterialForm
    {
        frmCliente formCliente = new frmCliente();
        public int ctrlSeleccionado = 0;
        //CONTENIDO DE DATAGRID
        public string IdCliente;
        public string Nombres;
        public string Apellidos;
        public string Sexo;
        public DateTime FechaNacimiento;
        public string TipoDocumento;
        public string NumeroDocumento;
        public string Domicilio;
        public string TelefonoFijo;
        public string TelefonoCelular;
        public string Email;

        ControlTeclado controlTeclado = new ControlTeclado();

        public frmIngresarCliente()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmIngresarCliente_Load(object sender, EventArgs e)
        {
            HabilitarBotones();
        }

        #region MOSTRAR

        #region NOTIFICACIONES
        //ICONO DE NOTIFICACIÓN
        public void NotificacionOk(string mensaje, string titulo)
        {
            iconoNotificacion.Visible = false;
            iconoNotificacion.Visible = true;
            iconoNotificacion.BalloonTipText = mensaje;
            iconoNotificacion.BalloonTipTitle = titulo;
            iconoNotificacion.Icon = SystemIcons.Information;
            iconoNotificacion.ShowBalloonTip(1000);
        }

        public void NotificacionError(string mensaje, string titulo)
        {
            iconoNotificacion.Visible = false;
            iconoNotificacion.Visible = true;
            iconoNotificacion.BalloonTipText = mensaje;
            iconoNotificacion.BalloonTipTitle = titulo;
            iconoNotificacion.Icon = SystemIcons.Error;
            iconoNotificacion.ShowBalloonTip(1000);
        }
        #endregion

        #region LIMPIAR
        public void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
            chkPersonaFisica.Checked = false;
            txtNombres.Text = string.Empty;
            lblApellidos.Visible = false;
            txtApellidos.Text = string.Empty;
            txtApellidos.Visible = false;
            cmbSexo.Text = string.Empty;
            cmbSexo.SelectedValue = 0;
            dtpFechaNacimiento.Value = DateTime.Now;
            dtpFechaNacimiento.Text = DateTime.Now.ToString();
            cmbTipoDocumento.Text = string.Empty;
            cmbTipoDocumento.SelectedValue = 0;
            txtNumeroDocumento.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
        #endregion

        #region HABILITAR

        #region HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtNombres.Enabled = valor;
            txtApellidos.Enabled = valor;
            chkPersonaFisica.Enabled = valor;
            cmbSexo.Enabled = valor;
            dtpFechaNacimiento.Enabled = valor;
            cmbTipoDocumento.Enabled = valor;
            txtNumeroDocumento.Enabled = valor;
            txtDomicilio.Enabled = valor;
            txtTelefonoFijo.Enabled = valor;
            txtTelefonoCelular.Enabled = valor;
            txtEmail.Enabled = valor;
        }
        #endregion

        #region HABILITAR BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(true);
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = false;
                    chkPersonaFisica.Enabled = true;
                    lblCliente.Text = "Nuevo cliente";
                    txtNombres.SelectAll();
                    break;
                case 1: //EDITAR
                    Habilitar(true);
                    btnInsertar.Enabled = false;
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    chkPersonaFisica.Enabled = true;
                    lblCliente.Text = "Detalles";
                    txtNombres.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(false);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    chkPersonaFisica.Enabled = false;
                    txtIdCliente.Text = IdCliente;
                    txtNombres.Text = Nombres;
                    txtApellidos.Text = Apellidos;
                    if (Apellidos.Length > 0)
                    cmbSexo.Text = Sexo;
                    dtpFechaNacimiento.Value = FechaNacimiento;
                    // Fijarse si hace falta poner la fecha en formato texto
                    cmbTipoDocumento.Text = TipoDocumento;
                    txtNumeroDocumento.Text = NumeroDocumento;
                    txtDomicilio.Text = Domicilio;
                    txtTelefonoFijo.Text = TelefonoFijo;
                    txtTelefonoCelular.Text = TelefonoCelular;
                    txtEmail.Text = Email;
                    lblCliente.Text = "Detalles";
                    break;
                case 3: //CANCELAR
                    Habilitar(false);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    chkPersonaFisica.Enabled = false;
                    txtIdCliente.Text = IdCliente;
                    txtNombres.Text = Nombres;
                    txtApellidos.Text = Apellidos;
                    cmbSexo.Text = Sexo;
                    dtpFechaNacimiento.Value = FechaNacimiento;
                    cmbTipoDocumento.Text = TipoDocumento;
                    txtNumeroDocumento.Text = NumeroDocumento;
                    txtDomicilio.Text = Domicilio;
                    txtTelefonoFijo.Text = TelefonoFijo;
                    txtTelefonoCelular.Text = TelefonoCelular;
                    txtEmail.Text = Email;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblCliente.Text = "Detalles";
                    break;
            }
        }
        #endregion

        // BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            HabilitarBotones();
            btnCancelar.Visible = true;
            Limpiar();
        }

        //BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            HabilitarBotones();
        }

        //CHEKBOX HABILITA EL TEXTBOX APELLIDO
        private void chkPersonaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonaFisica.Checked)
            {
                lblNombres.Text = "Nombres:";
                txtNombres.Hint = "Nombre";
                lblApellidos.Visible = true;
                txtApellidos.Visible = true;
                txtApellidos.Text = Apellidos;
                lblSexo.Visible = true;
                cmbSexo.Text = Sexo;
                cmbSexo.Visible = true;
                if (txtNombres.Text == string.Empty || txtNombres.Text == "")
                {
                    txtNombres.SelectAll();
                }
                else
                {
                    txtApellidos.SelectAll();
                }
            }
            else
            {
                lblNombres.Text = "Razón Social:";
                txtNombres.Hint = "Razón Social:";
                lblApellidos.Visible = false;
                txtApellidos.Visible = false;
                txtApellidos.Text = string.Empty;
                lblSexo.Visible = false;
                cmbSexo.Text = string.Empty;
                cmbSexo.Visible = false;
                txtNombres.SelectAll();
            }
        }

        #endregion

        #endregion

        #region INSERTAR EDITAR

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {
            string agregarActualizar = "";
            if (txtNombres.Text == string.Empty)
            {
                if (chkPersonaFisica.Checked)
                {
                    errorIcono.SetError(txtNombres, "Ingrese el nombre del cliente");
                }
                errorIcono.SetError(txtNombres, "Ingrese la razón social del cliente.");
                txtNombres.SelectAll();
            }
            else if (chkPersonaFisica.Checked && txtApellidos.Text == string.Empty)
            {
                errorIcono.SetError(txtApellidos, "Ingrese el apellido del cliente");
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            if (chkPersonaFisica.Checked == false && txtApellidos.Text == string.Empty)
                            {
                                agregarActualizar = NegocioCliente.Insertar(txtNombres.Text.Trim().ToUpper(),
                                txtApellidos.Text.Trim().ToUpper(), cmbSexo.Text.Trim(), dtpFechaNacimiento.Value, cmbTipoDocumento.Text.Trim().ToUpper(),
                                txtNumeroDocumento.Text, txtDomicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text);
                            }
                            else
                            {
                                agregarActualizar = NegocioCliente.Insertar(txtNombres.Text.Trim().ToUpper(),
                                txtApellidos.Text.Trim().ToUpper(), cmbSexo.Text.Trim(), dtpFechaNacimiento.Value, cmbTipoDocumento.Text.Trim().ToUpper(),
                                txtNumeroDocumento.Text, txtDomicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text);
                            }
                            NotificacionOk("Cliente guardado correctamente", "Guardando");
                            txtNombres.SelectAll();
                            Limpiar();
                            break;
                        case 1://EDITAR
                            if (chkPersonaFisica.Checked == false && txtApellidos.Text == string.Empty)
                            {
                                agregarActualizar = NegocioCliente.Editar(Convert.ToInt32(txtIdCliente.Text),
                                txtNombres.Text.Trim().ToUpper(),
                                txtApellidos.Text.Trim().ToUpper(), cmbSexo.Text.Trim(), dtpFechaNacimiento.Value, cmbTipoDocumento.Text.Trim().ToUpper(),
                                txtNumeroDocumento.Text, txtDomicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text);
                            }
                            else
                            {
                                agregarActualizar = NegocioCliente.Editar(Convert.ToInt32(txtIdCliente.Text),
                                txtNombres.Text.Trim().ToUpper(),
                                txtApellidos.Text.Trim().ToUpper(), cmbSexo.Text.Trim(), dtpFechaNacimiento.Value, cmbTipoDocumento.Text.Trim().ToUpper(),
                                txtNumeroDocumento.Text, txtDomicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text);
                            }
                            Nombres = txtNombres.Text;
                            Apellidos = txtApellidos.Text;
                            Sexo = cmbSexo.Text;
                            dtpFechaNacimiento.Value = FechaNacimiento;
                            TipoDocumento = cmbTipoDocumento.Text;
                            NumeroDocumento = txtNumeroDocumento.Text;
                            Domicilio = txtDomicilio.Text;
                            TelefonoFijo = txtTelefonoFijo.Text;
                            TelefonoCelular = txtTelefonoCelular.Text;
                            Email = txtEmail.Text;
                            ctrlSeleccionado = 3;
                            NotificacionOk("Cliente editado correctamente", "Editando");
                            break;
                        default:
                            NotificacionError(agregarActualizar, "Error");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                HabilitarBotones();
            }
        }
        #endregion
        

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarEditar();
        }

        #endregion

        #region EVENTOS TECLADO

        #region KEYDOWN TECLA ESCAPE
        //EVENTO QUE SE EJECUTARÁ AL PRESIONAR LA TECLA ESCAPE
        private void frmIngresarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region TECLA ENTER EN CONTROL
        private void pasarControlSiguiente(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #endregion

        #region VALIDADION DE CONTROLES

        #region METODO QUE VALIDA UN CONTROL DE TIPO RICHTEXTBOX
        private void validarLongitud(RichTextBox control, int maxCaracteres, KeyPressEventArgs e)
        {
            if (control.Text.Length > maxCaracteres)
            {
                errorIcono.SetError(control, "Sólo puede ingresar un máximo de " + maxCaracteres + " carateres en este campo.");
                if (Char.IsControl(e.KeyChar) || control.SelectedText.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                control.ScrollToCaret();
            }
        }
        #endregion

        #region METODO QUE VALIDA UN CONTROL DE TIPO MATERIALSINGLELINETEXTFIELD
        private void validarLongitud(MaterialSingleLineTextField control, int maxCaracteres, KeyPressEventArgs e)
        {
            //VALIDANDO LONGITUD DE CAMPO
            if (control.TextLength > maxCaracteres)
            {
                errorIcono.SetError(control, "Sólo puede ingresar un máximo de " + maxCaracteres + " carateres en este campo.");
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
            pasarControlSiguiente(e);
        }
        #endregion

        #region PASAR TEXT A MAYÚSCULAS - ESTA SIN USAR
        private void pasarAMayuscula(MaterialSingleLineTextField control)
        {
            if (!String.IsNullOrEmpty(control.Text))
            {
                control.Text = control.Text.ToUpper();
                control.SelectionStart = control.TextLength;
            }
        }
        #endregion

        #region VALIDACION DE TIPO DE DATOS QUE SE INGRESARAN EN TEXTBOX

        #region SOLO TEXTO
        private void ingresarTexto(KeyPressEventArgs e)
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

        #region SOLO NUMEROS
        private void ingresarNumero(KeyPressEventArgs e)
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

        #endregion

        #region TEXTBOX NOMBRE
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarTexto(e);
            validarLongitud(txtNombres, 50, e);
        }
        #endregion

        #region CHECKBOX PERSONA FISICA
        private void chkPersonaFisica_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
        }
        #endregion

        #region APELLIDO
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarTexto(e);
            validarLongitud(txtApellidos, 50, e);
        }
        #endregion

        #region COMBOBOX SEXO
        private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
        }
        #endregion

        #region DATETIMEPICKER FECHA DE NACIMIENTO
        private void dtpFecha_Nacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
        }
        #endregion

        #region COMBOBOX TIPO DE DOCUMENTO
        private void cmbTipo_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX NUMERO DE DOCUMENTO
        private void txtNum_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            validarLongitud(txtNumeroDocumento, 11, e);
        }
        #endregion

        #region TEXTBOX DOMICILIO
        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLongitud(txtDomicilio, 100, e);
        }
        #endregion

        #region TEXTBOX TELEFONO FIJO
        private void txtTel_Fijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            validarLongitud(txtTelefonoFijo, 10, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX TELEFONO CELULAR
        private void txtTel_Cel_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            validarLongitud(txtTelefonoCelular, 12, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX EMAIL
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                errorIcono.SetError(txtEmail, "La dirección de e-mail no contiene espacios");
                e.Handled = true;
            }
            validarLongitud(txtEmail, 50, e);
        }
        #endregion

        #endregion
        
    }
}
