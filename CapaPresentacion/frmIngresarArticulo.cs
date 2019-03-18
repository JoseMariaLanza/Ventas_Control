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
using MaterialSkin.Controls;
using MaterialSkin;
using CapaPresentacion.Teclado;
using System.Globalization;

namespace CapaPresentacion
{
    public partial class frmIngresarArticulo : MaterialForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();
        Validacion.Validacion validaciones = new Validacion.Validacion();

        public int ctrlSeleccionado;
        public int IdArticulo;
        public string Codigo;
        public string Articulo;
        public int IdCategoria;
        public string Categoria;
        public decimal PrecioCompra;
        public decimal PrecioVenta;
        public decimal Stock;
        public int IdPresentacion;
        public string Presentacion;
        public string Descripcion;
        public string RutaImagen;
        
        public frmIngresarArticulo()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtArticulo, "Ingrese el nombre del artículo.");
            ttMensaje.SetToolTip(txtDescripcion, "Ingrese una descripcion para este artículo.");
            ttMensaje.SetToolTip(pbxImagen, "Seleccione una imagen para este artículo.");
            ttMensaje.SetToolTip(cmbCategoria, "Ingrese una categoría para este artículo.");
            ttMensaje.SetToolTip(cmbPresentacion, "Ingrese una presentación para este artículo.");
            ListaCategoria();
            ListaPresentacion();
            //HabilitarBotones();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmIngresarArticulo_Load(object sender, EventArgs e)
        {
            HabilitarBotones();
            btnCancelar.Visible = false;
        }

        #region INSTANCIACION
        private static frmIngresarArticulo _Instancia = null;

        public static frmIngresarArticulo Instancia
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

        public static frmIngresarArticulo GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarArticulo();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmIngresarArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region MOSTRAR
        #region HABILITAR
        //HABILITAR CONTROLES
        private void HabilitarCampos(bool valor)
        {
            txtCodigoBarras.Enabled = valor;
            txtArticulo.Enabled = valor;
            cmbCategoria.Enabled = valor;
            btnAgregarCategoria.Enabled = valor;
            txtPrecioCompra.Enabled = valor;
            txtPrecioVenta.Enabled = valor;
            //El stock no se podrá modificar desde aquí ya que es obligación que el ingreso correspondiente quede registrado
            cmbPresentacion.Enabled = valor;
            btnAgregarPresentacion.Enabled = valor;
            txtDescripcion.Enabled = valor;
            btnAgregarImagen.Enabled = valor;
            btnQuitarImagen.Enabled = valor;
            //Se toma decisión final de proporcionar posibilidad de modificar txtStock por situaciones especiales
            chkEditarStock.Enabled = valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    HabilitarCampos(true);
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    btnAgregarImagen.Enabled = true;
                    btnQuitarImagen.Enabled = true;
                    lblABMProducto.Text = "Nuevo artículo";
                    txtCodigoBarras.SelectAll();
                    break;
                case 1: //EDITAR
                    HabilitarCampos(true);
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    lblABMProducto.Text = "Detalles";
                    txtCodigoBarras.SelectAll();
                    break;
                case 2: //CONSULTAR
                    HabilitarCampos(false);
                    btnEditar.Visible = true;
                    btnInsertar.Visible = false;
                    btnNuevo.Visible = true;
                    btnAgregarImagen.Enabled = false;
                    btnQuitarImagen.Enabled = false;
                    lblABMProducto.Text = "Detalles";
                    txtIdArticulo.Text = Convert.ToString(IdArticulo);
                    txtCodigoBarras.Text = Codigo;
                    txtArticulo.Text = Convert.ToString(Articulo);
                    cmbCategoria.SelectedValue = IdCategoria;
                    cmbCategoria.Text = Categoria;
                    txtPrecioCompra.Text = Convert.ToString(PrecioCompra, CultureInfo.InvariantCulture);
                    txtPrecioVenta.Text = Convert.ToString(PrecioVenta, CultureInfo.InvariantCulture);
                    txtStock.Text = Convert.ToString(Stock);
                    cmbPresentacion.SelectedValue = IdPresentacion;
                    cmbPresentacion.Text = Presentacion;
                    txtDescripcion.Text = Descripcion;
                    pbxImagen.ImageLocation = RutaImagen;
                    pbxImagen.Image = Properties.Resources.Imagen_en_blanco;
                    break;
                case 3: //CANCELAR
                    HabilitarCampos(false);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    btnAgregarImagen.Enabled = false;
                    btnQuitarImagen.Enabled = false;
                    lblABMProducto.Text = "Detalles";
                    txtIdArticulo.Text = Convert.ToString(IdArticulo);
                    txtCodigoBarras.Text = Convert.ToString(Codigo);
                    txtArticulo.Text = Articulo;
                    cmbCategoria.SelectedValue = IdCategoria;
                    cmbCategoria.Text = Convert.ToString(Categoria);
                    txtPrecioCompra.Text = Convert.ToString(PrecioCompra);
                    txtPrecioVenta.Text = Convert.ToString(PrecioVenta);
                    txtStock.Text = Convert.ToString(Stock);
                    cmbPresentacion.SelectedValue = IdPresentacion;
                    cmbPresentacion.Text = Convert.ToString(Presentacion);
                    txtDescripcion.Text = Descripcion;
                    pbxImagen.ImageLocation = RutaImagen;
                    break;
            }
        }

        #endregion

        #region CATEGORIAS
        #region CARGA DE ITEMS EN LISTA
        //CARGA DE ITEMS AUTOCOMPLETE DESDE FUENTE - CATEGORIAS
        private AutoCompleteStringCollection ItemsCategoria()
        {
            DataTable listaItems = NegocioCategoria.Buscar(cmbCategoria.Text);
            AutoCompleteStringCollection cadenaCategoria = new AutoCompleteStringCollection();
            foreach (DataRow row in listaItems.Rows)
            {
                cadenaCategoria.Add(Convert.ToString(row["categoria"]));
            }
            return cadenaCategoria;
        }
        #endregion

        #region COMBOBOX
        //COMBOBOX CMBCATEGORIA
        private void ListaCategoria()
        {
            cmbCategoria.DataSource = NegocioCategoria.Mostrar();
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.SelectedValue = 0;
            AutocompletarCategoria();
        }
        #endregion

        #region METODO PARA AUTOCOMPLETAR COMBOBOX
        //METODO PARA AUTOCOMPLETAR COMBOBOX CATEGORIAS
        private void AutocompletarCategoria()
        {
            try
            {
                cmbCategoria.AutoCompleteCustomSource = ItemsCategoria();
                cmbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategoria.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region PRESENTACION

        #region CARGA DE ITEMS EN LISTA
        // CARGA DE ITEMS AUTOCOMPLETE EN FUENTE - PRESENTACION
        private AutoCompleteStringCollection ItemsPresentacion()
        {
            DataTable listaItems = NegocioPresentacion.Buscar(cmbPresentacion.Text);
            AutoCompleteStringCollection cadenaPresentacion = new AutoCompleteStringCollection();
            foreach (DataRow row in listaItems.Rows)
            {
                cadenaPresentacion.Add(Convert.ToString(row["Presentacion"]));
            }
            return cadenaPresentacion;
        }
        #endregion

        #region COMBOBOX
        //COMBOBOX CMBPRESENTACION
        private void ListaPresentacion()
        {
            cmbPresentacion.DataSource = NegocioPresentacion.Mostrar();
            cmbPresentacion.ValueMember = "IdPresentacion";
            cmbPresentacion.DisplayMember = "Presentacion";
            cmbPresentacion.SelectedValue = 0;
            AutocompletarPresentacion();
        }

        //ASIGNAR TEXTO DE COMBOBOX A "lblPresentacion"
        private void cmbPresentacion_TextChanged(object sender, EventArgs e)
        {

            lblPresentacion.Text = cmbPresentacion.Text;
        }
        #endregion

        #region METODO AUTOCOMPLETAR COMBOBOX
        //METODO PARA AUTOCOMPLETAR COMBOBOX PRESENTACION
        private void AutocompletarPresentacion()
        {
            try
            {
                cmbPresentacion.AutoCompleteCustomSource = ItemsPresentacion();
                cmbPresentacion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPresentacion.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
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

        #endregion

        #region LIMPIAR
        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            txtIdArticulo.Text = string.Empty;
            txtCodigoBarras.Text = string.Empty;
            txtArticulo.Text = string.Empty;
            cmbCategoria.SelectedValue = 0;
            txtPrecioCompra.Text = "0";
            txtPrecioVenta.Text = "0";
            txtStock.Text = "0";
            cmbPresentacion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            pbxImagen.Image = Properties.Resources.Imagen_en_blanco;
        }
        #endregion

        #region CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            HabilitarBotones();
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
            txtCodigoBarras.SelectAll();
        }

        //BOTON EDITAR - CLICK - SOLO HABILITA CONTROLES
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }

        #region METODO INSERTAR - EDITAR REGISTRO
        //METODO INSERTAR - EDITAR REGISTRO
        private void InsertarEditar()
        {
            //IdProducto = txtIdProducto.Text;
            Codigo = txtCodigoBarras.Text;
            Articulo = txtArticulo.Text;
            IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text, CultureInfo.InvariantCulture);
            PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text, CultureInfo.InvariantCulture);
            Stock = Convert.ToDecimal(txtStock.Text);
            IdPresentacion = Convert.ToInt32(cmbPresentacion.SelectedValue);
            Descripcion = txtDescripcion.Text;
            string agregarActualizar = "";
            //if (txtCodigoBarras.Text == string.Empty)
            //{
            //    errorIcono.SetError(txtCodigoBarras, "Ingrese el código");
            //    txtCodigoBarras.SelectAll();
            //}
            //else
            //{
                if (txtArticulo.Text == string.Empty)
                {
                    errorIcono.SetError(txtArticulo, "Ingrese el nombre del artículo.");
                    txtArticulo.SelectAll();
                }
                else
                {
                    if (IdCategoria == 0)
                    {
                        errorIcono.SetError(cmbCategoria, "Ingrese la categoría");
                        cmbCategoria.Focus();
                    }
                    else
                    {
                        if (IdPresentacion == 0)
                        {
                            errorIcono.SetError(cmbPresentacion, "Ingrese la presentación");
                            cmbPresentacion.Focus();
                        }
                        else
                        {
                            try
                            {
                                switch (ctrlSeleccionado)
                                {
                                    case 0://INSERTAR
                                        agregarActualizar = NegocioArticulo.Insertar(Codigo.Trim(), Articulo.Trim().ToUpper(), IdCategoria, 
                                            PrecioCompra, PrecioVenta, Stock, IdPresentacion, Descripcion.Trim(), RutaImagen);
                                        if (agregarActualizar.Equals("OK"))
                                        {
                                            NotificacionOk("Artículo guardado correctamente", "Guardando"); // Aqui antes iba el método mensajeOk pero lo reemplacé por
                                                                                                  //un icono de notificación
                                        }
                                        else
                                        {
                                            MessageBox.Show(agregarActualizar);
                                        }
                                        Limpiar();
                                        break;
                                    case 1://EDITAR
                                        agregarActualizar = NegocioArticulo.Editar(IdArticulo, Codigo.Trim(), Articulo.Trim().ToUpper(), IdCategoria,
                                            PrecioCompra, PrecioVenta, Stock, IdPresentacion, Descripcion.Trim(), RutaImagen);
                                        if (agregarActualizar.Equals("OK"))
                                        {
                                            NotificacionOk("Artículo modificado correctamente", "Modificando"); // Aqui antes iba el método mensajeOk pero lo reemplacé por
                                                                                                      //un icono de notificación
                                        }
                                        else
                                        {
                                            MessageBox.Show(agregarActualizar);
                                        }
                                        ctrlSeleccionado = 2;
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
                            frmArticulo formArticulo = frmArticulo.GetInstancia();
                            formArticulo.Mostrar();
                            HabilitarBotones();
                            errorIcono.Clear();
                        }
                    }
                }
            //}
        }
        #endregion

        #region BOTÓN GUARDAR - INSERTA Y EDITA REGISTROS
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarEditar();
        }
        #endregion

        #region BOTON AGREGAR/QUITAR IMAGEN
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                RutaImagen = dialog.FileName;
                pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                pbxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void desenlazarImagen()
        {
            pbxImagen.Image = Properties.Resources.Imagen_en_blanco;
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            desenlazarImagen();
        }
        #endregion

        #region BOTONES AGREGAR CATEGORIA - AGREGAR PRESENTACION
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            //btnAgregarCategoria.Enabled = false;
            frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria();
            //CAPTURADOR DE EVENTO FORMULARIO INGRESAR CATEGORIA CERRADO
            formIngresarCategoria.FormClosed += new FormClosedEventHandler(formIngresarCategoria_FormClosed);
            formIngresarCategoria.ShowDialog();
        }

        private void btnAgregarPresentacion_Click(object sender, EventArgs e)
        {
            //btnAgregarPresentacion.Enabled = false;
            frmIngresarPresentacion formIngresarPresentacion = frmIngresarPresentacion.GetInstancia();
            //CAPTURADOR DE EVENTO FORMULARIO PRESENTACION CERRADO
            formIngresarPresentacion.FormClosed += new FormClosedEventHandler(formIngresarPresentacion_FormClosed);
            formIngresarPresentacion.ShowDialog();
        }

        //EVENTO CERRANDO FORMULARIO INGRESARCATEGORIA
        private void formIngresarCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListaCategoria();
            btnAgregarCategoria.Enabled = true;
        }

        //EVENTO CERRANDO FORMULARIO PRESENTACION
        private void formIngresarPresentacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListaPresentacion();
            btnAgregarPresentacion.Enabled = true;
        }
        #endregion

        #endregion

        #region CONTROL TECLADO

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
            validaciones.IngresarNumeroDecimal(e);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
            validaciones.IngresarNumeroDecimal(e);
        }

        #endregion

        private void frmIngresarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
            //controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void chkEditarStock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditarStock.Checked)
            {
                txtStock.Enabled = true;
            }
            else
            {
                txtStock.Enabled = false;
            }
        }
    }
}
