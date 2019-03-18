using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

using MaterialSkin;
using MaterialSkin.Controls;

using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmIngresarPresentacion : MaterialForm
    {
        public int ctrlSeleccionado = 0;
        public int IdPresentacion;
        public string Presentacion;
        public string Descripcion;

        ControlTeclado controlTeclado = new ControlTeclado();

        public frmIngresarPresentacion()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtPresentacion,
                "Ingrese el nombre de la presentación.");
            ttMensaje.SetToolTip(txtDescripcion,
                "Ingrese una descripcion para esta presentación.");
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmIngresarPresentacion_Load(object sender, EventArgs e)
        {
            HabilitarBotones();
            txtPresentacion.SelectAll();
        }

        #region INSTANCIACION
        private static frmIngresarPresentacion _Instancia;

        public static frmIngresarPresentacion Instancia
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

        public static frmIngresarPresentacion GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarPresentacion();
            }
            return Instancia;
        }

        private void frmIngresarPresentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            txtIdPresentacion.Text = string.Empty;
            txtPresentacion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        #region MOSTRAR

        #region HABILITAR
        //HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtPresentacion.Enabled = valor;
            txtDescripcion.ReadOnly = !valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(true);
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    IdPresentacion = 0;
                    Presentacion = string.Empty;
                    Descripcion = string.Empty;
                    lblAgregandoPresentacion.Text = "Agregando presentación";
                    break;
                case 1: //EDITAR
                    Habilitar(true);
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    lblAgregandoPresentacion.Text = "Detalles";
                    break;
                case 2: //CONSULTAR
                    Habilitar(false);
                    btnEditar.Visible = true;
                    btnInsertar.Visible = false;
                    btnNuevo.Visible = true;
                    lblAgregandoPresentacion.Text = "Detalles";
                    frmPresentacion formPresentacion = frmPresentacion.GetInstancia();
                    IdPresentacion = formPresentacion.IdPresentacion;
                    Presentacion = formPresentacion.Presentacion;
                    Descripcion = formPresentacion.Descripcion;
                    txtIdPresentacion.Text = Convert.ToString(IdPresentacion);
                    txtPresentacion.Text = Presentacion;
                    txtDescripcion.Text = Descripcion;
                    break;
                case 3: //CANCELAR
                    Habilitar(false);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblAgregandoPresentacion.Text = "Detalles";
                    txtIdPresentacion.Text = Convert.ToString(IdPresentacion);
                    txtPresentacion.Text = Presentacion;
                    txtDescripcion.Text = Descripcion;
                    break;
            }
        }
        #endregion

        //ICONOS DE NOTIFICACIÓN
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

        #region BOTÓN CANCELAR
        //BOTON CANCELAR - CLICK - DESHABILITA CONTROLES

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            HabilitarBotones();
            //dgvListado.Focus();
        }
        #endregion

        #region AGREGAR - EDITAR
        //BOTON NUEVO - CLICK - SOLO HABILITA Y LIMPIA CONTROLES -
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            HabilitarBotones();
            btnCancelar.Visible = true;
            Limpiar();
            txtPresentacion.SelectAll();
        }

        //BOTON EDITAR - CLICK - SOLO HABILITA CONTROLES
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }

        #region BOTÓN GUARDAR - INSERTA REGISTROS
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //IdPresentacion = Convert.ToInt32(txtIdPresentacion.Text);
            Presentacion = txtPresentacion.Text;
            Descripcion = txtDescripcion.Text;
            string agregarActualizar = "";
            if (Presentacion == string.Empty)
            {
                errorIcono.SetError(txtPresentacion, "Ingrese el nombre de la presentación.");
                txtPresentacion.SelectAll();
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            agregarActualizar = NegocioPresentacion.Insertar(Presentacion.Trim().ToUpper(),
                                Descripcion.Trim());
                            NotificacionOk("Presentación guardada", "Guardando"); // Aqui antes iba el método mensajeOk pero lo reemplacé por
                            //un icono de notificación
                            HabilitarBotones();
                            Limpiar();
                            txtPresentacion.SelectAll();
                            break;
                        case 1://EDITAR
                            agregarActualizar = NegocioPresentacion.Editar(IdPresentacion,
                                Presentacion.Trim().ToUpper(), Descripcion.Trim());
                            txtPresentacion.Enabled = false;
                            txtDescripcion.ReadOnly = true;
                            btnEditar.Visible = true;
                            btnInsertar.Visible = false;
                            NotificacionOk("Presentación modificada", "Modificando"); // Aqui antes iba el método mensajeOk pero lo reemplacé por
                            //un icono de notificación
                            break;
                        default:
                            MessageBox.Show(agregarActualizar);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                //Mostrar();
            }
        }
        #endregion

        #endregion

        private void frmIngresarPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }
    }
}