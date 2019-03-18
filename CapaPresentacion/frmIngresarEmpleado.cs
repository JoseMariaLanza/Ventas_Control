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

namespace CapaPresentacion
{
    public partial class frmIngresarEmpleado : MaterialForm
    {
        frmEmpleados formEmpleados = new frmEmpleados();
        public int ctrlSeleccionado = 0;
        //CONTENIDO DE DATAGRID
        public string IdEmpleado;
        public string Nombres;
        public string Apellidos;
        public string Sexo;
        public DateTime FechaNacimiento;
        public string NumeroDocumento;
        public string Domicilio;
        public string TelefonoFijo;
        public string TelefonoCelular;
        public string Email;
        public string Acceso;
        public string Usuario;
        public string Password;
        public frmIngresarEmpleado()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmIngresarEmpleado_Load(object sender, EventArgs e)
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
            txtIdEmpleado.Text = string.Empty;
            txtNombres.Text = string.Empty;
            lblApellido.Visible = false;
            txtApellidos.Text = string.Empty;
            txtApellidos.Visible = false;
            cmbSexo.SelectedIndex = -1;
            cmbSexo.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Now;
            dtpFechaNacimiento.Text = DateTime.Now.ToString();
            txtNumeroDocumento.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbAcceso.SelectedIndex = -1;
            cmbAcceso.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmarPassword.Text = string.Empty;
        }
        #endregion

        #region HABILITAR

        #region HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtNombres.Enabled = valor;
            txtApellidos.Enabled = valor;        
            cmbSexo.Enabled = valor;
            dtpFechaNacimiento.Enabled = valor;
            txtNumeroDocumento.Enabled = valor;
            txtDomicilio.Enabled = valor;
            txtTelefonoFijo.Enabled = valor;
            txtTelefonoCelular.Enabled = valor;
            txtEmail.Enabled = valor;
            cmbAcceso.Enabled = valor;
            txtUsuario.Enabled = valor;
            txtPassword.Enabled = valor;
            lblConfirmarPassword.Visible = valor;
            txtConfirmarPassword.Visible = valor;
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
                    lblTrabajador.Text = "Nuevo empleado";
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
                    lblTrabajador.Text = "Detalles";
                    txtNombres.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(false);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    txtIdEmpleado.Text = IdEmpleado;
                    txtNombres.Text = Nombres;
                    txtApellidos.Text = Apellidos;
                    cmbSexo.Text = Sexo;
                    dtpFechaNacimiento.Value = FechaNacimiento;
                    txtNumeroDocumento.Text = NumeroDocumento;
                    txtDomicilio.Text = Domicilio;
                    txtTelefonoFijo.Text = TelefonoFijo;
                    txtTelefonoCelular.Text = TelefonoCelular;
                    txtEmail.Text = Email;
                    cmbAcceso.Text = Acceso;
                    txtUsuario.Text = Usuario;
                    txtPassword.Text = Password;
                    lblConfirmarPassword.Visible = false;
                    txtConfirmarPassword.Visible = false;
                    lblTrabajador.Text = "Detalles";
                    break;
                case 3: //CANCELAR
                    Habilitar(false);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    txtIdEmpleado.Text = IdEmpleado;
                    txtNombres.Text = Nombres;
                    txtApellidos.Text = Apellidos;
                    cmbSexo.Text = Sexo;
                    dtpFechaNacimiento.Value = FechaNacimiento;
                    txtNumeroDocumento.Text = NumeroDocumento;
                    txtDomicilio.Text = Domicilio;
                    txtTelefonoFijo.Text = TelefonoFijo;
                    txtTelefonoCelular.Text = TelefonoCelular;
                    txtEmail.Text = Email;
                    cmbAcceso.Text = Acceso;
                    txtUsuario.Text = Usuario;
                    txtPassword.Text = Password;
                    lblConfirmarPassword.Visible = false;
                    txtConfirmarPassword.Visible = false;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblTrabajador.Text = "Detalles";
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
        #endregion
        #endregion

