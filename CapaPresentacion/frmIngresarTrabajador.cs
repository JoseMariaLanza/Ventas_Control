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
    public partial class frmIngresarTrabajador : MaterialForm
    {
        frmTrabajador formTrabajador = new frmTrabajador();
        public int ctrlSeleccionado = 0;
        //CONTENIDO DE DATAGRID
        public string idtrabajador;
        public string nombre;
        public string apellido;
        public string sexo;
        public DateTime fecha_nacimiento;
        public string num_documento;
        public string domicilio;
        public string tel_fijo;
        public string tel_cel;
        public string email;
        public string acceso;
        public string usuario;
        public string password;
        public frmIngresarTrabajador()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmIngresarTrabajador_Load(object sender, EventArgs e)
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
            txtIdTrabajador.Text = string.Empty;
            txtNombre.Text = string.Empty;
            lblApellido.Visible = false;
            txtApellido.Text = string.Empty;
            txtApellido.Visible = false;
            cmbSexo.SelectedIndex = -1;
            cmbSexo.Text = string.Empty;
            dtpFecha_Nacimiento.Value = DateTime.Now;
            dtpFecha_Nacimiento.Text = DateTime.Now.ToString();
            txtNum_Documento.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTel_Fijo.Text = string.Empty;
            txtTel_Cel.Text = string.Empty;
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
            txtNombre.Enabled = valor;
            txtApellido.Enabled = valor;        
            cmbSexo.Enabled = valor;
            dtpFecha_Nacimiento.Enabled = valor;
            txtNum_Documento.Enabled = valor;
            txtDomicilio.Enabled = valor;
            txtTel_Fijo.Enabled = valor;
            txtTel_Cel.Enabled = valor;
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
                    lblTrabajador.Text = "Nuevo trabajador";
                    txtNombre.SelectAll();
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
                    txtNombre.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(false);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    txtIdTrabajador.Text = idtrabajador;
                    txtNombre.Text = nombre;
                    txtApellido.Text = apellido;
                    cmbSexo.Text = sexo;
                    dtpFecha_Nacimiento.Value = fecha_nacimiento;
                    txtNum_Documento.Text = num_documento;
                    txtDomicilio.Text = domicilio;
                    txtTel_Fijo.Text = tel_fijo;
                    txtTel_Cel.Text = tel_cel;
                    txtEmail.Text = email;
                    cmbAcceso.Text = acceso;
                    txtUsuario.Text = usuario;
                    txtPassword.Text = password;
                    lblConfirmarPassword.Visible = false;
                    txtConfirmarPassword.Visible = false;
                    lblTrabajador.Text = "Detalles";
                    break;
                case 3: //CANCELAR
                    Habilitar(false);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    txtIdTrabajador.Text = idtrabajador;
                    txtNombre.Text = nombre;
                    txtApellido.Text = apellido;
                    cmbSexo.Text = sexo;
                    dtpFecha_Nacimiento.Value = fecha_nacimiento;
                    txtNum_Documento.Text = num_documento;
                    txtDomicilio.Text = domicilio;
                    txtTel_Fijo.Text = tel_fijo;
                    txtTel_Cel.Text = tel_cel;
                    txtEmail.Text = email;
                    cmbAcceso.Text = acceso;
                    txtUsuario.Text = usuario;
                    txtPassword.Text = password;
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
            if (txtNombre.Text == string.Empty)
            {
                errorIcono.SetError(txtNombre, "Ingrese el nombre del trabajador");
                txtNombre.SelectAll();
            }
            else if (txtApellido.Text == string.Empty)
            {
                errorIcono.SetError(txtApellido, "Ingrese el apellido del cliente");
                txtApellido.SelectAll();
            }
            else if (cmbSexo.Text == string.Empty)
            {
                errorIcono.SetError(cmbSexo, "Ingrersse el sexo del trabajador");
                cmbSexo.Focus();
            }
            else if (dtpFecha_Nacimiento.Value == DateTime.Now.Date)
            {
                errorIcono.SetError(dtpFecha_Nacimiento, "Ingrese la fecha de nacimiento del trabajador");
                dtpFecha_Nacimiento.Focus();
            }
            else if (txtNum_Documento.Text == string.Empty)
            {
                errorIcono.SetError(txtNum_Documento, "INgrese el número de documento del trabajador");
                txtNum_Documento.SelectAll();
            }
            else if (cmbAcceso.Text == string.Empty)
            {
                errorIcono.SetError(cmbAcceso, "Ingrese el nivel de acceso del trabajador");
                cmbAcceso.Focus();
            }
            else if (txtUsuario.Text == string.Empty)
            {
                errorIcono.SetError(txtUsuario, "Ingrese el nombre de usuario del trabajador");
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
                            agregarActualizar = NegocioTrabajador.Insertar(txtNombre.Text.Trim().ToUpper(),
                            txtApellido.Text.Trim().ToUpper(), cmbSexo.Text, dtpFecha_Nacimiento.Value,txtNum_Documento.Text, 
                            txtDomicilio.Text, txtTel_Fijo.Text, txtTel_Cel.Text, txtEmail.Text, cmbAcceso.Text, 
                            txtUsuario.Text.Trim(), txtPassword.Text.Trim());

                            NotificacionOk("Trabajador guardado correctamente", "Guardando");
                            txtNombre.SelectAll();
                            Limpiar();
                            break;
                        case 1://EDITAR
                            agregarActualizar = NegocioTrabajador.Editar(Convert.ToInt32(txtIdTrabajador.Text),
                            txtNombre.Text.Trim().ToUpper(), txtApellido.Text.Trim().ToUpper(), cmbSexo.Text, dtpFecha_Nacimiento.Value, 
                            txtNum_Documento.Text, txtDomicilio.Text, txtTel_Fijo.Text, txtTel_Cel.Text, txtEmail.Text, cmbAcceso.Text,
                            txtUsuario.Text.Trim(), txtPassword.Text.Trim());

                            nombre = txtNombre.Text;
                            apellido = txtApellido.Text;
                            sexo = cmbSexo.Text;
                            dtpFecha_Nacimiento.Value = fecha_nacimiento;
                            num_documento = txtNum_Documento.Text;
                            domicilio = txtDomicilio.Text;
                            tel_fijo = txtTel_Fijo.Text;
                            tel_cel = txtTel_Cel.Text;
                            email = txtEmail.Text;
                            acceso = cmbAcceso.Text;
                            usuario = txtUsuario.Text;
                            password = txtPassword.Text;
                            txtConfirmarPassword.Text = string.Empty;
                            ctrlSeleccionado = 3;
                            NotificacionOk("Trabajador editado correctamente", "Editando");
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
            validarLongitud(txtNombre, 50, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region APELLIDO
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarTexto(e);
            validarLongitud(txtApellido, 50, e);
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
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX NUMERO DE DOCUMENTO
        private void txtNum_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            validarLongitud(txtNum_Documento, 11, e);
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
            validarLongitud(txtTel_Fijo, 10, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX TELEFONO CELULAR
        private void txtTel_Cel_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            validarLongitud(txtTel_Cel, 12, e);
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
