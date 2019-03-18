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
    public partial class frmIngresarCategoria : MaterialForm
    {
        frmCategoria formCategoria = new frmCategoria();
        public int ctrlSeleccionado = 0;
        //CONTENIDO DE DATAGRID
        public string IdCategoria;
        public string Categoria;
        public string Descripcion;

        ControlTeclado controlTeclado = new ControlTeclado();

        public frmIngresarCategoria()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        #region INSTANCIACION
        private static frmIngresarCategoria _Instancia;

        public static frmIngresarCategoria Instancia
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

        public static frmIngresarCategoria GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarCategoria();
            }
            return Instancia;
        }

        private void frmIngresarCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void frmIngresarCategoria_Load(object sender, EventArgs e)
        {
            HabilitarBotones(); // SelectAll() de MaterialSkin es el equivalente a Focus() de WindowsForms
        }

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

        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            txtIdCategoria.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        #region HABILITAR

        //HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtCategoria.Enabled = !valor;
            txtDescripcion.Enabled = !valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(false);
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = false;
                    IdCategoria = txtIdCategoria.Text;
                    Categoria = txtCategoria.Text;
                    Descripcion = txtDescripcion.Text;
                    lblCategoria.Text = "Nueva categoría";
                    txtCategoria.SelectAll();
                    break;
                case 1: //EDITAR
                    Habilitar(false);
                    btnInsertar.Enabled = false;
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    lblCategoria.Text = "Detalles";
                    txtCategoria.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(true);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    lblCategoria.Text = "Detalles";
                    txtIdCategoria.Text = IdCategoria;
                    txtCategoria.Text = Categoria;
                    txtDescripcion.Text = Descripcion;
                    break;
                case 3: //CANCELAR
                    Habilitar(true);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    txtCategoria.Text = Categoria;
                    txtDescripcion.Text = Descripcion;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblCategoria.Text = "Detalles";
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

        #region BOTÓN CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            txtIdCategoria.Text = IdCategoria;
            txtCategoria.Text = Categoria;
            txtDescripcion.Text = Descripcion;
            HabilitarBotones();
        }
        #endregion

        #region INSERTAR - EDITAR

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {

            //frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria(); Borrar?
            string agregarActualizar = "";
            if (txtCategoria.Text == string.Empty)
            {
                errorIcono.SetError(txtCategoria, "Ingrese el nombre de la categoría.");
                txtCategoria.SelectAll();
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            agregarActualizar = NegocioCategoria.Insertar(txtCategoria.Text.Trim().ToUpper(),
                                txtDescripcion.Text.Trim());
                            NotificacionOk("Categoría guardada correctamente", "Guardando");
                            HabilitarBotones();
                            txtCategoria.SelectAll();
                            Limpiar();
                            break;
                        case 1://EDITAR
                            agregarActualizar = NegocioCategoria.Editar(Convert.ToInt32(txtIdCategoria.Text),
                                txtCategoria.Text.Trim().ToUpper(),
                                txtDescripcion.Text.Trim());
                            txtCategoria.Enabled = false;
                            txtDescripcion.Enabled = false;
                            btnEditar.Visible = true;
                            btnInsertar.Visible = false;
                            btnCancelar.Visible = false;
                            btnNuevo.Visible = true;
                            NotificacionOk("Categoría editada correctamente", "Editando");
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
            }
        }
        #endregion

        #region BOTÓN GUARDAR
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarEditar();
        }
        #endregion

        #endregion

        #region TECLADO

        #endregion

        private void frmIngresarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }
        
    }
}