        #region INSERTAR EDITAR

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {
            string agregarActualizar = "";
            if (txtNombres.Text == string.Empty)
            {
                errorIcono.SetError(txtNombres, "Ingrese el nombre del empleado");
                txtNombres.SelectAll();
            }
            else if (txtApellidos.Text == string.Empty)
            {
                errorIcono.SetError(txtApellidos, "Ingrese el apellido del empleado");
                txtApellidos.SelectAll();
            }
            else if (cmbSexo.Text == string.Empty)
            {
                errorIcono.SetError(cmbSexo, "Ingrersse el sexo del trabajador");
                cmbSexo.Focus();
            }
            else if (dtpFechaNacimiento.Value == DateTime.Now.Date)
            {
                errorIcono.SetError(dtpFechaNacimiento, "Ingrese la fecha de nacimiento del empleado");
                dtpFechaNacimiento.Focus();
            }
            else if (txtNumeroDocumento.Text == string.Empty)
            {
                errorIcono.SetError(txtNumeroDocumento, "INgrese el número de documento del empleado");
                txtNumeroDocumento.SelectAll();
            }
            else if (cmbAcceso.Text == string.Empty)
            {
                errorIcono.SetError(cmbAcceso, "Ingrese el nivel de acceso del empleado");
                cmbAcceso.Focus();
            }
            else if (txtUsuario.Text == string.Empty)
            {
                errorIcono.SetError(txtUsuario, "Ingrese el nombre de usuario del empleado");
                txtUsuario.SelectAll();
            }
            else if (txtPassword.Text == string.Empty)
            {
                errorIcono.SetError(txtPassword, "Ingrese la contraseña del usuario");
                txtPassword.SelectAll();
            }
            else if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                errorIcono.SetError(txtConfirmarPassword, "Las contraseñas no coinciden");
                txtConfirmarPassword.SelectAll();
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            agregarActualizar = NegocioEmpleado.Insertar(txtNombres.Text.Trim().ToUpper(),
                            txtApellidos.Text.Trim().ToUpper(), cmbSexo.Text, dtpFechaNacimiento.Value,txtNumeroDocumento.Text, 
                            txtDomicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text, cmbAcceso.Text, 
                            txtUsuario.Text.Trim(), txtPassword.Text.Trim());

                            NotificacionOk("Empleado guardado correctamente", "Guardando");
                            txtNombres.SelectAll();
                            Limpiar();
                            break;
                        case 1://EDITAR
                            agregarActualizar = NegocioEmpleado.Editar(Convert.ToInt32(txtIdEmpleado.Text),
                            txtNombres.Text.Trim().ToUpper(), txtApellidos.Text.Trim().ToUpper(), cmbSexo.Text, dtpFechaNacimiento.Value, 
                            txtNumeroDocumento.Text, txtDomicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text, cmbAcceso.Text,
                            txtUsuario.Text.Trim(), txtPassword.Text.Trim());

                            Nombres = txtNombres.Text;
                            Apellidos = txtApellidos.Text;
                            Sexo = cmbSexo.Text;
                            dtpFechaNacimiento.Value = FechaNacimiento;
                            NumeroDocumento = txtNumeroDocumento.Text;
                            Domicilio = txtDomicilio.Text;
                            TelefonoFijo = txtTelefonoFijo.Text;
                            TelefonoCelular = txtTelefonoCelular.Text;
                            Email = txtEmail.Text;
                            Acceso = cmbAcceso.Text;
                            Usuario = txtUsuario.Text;
                            Password = txtPassword.Text;
                            txtConfirmarPassword.Text = string.Empty;
                            ctrlSeleccionado = 3;
                            NotificacionOk("Empleado editado correctamente", "Editando");
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
        private void frmIngresarTrabajador_KeyDown(object sender, KeyEventArgs e)
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
                    errorIcono.Clear();
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

        #region TEXTBOX NOMBRES
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarTexto(e);
            validarLongitud(txtNombres, 50, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region APELLIDOS
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dtpFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX NUMERO DE DOCUMENTO
        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtTelefonoFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            validarLongitud(txtTelefonoFijo, 10, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX TELEFONO CELULAR
        private void txtTelefonoCelular_KeyPress(object sender, KeyPressEventArgs e)
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

        #region COMBOBOX ACCESO
        private void cmbAcceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX USUARIO
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLongitud(txtUsuario, 20, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX PASSWORD
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLongitud(txtPassword, 20, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX CONFIRMAR PASSWORD
        private void txtConfirmarPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLongitud(txtConfirmarPassword, 20, e);
        }
        #endregion
        #endregion
        
    }
}
