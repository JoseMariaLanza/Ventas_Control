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
    public partial class frmIngresarProveedor : MaterialForm
    {
        frmProveedor formProveedor = new frmProveedor();
        Validacion.Validacion validaciones = new Validacion.Validacion();
        public int ctrlSeleccionado = 0;
        //CONTENIDO DE DATAGRID
        public string IdProveedor;
        public string Nombres;
        public string Apellidos;
        public string Rubro;
        public string TipoDocumento;
        public string NumeroDocumento;
        public string Domicilio;
        public string TelefonoFijo;
        public string TelefonoCelular;
        public string Email;
        public string URL;

        public frmIngresarProveedor()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmIngresarProveedor_Load(object sender, EventArgs e)
        {
            HabilitarBotones();
        }

        #region INSTANCIACION
        private static frmIngresarProveedor _Instancia = null;

        public static frmIngresarProveedor Instancia
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

        public static frmIngresarProveedor GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarProveedor();
                //Instancia.Disposed += new EventHandler(formIngresarProveedor_Disposed);
            }
            return Instancia;
        }

        //METODO FORM DISPOSED PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void formIngresarProveedor_Disposed(object sender, EventArgs e)
        {
            Instancia = null;
        }
        #endregion

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

        //LIMPIAR
        public void Limpiar()
        {
            txtIdProveedor.Text = string.Empty;
            chkPersonaFisica.Checked = false;
            txtNombres.Text = string.Empty;
            lblApellido.Visible = false;
            txtApellidos.Text = string.Empty;
            txtApellidos.Visible = false;
            cmbRubro.Text = string.Empty;
            cmbRubro.SelectedValue = 0;
            cmbTipoDocumento.Text = string.Empty;
            cmbTipoDocumento.SelectedValue = 0;
            txtNumeroDocumento.Text = string.Empty;
            rtxtDocmicilio.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtURL.Text = string.Empty;
        }

        #region HABILITAR

        //HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtNombres.Enabled = valor;
            txtApellidos.Enabled = valor;
            chkPersonaFisica.Enabled = valor;
            cmbRubro.Enabled = valor;
            cmbTipoDocumento.Enabled = valor;
            txtNumeroDocumento.Enabled = valor;
            rtxtDocmicilio.Enabled = valor;
            txtTelefonoFijo.Enabled = valor;
            txtTelefonoCelular.Enabled = valor;
            txtEmail.Enabled = valor;
            txtURL.Enabled = valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
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
                    lblProveedor.Text = "Nuevo proveedor";
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
                    lblProveedor.Text = "Detalles";
                    txtNombres.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(false);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    chkPersonaFisica.Enabled = false;
                    txtIdProveedor.Text = IdProveedor;
                    txtNombres.Text = Nombres;
                    if (Apellidos.Length > 0)
                    {
                        txtApellidos.Text = Apellidos.Remove(Apellidos.Length - 1, 1);
                    }
                    else
                    {
                        txtApellidos.Text = Apellidos;
                    }
                    cmbRubro.Text = Rubro;
                    cmbTipoDocumento.Text = TipoDocumento;
                    txtNumeroDocumento.Text = NumeroDocumento;
                    rtxtDocmicilio.Text = Domicilio;
                    txtTelefonoFijo.Text = TelefonoFijo;
                    txtTelefonoCelular.Text = TelefonoCelular;
                    txtEmail.Text = Email;
                    txtURL.Text = URL;
                    lblProveedor.Text = "Detalles";
                    break;
                case 3: //CANCELAR
                    Habilitar(false);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    chkPersonaFisica.Enabled = false;
                    txtIdProveedor.Text = IdProveedor;
                    txtNombres.Text = Nombres;
                    txtApellidos.Text = Apellidos;
                    cmbRubro.Text = Rubro;
                    cmbTipoDocumento.Text = TipoDocumento;
                    txtNumeroDocumento.Text = NumeroDocumento;
                    rtxtDocmicilio.Text = Domicilio;
                    txtTelefonoFijo.Text = TelefonoFijo;
                    txtTelefonoCelular.Text = TelefonoCelular;
                    txtEmail.Text = Email;
                    txtURL.Text = URL;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblProveedor.Text = "Detalles";
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            HabilitarBotones();
            btnCancelar.Visible = true;
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }


        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            HabilitarBotones();
        }

        #region INSERTAR EDITAR

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {
            string agregarActualizar = "";
            if (txtNombres.Text == string.Empty)
            {
                errorIcono.SetError(txtNombres, "Ingrese el nombre o razón social del proveedor.");
                txtNombres.SelectAll();
            }
            else
            {
                if (cmbRubro.Text == string.Empty)
                {
                    errorIcono.SetError(cmbRubro, "Ingrese el rubro del proveedor.");
                    cmbRubro.Focus();
                }
                else
                {
                    if (cmbTipoDocumento.Text == string.Empty)
                    {
                        errorIcono.SetError(cmbTipoDocumento, "Ingrese el tipo de documento del proveedor.");
                        cmbTipoDocumento.Focus();
                    }
                    else
                    {
                        if (txtNumeroDocumento.Text == string.Empty)
                        {
                            errorIcono.SetError(txtNumeroDocumento, "Ingrese el número de documento del proveedor.");
                            txtNumeroDocumento.SelectAll();
                        }
                        else
                        {
                            if (chkPersonaFisica.Checked && txtApellidos.Text == string.Empty)
                            {
                                errorIcono.SetError(txtApellidos, "Ingrese el apellido.");
                                txtApellidos.SelectAll();
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
                                                agregarActualizar = NegocioProveedor.Insertar(txtNombres.Text.Trim().ToUpper(),
                                                txtApellidos.Text.Trim().ToUpper(), cmbRubro.Text.Trim(), cmbTipoDocumento.Text.Trim().ToUpper(),
                                                txtNumeroDocumento.Text, rtxtDocmicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text, txtURL.Text);
                                            }
                                            else
                                            {
                                                agregarActualizar = NegocioProveedor.Insertar(txtNombres.Text.Trim().ToUpper(),
                                                txtApellidos.Text.Trim() + ", ".ToUpper(), cmbRubro.Text.Trim(), cmbTipoDocumento.Text.Trim().ToUpper(),
                                                txtNumeroDocumento.Text, rtxtDocmicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text, txtURL.Text);
                                            }
                                            NotificacionOk("Proveedor guardado correctamente", "Guardando");
                                            txtNombres.SelectAll();
                                            Limpiar();
                                            break;
                                        case 1://EDITAR
                                            if (chkPersonaFisica.Checked == false && txtApellidos.Text == string.Empty)
                                            {
                                                agregarActualizar = NegocioProveedor.Editar(Convert.ToInt32(txtIdProveedor.Text),
                                                txtNombres.Text.Trim().ToUpper(),
                                                txtApellidos.Text.Trim().ToUpper(), cmbRubro.Text.Trim(), cmbTipoDocumento.Text.Trim().ToUpper(),
                                                txtNumeroDocumento.Text, rtxtDocmicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text, txtURL.Text);
                                            }
                                            else
                                            {
                                                agregarActualizar = NegocioProveedor.Editar(Convert.ToInt32(txtIdProveedor.Text),
                                                txtNombres.Text.Trim().ToUpper(),
                                                txtApellidos.Text.Trim() + ", ".ToUpper(), cmbRubro.Text.Trim(), cmbTipoDocumento.Text.Trim().ToUpper(),
                                                txtNumeroDocumento.Text, rtxtDocmicilio.Text, txtTelefonoFijo.Text, txtTelefonoCelular.Text, txtEmail.Text, txtURL.Text);
                                            }
                                            Nombres = txtNombres.Text;
                                            Apellidos = txtApellidos.Text;
                                            Rubro = cmbRubro.Text;
                                            TipoDocumento = cmbTipoDocumento.Text;
                                            NumeroDocumento = txtNumeroDocumento.Text;
                                            Domicilio = rtxtDocmicilio.Text;
                                            TelefonoFijo = txtTelefonoFijo.Text;
                                            TelefonoCelular = txtTelefonoCelular.Text;
                                            Email = txtEmail.Text;
                                            URL = txtURL.Text;
                                            ctrlSeleccionado = 3;
                                            NotificacionOk("Proveedor editado correctamente", "Editando");
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
                    }
                }
            }
        }
        #endregion

        //CHEKBOX HABILITA EL TEXTBOX APELLIDO
        private void chkPersonaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonaFisica.Checked)
            {
                lblNombres.Text = "Nombre:";
                txtNombres.Hint = "Nombre";
                lblApellido.Visible = true;
                txtApellidos.Visible = true;
                txtApellidos.Text = Apellidos;
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
                lblApellido.Visible = false;
                txtApellidos.Visible = false;
                txtApellidos.Text = string.Empty;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarEditar();
        }



        #endregion

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox control = (TextBox)sender;
            validaciones.LongitudMaximaDeCampo(control, 11, e);
            validaciones.IngresarNumeroEntero(e);
        }

        private void txtTelefonoFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox control = (TextBox)sender;
            validaciones.LongitudMaximaDeCampo(control, 11, e);
            validaciones.IngresarNumeroEntero(e);
        }

        private void txtTelefonoCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox control = (TextBox)sender;
            validaciones.LongitudMaximaDeCampo(control, 13, e);
            validaciones.IngresarNumeroEntero(e);
        }
    }
}
