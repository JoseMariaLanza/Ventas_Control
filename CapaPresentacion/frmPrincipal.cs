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
using DevComponents;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Controls;
//using DevComponents.DotNetBar.Rendering;
//using DevComponents.DotNetBar.Metro.ColorTables;
//using DevComponents.DotNetBar.Metro.Rendering;
using CapaPresentacion.Properties;
using System.Globalization;
using CapaPresentacion.Modulos.Facturacion;
using System.Reflection;

namespace CapaPresentacion
{
    public partial class frmPrincipal : MetroForm
    {
        int AnchoExp= 334;
        const int diferencia = 109;
        int AreaTrabajo = Screen.PrimaryScreen.WorkingArea.Width;
        bool SideNavMaximizado = false;

        #region GASTOS
        int IdGasto;
        bool Edit;
        #endregion

        //public decimal totalVentas = 0; // MÉTODO NO CONFIABLE PARA HACER EL CÁLCULO DE LAS VENTAS DEL DÍA


        public int IdEmpleado;
        public string Apellido;
        public string Nombre;
        public string Acceso;
        private bool CambiarUsuario = false;
        DateTime Ahora = new DateTime();

        frmNota formNota = new frmNota();
        
        public frmPrincipal()
        {
            InitializeComponent();
            #region CAMBIA EL COLOR DEL FORMULARIO MDI Y SUS CONTROLES, INCLUSO EL GRIS DONDE SE ALOJARAN LOS MDICHILD
            //MdiClient ctlMDI;
            //foreach (Control ctl in this.Controls)
            //{
            //    try
            //    {
            //        // Attempt to cast the control to type MdiClient.
            //        ctlMDI = (MdiClient)ctl;
            //
            //        // Set the BackColor of the MdiClient control.
            //        ctlMDI.BackColor = Color.FromArgb(64, 64, 64);
            //    }
            //    catch (InvalidCastException exc)
            //    {
            //        // Catch and ignore the error if casting failed.
            //    }
            //}
            #endregion

            #region CAMBIA EL COLOR DE LOS CONTROLES METRO
            //Office2007ColorTable table = ((Office2007Renderer)GlobalManager.Renderer).ColorTable;
            //SideNavColorTable ct = table.SideNav;
            //ct.TitleBackColor = Color.FromArgb(64, 64, 64);
            //ct.SideNavItem.MouseOver.BackColors = new Color[] { Color.Red, Color.Yellow };
            //ct.SideNavItem.MouseOver.BackColors = new Color[] { Color.White, Color.White };
            //ct.SideNavItem.MouseOver.TextColor = Color.Black;
            //ct.SideNavItem.MouseOver.BorderColors = new Color[0]; // No border
            //ct.SideNavItem.Selected.BackColors = new Color[] { Color.White };
            //ct.SideNavItem.Selected.TextColor = Color.Black;
            //ct.BorderColors = new Color[] { Color.FromArgb(64,64,64) }; // Control border color
            //ct.PanelBackColor = Color.FromArgb(64, 64, 64);
            //ct.TitleBorderColors = new Color[] { Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64) };
            //snMenu.BackColor = Color.FromArgb(64, 64, 64);
            //snMenu.UpdateColors();

            //MetroColorTable tabla = MetroRender.GetColorTable();
            //tabla.BaseColor = Color.FromArgb(64, 64, 64);
            //tabla.EditControlBackColor = Color.FromArgb(64, 64, 64);
            //tabla.MetroTab.ActiveCaptionText = Color.Green;
            //tabla.MetroTab.InactiveCaptionText = Color.Red;

            // CAMBIA EL COLOR GLOBAL DE TODOS LOS FORMULARIOS - SE LO INCLUYE EN EL FORMULARIO LOGIN YA QUE ES EL PRIMER FORMULARIO QUE SE INICIA
            //StyleManager.MetroColorGeneratorParameters = new MetroColorGeneratorParameters(Color.FromArgb(64, 64, 64), Color.FromArgb(64,64,64));
            #endregion
            CargarConfiguracion();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //AsignarVariablesConfiguracionPrincipal();
            CargarConfiguracion();
            snMenu.EnableMaximize = false;
            Ahora = DateTime.Now;
            //CargarConfiguracion();
            decimal stockminimo = Convert.ToDecimal(nudEstablecerStockMinimo.Value, CultureInfo.InvariantCulture);
            Mostrar(stockminimo);
            MostrarDeudores();
            Permisos();
            UsuarioLogueado();
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            // NO HACE FALTA ASIGNAR UN TAMAÑO MÍNIMO YA QUE SE DESHABILITÓ EL SPLITTER DE snMenu
            //snMenu.MinimumSize = new Size(229, snMenu.Height);
            //snMenu.MaximumSize = new Size(229, snMenu.Height);
            // SE ESTABLECE EL TAMAÑO MÁXIMO A LA MITAD DEL ÁREA DE TRABAJO (área que ocupa el formulario en la pantalla)
            //snMenu.MaximumSize = new Size(AreaTrabajo/2, snMenu.Height);
            Mostrar();
            Longitud();
            ComprobarAperturaPendiente();
            ListaCajas();
            ListaAperturasPredefinidas();
            AperturaAutomatica();
            CargarControles();
        }

        #region DESHABILITAR COPIAR Y PEGAR DESDE TECLADO - DESHABILITADO
        //// Constants
        //private const Keys CopyKeys = Keys.Control | Keys.C;
        //private const Keys PasteKeys = Keys.Control | Keys.V;
        //
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if ((keyData == CopyKeys) || (keyData == PasteKeys))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return base.ProcessCmdKey(ref msg, keyData);
        //    }
        //}
        #endregion

        #region METODOS DE APERTURAS PREDEFINIDAS
        Apertura Aperturas = new Apertura();
        public int IdAperturaCierre;
        public bool AdministrarCierreCaja;
        public bool ForzarCierre;

        #region CONTROL DE CIERRE DE CAJA

        public void formCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            PreguntarSalirSinCerrarCaja(e);
        }

        private void PreguntarSalirSinCerrarCaja(FormClosingEventArgs e)
        {
            if (!ForzarCierre)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Realmente desea salir sin cerrar la caja?.", "CANCELANDO CIERRE DE CAJA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        public void ComprobarAperturaPendiente()
        {
            if (Acceso == "Administrador" || Acceso == "Encargado")
            {
                //AdministrarCierreCaja = true;
                Aperturas.ComprobarAperturaPendiente(Configuracion, FechaHoraApertura);
            }
        }

        private void ForzarAperturaPorDefecto()
        {
            //if (!CajaAbierta && !AbrirCaja && ) CONTINUAR...
        }

        public void CancelarAperturaAutomatica()
        {
            AbrirCaja = false;
            IdAperturaPredefinida = 0; // No es necesaria pero bue...
            GuardarConfiguracion();
            CargarConfiguracion();
        }

        #region FORZAR CIERRE DE CAJA ABIERTA
        public void ForzarCierreCaja(frmCierreCaja formCierreCaja)
        {
            formCierreCaja.IdCaja = IdCaja;
            formCierreCaja.IdAperturaCierre = IdAperturaCierre;
            formCierreCaja.FormClosing += new FormClosingEventHandler(formCierreCaja_FormClosing);
            formCierreCaja.ShowDialog();
            formCierreCaja.BringToFront();
        }
        #endregion
        #endregion

        #region INSTANCIACION
        private static frmPrincipal _Instancia = null;

        public static frmPrincipal Instancia
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

        public static frmPrincipal GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmPrincipal();
            }
            return Instancia;
        }

        private void frmPrincipal_Disposed(object sender, EventArgs e)
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

        #region LOGIN
        private void sniCambiarUsuario_Click(object sender, EventArgs e)
        {
            CambiarUsuario = true;
            try
            {
                frmLogin formLogin = frmLogin.GetInstancia();
                formLogin.MdiParent = this;
                formLogin.btnSalir.Enabled = false;
                formLogin.btnIngresar.Text = "Aceptar";
                formLogin.ControlBox = false;
                formLogin.btnCancelar.Visible = true;
                formLogin.btnIngresar.Click += new EventHandler(formLogin_btnIngresarCliek);
                formLogin.Visible = true;
                formLogin.BringToFront();
                //formLogin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void formLogin_btnIngresarCliek(object sender, EventArgs e)
        {
            Permisos();
            UsuarioLogueado();
        }
        #endregion

        #region USUARIOS
        private void Permisos()
        {
            if (Acceso == "Administrador")
            {
                sniCompras.Enabled = true;
                sniSistema.Enabled = true;
                sniConfiguracion.Enabled = true;
                sniFacturacion.Enabled = true;
                btnAgregarNota.Enabled = true;
                btnArqueoCajas.Enabled = true;
                btnRestablecerPrimerInicio.Enabled = true;
                if (CargarNotas() && CambiarUsuario == false)
                {
                    MostrarNota();
                }
            }
            else if (Acceso == "Encargado")
            {
                sniCompras.Enabled = true;
                sniSistema.Enabled = true;
                sniConfiguracion.Enabled = true;
                sniFacturacion.Enabled = true;
                btnAgregarNota.Enabled = true;
                btnArqueoCajas.Enabled = true;
                btnRestablecerPrimerInicio.Enabled = false;
                if (CargarNotas() && CambiarUsuario == false)
                {
                    MostrarNota();
                }
            }
            else if (Acceso == "Vendedor")
            {
                sniCompras.Enabled = false;
                sniConfiguracion.Enabled = false;
                sniSistema.Enabled = false;
                sniFacturacion.Enabled = false;
                btnAgregarNota.Enabled = true;
                btnArqueoCajas.Enabled = false;
                btnRestablecerPrimerInicio.Enabled = false;
                if (CargarNotas() && CambiarUsuario == false)
                {
                    MostrarNota();
                }
                sniFacturacion.RaiseClick();
            }
            else
            {
                sniCompras.Enabled = false;
                sniConfiguracion.Enabled = false;
                sniSistema.Enabled = false;
                sniFacturacion.Enabled = false;
                btnAgregarNota.Enabled = false;
                snMenu.Visible = false;
                btnVender.Enabled = false;
                btnRestablecerPrimerInicio.Enabled = false;
            }
        }

        //DATOS USUARIO
        private void UsuarioLogueado()
        {
            lblTrabajador.Text = Apellido + ", " + Nombre;
            lblIdTrabajador.Text = Convert.ToString(IdEmpleado);
            lblUsuario.Text = "No disponible";
            lblAcceso.Text = Acceso;
        }
        #endregion

        #region NOTA

        #region CARGA DE NOTAS
        private bool CargarNotas()
        {
            int registros;
            registros = NegocioNota.Contar();
            if (registros <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CREAR NOTA
        private void CrearNota()
        {
            frmNota formNota = new frmNota();
            formNota.MdiParent = this;
            formNota.StartPosition = FormStartPosition.CenterScreen;
            formNota.Show();
        }
        #endregion

        #region MOSTRAR NOTA
        private void MostrarNota()
        {
            DataTable registroNota = NegocioNota.Mostrar();
            foreach (DataRow row in registroNota.Rows)
            {
                int idnota = Convert.ToInt32(row[0]);
                string nota = Convert.ToString(row[1]);
                int posx = Convert.ToInt32(row[2]);
                int posy = Convert.ToInt32(row[3]);
                int ancho = Convert.ToInt32(row[4]);
                int alto = Convert.ToInt32(row[5]);
                frmNota formNota = new frmNota();
                formNota.MdiParent = this;
                formNota.CargarNota(idnota, nota, posx, posy, ancho, alto);
                formNota.StartPosition = FormStartPosition.Manual;
                Point ubicacion = new Point(posx, posy);
                Size tamaño = new Size(ancho, alto);
                formNota.Location = ubicacion;
                formNota.Size = tamaño;
                formNota.Show();
            }
        }
        #endregion

        #region CREAR FORM NOTA
        private void ShowNewForm(object sender, EventArgs e)
        {
            CrearNota();
        }
        #endregion

        #endregion

        #region CODIGO AUTOGENERADO
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name != formNota.Name)
                {
                    childForm.Close();
                }
            }
        }
        #endregion

        #region MINIMIZAR
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region ARTICULO
        private void mtiArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                frmArticulo formArticulo = frmArticulo.GetInstancia();
                formArticulo.MdiParent = this;
                formArticulo.Show();
                formArticulo.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region CATEGORIA
        private void mtiCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                frmCategoria formCategoria = frmCategoria.GetInstancia();
                formCategoria.MdiParent = this;
                formCategoria.Show();
                formCategoria.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region PRESENTACION
        private void mtiPresentacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmPresentacion formPresentacion = frmPresentacion.GetInstancia();
                formPresentacion.MdiParent = this;
                formPresentacion.Show();
                formPresentacion.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region EMPLEADOS
        private void mtiEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmpleados formEmpleados = frmEmpleados.GetInstancia();
                formEmpleados.MdiParent = this;
                formEmpleados.Show();
                formEmpleados.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region CLIENTE
        private void mtiCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmCliente formCliente = frmCliente.GetInstancia();
                formCliente.MdiParent = this;
                formCliente.Show();
                formCliente.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region DEUDORES
        private void mtiDeudores_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeudores formDeudores = frmDeudores.GetInstancia();
                formDeudores.MdiParent = (this);
                formDeudores.Show();
                formDeudores.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region PROVEEDOR
        private void mtiProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedor formProveedor = frmProveedor.GetInstancia();
                formProveedor.MdiParent = this;
                formProveedor.Show();
                formProveedor.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region INGRESO
        private void mtiIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                frmIngreso formIngreso = frmIngreso.GetInstancia();
                formIngreso.MdiParent = this;
                formIngreso.Show();
                formIngreso.BringToFront();
                formIngreso.IdEmpleado = IdEmpleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region PROMO/DESCUENTOS
        private void mtiPromociones_Click(object sender, EventArgs e)
        {
            try
            {
                frmPromoDescuento formPromoDescuento = frmPromoDescuento.GetInstancia();
                formPromoDescuento.MdiParent = this;
                formPromoDescuento.Show();
                formPromoDescuento.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region VENTAS
        private void btnVender_Click(object sender, EventArgs e)
        {
            Vender();
        }

        private void mtiVentas_Click(object sender, EventArgs e)
        {
            frmVenta formVenta = frmVenta.GetInstancia();
            formVenta.MdiParent = (this);
            formVenta.Show();
            formVenta.BringToFront();
        }
        
        private void snibtnVentas_Click(object sender, EventArgs e)
        {
            Vender();
        }

        private void Vender()
        {
            if (CajaAbierta)//(Configuracion.IdCaja)//(Configuracion.IdApertura > 0)
            {
                frmIngresarVenta formIngresarVenta = frmIngresarVenta.GetInstancia();
                formIngresarVenta.Show();
                formIngresarVenta.BringToFront();
            }
            else
            {
                MessageBox.Show("Debe abrir una caja antes de poder empezar a vender.", "AVISO:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region CAJAS
        private void sniCajas_Click(object sender, EventArgs e)
        {
            frmCaja formCaja = frmCaja.GetInstancia();
            formCaja.MdiParent = (this);
            formCaja.Show();
            formCaja.BringToFront();
        }
        #endregion

        #region BOTON SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Realmente desea salir del sistema?",
                "Saliendo del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void sniSalir_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Realmente desea salir del sistema?",
                "Saliendo del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region GASTOS

        #region MOSTRAR
        private void Mostrar()
        {
            dgvGastos.DataSource = NegocioGastos.Mostrar();
        }
        #endregion

        #region INSERTAR
        private void Insertar(string concepto, string descripcion, decimal monto, string periodo, DateTime fecha)
        {
            try
            {
                string respuesta = NegocioGastos.Insertar(concepto, descripcion, monto, periodo, fecha);
                if (respuesta.Equals("OK"))
                {
                    NotificacionOk("Gasto guardado correctamente", "Guardando");
                    Limpiar();
                }
                else
                {
                    NotificacionError("El gasto no se pudo guardar", "Error");
                }
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción capturada: " + ex.Message + " Trace: " + ex.StackTrace);
            }
        }
        #endregion

        #region EDITAR
        private void Editar(int idgasto, string concepto, string descripcion, decimal monto, string periodo, DateTime fecha)
        {
            try
            {
                string respuesta = NegocioGastos.Editar(idgasto, concepto, descripcion, monto, periodo, fecha);
                if (respuesta.Equals("OK"))
                {
                    NotificacionOk("Gasto editado correctamente", "Editando");
                    Limpiar();
                }
                else
                {
                    NotificacionError("El gasto no se pudo editar", "Error");
                    MessageBox.Show(respuesta);
                }
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción capturada: " + ex.Message + " Trace: " + ex.StackTrace);
            }
        }
        #endregion

        #region ELIMINAR
        private void Eliminar(int idgasto)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Está seguro que desea eliminar este gasto?.",
                    "Eliminando gasto registrado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    string respuesta = NegocioGastos.Eliminar(idgasto);
                    if (respuesta.Equals("OK"))
                    {
                        NotificacionOk("Gasto eliminado correctamente", "Eliminando");
                        Limpiar();
                    }
                    else
                    {
                        NotificacionError("El gasto no se pudo eliminar", "Error");
                    }
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción capturada: " + ex.Message + " Trace: " + ex.StackTrace);
            }
        }
        #endregion
        #endregion
        
        private void tTiempoLogueado_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
            TimeSpan tiempoLogueado = new TimeSpan(DateTime.Now.Ticks - Ahora.Ticks);
            lblTiempoLogueado.Text = tiempoLogueado.ToString(@"dd\.hh\:mm\:ss");
            AperturaAutomatica();
        }

        #region VALIDACIÓN DE CAMPOs
        private bool Validar(string concepto, string descripcion, decimal monto, string periodo, DateTime fecha)
        {
            if (txtConcepto.Text != string.Empty || nudMonto.Value > 0 || cmbPeriodo.Text != string.Empty || dtpFecha.Value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ESTILO
        #region MANEJO DE DIMENSIONES DEL SIDENAV

        private void sniSistema_Click(object sender, EventArgs e)
        {
            snMenu.MaximumSize = new Size(AreaTrabajo / 2, snMenu.Height);
            snMenu.EnableMaximize = false;
            AnchoExp = 334;
            if (!(snMenu.IsMenuExpanded))
            {
                snMenu.Width = AnchoExp - diferencia;
            }
            else
            {
                snMenu.Width = AnchoExp;
            }

            #region CÓDIGO PARA MAXIMIZAR EL TAPPAGE - SI FUNCA
            //if (SideNavMaximizado)
            //{
            //    snMenu.Maximize((eEventSource)MouseButtons.Left);
            //    snMenu.Width = AreaTrabajo / 2;
            //}
            //else
            //{
            //    if (!(snMenu.Width == AreaTrabajo / 2))
            //    {
            //        MessageBox.Show("Ingreso a la condición");
            //        snMenu.Width = DeterminarAnchoNoExp(AnchoExp);
            //    }
            //}
            #endregion
        }

        private void sniCompras_Click(object sender, EventArgs e)
        {
            snMenu.EnableMaximize = false;
            AnchoExp = 334;
            if (!(snMenu.IsMenuExpanded))
            {
                snMenu.Width = AnchoExp - diferencia;
            }
            else
            {
                snMenu.Width = AnchoExp;
            }
            //if (!(snMenu.Width == Screen.PrimaryScreen.WorkingArea.Width / 2))
            //{
            //    snMenu.Width = DeterminarAnchoNoExp(AnchoExp);
            //}
        }

        private void sniVentas_Click(object sender, EventArgs e)
        {
            snMenu.EnableMaximize = false;
            AnchoExp = 334;
            if (!(snMenu.IsMenuExpanded))
            {
                snMenu.Width = AnchoExp - diferencia;
            }
            else
            {
                snMenu.Width = AnchoExp;
            }
            //if (!(snMenu.Width == AreaTrabajo / 2))
            //{
            //    snMenu.Width = DeterminarAnchoNoExp(AnchoExp);
            //}
        }

        #region CONFIGURACIÓN
        private void sniConfiguracion_Click(object sender, EventArgs e)
        {
            snMenu.MaximumSize = new Size(AreaTrabajo, snMenu.Height);
            snMenu.EnableMaximize = true;

            if (SideNavMaximizado)
            {
                snMenu.Maximize((eEventSource)MouseButtons.Left);
                snMenu.Width = AreaTrabajo;
            }
            else
            {
                AnchoExp = 720;
                if (!(snMenu.IsMenuExpanded))
                {
                    snMenu.Width = AnchoExp - diferencia;
                }
                else
                {
                    snMenu.Width = AnchoExp;
                }
            }
        }

        #region PINTAR CELDAS DE TABLE LAYOUTPANEL
        private void pintarCeldas_CellPaint(TableLayoutPanel control, TableLayoutCellPaintEventArgs e)
        {
            for (int i = 0; i <= control.ColumnCount; i++)
            {
                for (int j = 0; j <= control.RowCount; j++)
                {
                    using (SolidBrush brush = new SolidBrush(Color.WhiteSmoke))
                        e.Graphics.FillRectangle(brush, e.ClipRectangle);
                }
            }
        }

        // EVENTO CELLPAINT DE TABLE LAYOUTPANEL
        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutPanel tlPanel = sender as TableLayoutPanel;
            pintarCeldas_CellPaint(tlPanel, e);
        }
        #endregion
        #endregion

        private void sniAcercaDe_Click(object sender, EventArgs e)
        {
            snMenu.EnableMaximize = false;
            AnchoExp = 600;
            if (!(snMenu.IsMenuExpanded))
            {
                snMenu.Width = AnchoExp - diferencia;
            }
            else
            {
                snMenu.Width = AnchoExp;
            }
            //if (!(snMenu.Width == AreaTrabajo / 2))
            //{
            //    snMenu.Width = DeterminarAnchoNoExp(AnchoExp);
            //}
        }

        private void snMostrarNombres_Click(object sender, EventArgs e)
        {
            if (!(snMenu.Width == AreaTrabajo / 2)) // Si el ancho del menú es distinto al área de trabajo dividido en 2
            {
                if (!snMenu.IsClosed) // Si el menú está abierto
                {
                    snMenu.Width = Redimensionar(snMenu.Width);
                }
            }
        }

        // Redimensiona el menú (snMenu) al momento de hacer click en el botón snMostrarNombres
        private int Redimensionar(int ancho)
        {
            if (snMenu.Width != AreaTrabajo)
            {
                if (snMenu.IsMenuExpanded)
                {
                    ancho += diferencia;
                }
                else
                {
                    ancho -= diferencia;
                }
            }
            return ancho;
        }

        // Determinar el ancho del menú (snMenu) al momento de hacer click en los TapPages si el menú no está expandido
        private int DeterminarAnchoNoExp(int anchoExp)
        {
            if (!snMenu.IsMenuExpanded && (anchoExp == 334 || anchoExp == 632))
            {
                anchoExp -= diferencia;
            }
            return anchoExp;
        }
        #endregion

        #region COLOR DE MENUSTRIP
        private void menuStrip1_BackColorChanged(object sender, EventArgs e)
        {
            if (menuStrip1.BackColor != Color.FromArgb(1, 69, 79))
            {
                menuStrip1.BackColor = Color.FromArgb(1, 69, 79);
            }
        }

        #endregion
        #endregion

        private void snMenu_BeforeMaximize(object sender, CancelSourceEventArgs e)
        {
            SideNavMaximizado = true;
        }

        private void snMenu_BeforeRestore(object sender, CancelSourceEventArgs e)
        {
            SideNavMaximizado = false;
        }

        #region HABLITACIÓN DE CAMPOS DE GASTOS
        private void Habilitar(bool valor)
        {
            txtConcepto.Enabled = valor;
            nudMonto.Enabled = valor;
            cmbPeriodo.Enabled = valor;
            rtxtDescripcion.Enabled = valor;
            dtpFecha.Enabled = valor;
        }
        #endregion

        // Sobrecarga 1, habilita los cuadros de números de la configuración
        private void Habilitar(bool stockMinimo, bool recordarPagos)
        {
            if (stockMinimo)
            {
                nudEstablecerStockMinimo.Enabled = true;
            }
            if (recordarPagos)
            {
                nudDiasPagos.Enabled = true;
            }
        }

        private void Limpiar()
        {
            txtIdGasto.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            nudMonto.Value = 0;
            cmbPeriodo.Text = string.Empty;
            rtxtDescripcion.Text = string.Empty;
            dtpFecha.Value = DateTime.Now;
        }

        #region LONGITUD DE CAMPOS
        private void Longitud()
        {
            txtConcepto.MaxLength = 45;
            rtxtDescripcion.MaxLength = 255;
        }
        #endregion

        #region AGREGAR NUEVO GASTO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            Limpiar();
            btnAgregar.SendToBack();
            btnAgregar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGuardarGasto.Enabled = true;
        }
        #endregion

        #region BOTÓN CANCELAR AGREGAR NUEVO GASTO Y EDICIÓN
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            btnCancelar.SendToBack();
            btnCancelar.Enabled = false;
            btnAgregar.Enabled = true;
            btnGuardarGasto.Enabled = false;
        }
        #endregion

        #region BOTÓN INSERTAR NUEVO GASTO
        private void btnGuardarGasto_Click(object sender, EventArgs e)
        {
            if (Validar(txtConcepto.Text.Trim().ToUpper(), rtxtDescripcion.Text, Convert.ToDecimal(nudMonto.Value), cmbPeriodo.Text, dtpFecha.Value))
            {
                if (Edit)
                {
                    Editar(Convert.ToInt32(txtIdGasto.Text), txtConcepto.Text.Trim().ToUpper(), rtxtDescripcion.Text, Convert.ToDecimal(nudMonto.Value), cmbPeriodo.Text, dtpFecha.Value);// + DateTime.Now.TimeOfDay);
                }
                else
                {
                    Insertar(txtConcepto.Text.Trim().ToUpper(), rtxtDescripcion.Text, Convert.ToDecimal(nudMonto.Value), cmbPeriodo.Text, dtpFecha.Value);// + DateTime.Now.TimeOfDay);
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Habilitar(false);
            btnGuardarGasto.Enabled = false;
        }
        #endregion

        #region BOTÓN EDITAR GASTO
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            Edit = true;
            btnGuardarGasto.Enabled = true;
        }
        #endregion

        #region BOTÓN ELIMINAR GASTO
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdGasto != 0)
            {
                Eliminar(IdGasto);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar", "Error");
            }
        }
        #endregion

        #region DATAGRIDVIEW GASTOS
        private void dgvGastos_Click(object sender, EventArgs e)
        {
            try
            {
                txtIdGasto.Text = Convert.ToString(dgvGastos.CurrentRow.Cells["idgasto"].Value);
                IdGasto = Convert.ToInt32(txtIdGasto.Text);
                txtConcepto.Text = Convert.ToString(dgvGastos.CurrentRow.Cells["concepto"].Value);
                nudMonto.Text = Convert.ToString(dgvGastos.CurrentRow.Cells["monto"].Value);
                cmbPeriodo.Text = Convert.ToString(dgvGastos.CurrentRow.Cells["periodo"].Value);
                rtxtDescripcion.Text = Convert.ToString(dgvGastos.CurrentRow.Cells["descripcion"].Value);
                dtpFecha.Text = Convert.ToString(dgvGastos.CurrentRow.Cells["fecha"].Value);
            }
            catch { }
            btnCancelar.Enabled = false;
            btnGuardarGasto.Enabled = false;
            btnAgregar.Enabled = true;
            btnAgregar.BringToFront();
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            Habilitar(false);
        }
        #endregion

        #region CONFIGURACIÓN

        #region CONTROL DE STOCK
        private void chkEstablecerMinimo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstablecerMinimo.Checked)
            {
                nudEstablecerStockMinimo.Enabled = true;
            }
            else
            {
                nudEstablecerStockMinimo.Enabled = false;
            }
        }

        private void chkRecordarReponer_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region EMPLEADOS
        private void chkMostrarMensajeCumpleanios_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkEditarMensajeCumpleanios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditarMensajeCumpleanios.Checked)
            {
                rtxtMensajeCumpleanios.Enabled = true;
                btnAgregarImagen.Enabled = true;
                btnQuitarImagen.Enabled = true;
            }
            else
            {
                rtxtMensajeCumpleanios.Enabled = false;
                btnAgregarImagen.Enabled = false;
                btnQuitarImagen.Enabled = false;
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pbxImagen.ImageLocation = dialog.FileName;
                pbxImagen.SizeMode = PictureBoxSizeMode.Zoom;
                pbxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            pbxImagen.Image = Properties.Resources.Imagen_en_blanco;
        }

        #endregion

        #region SISTEMA
        private void chkRecordarDeudores_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPermitirNuevasDeudas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkRecordarPagos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecordarPagos.Checked)
            {
                nudDiasPagos.Enabled = true;
            }
            else
            {
                nudDiasPagos.Enabled = false;
            }
        }

        //#region ASIGNAR VALORES DE CONFIGURACION A VARIABLES DE SISTEMA
        //private void AsignarVariablesConfiguracionPrincipal()
        //{
        //    IdCaja = Configuracion.IdCaja;
        //}
        //#endregion

        #region LLENADO DE COMBOBOX CAJAS
        private void ListaCajas()
        {
            cmbCajas.DataSource = NegocioCaja.Mostrar();
            cmbCajas.ValueMember = "IdCaja";
            cmbCajas.DisplayMember = "Caja";
            cmbCajas.SelectedValue = IdCaja;
        }
        #endregion

        #region LLENADO DE COMBOBOX APERTURAS
        private void ListaAperturasPredefinidas()
        {
            cmbAperturasPredefinidas.DataSource = NegocioApertura.MostrarAperturasPredefinidas();
            cmbAperturasPredefinidas.ValueMember = "IdAperturaPredefinida";
            cmbAperturasPredefinidas.DisplayMember = "Descripcion";
            cmbCajas.SelectedValue = IdAperturaPredefinida;
        }
        #endregion

        #region COMPROBAR CAJA ABIERTA

        #region ABRIR CAJA AUTOMÁTICAMENTE
        private void AperturaAutomatica()
        {
            if (AbrirCaja && DateTime.Now >= FechaHoraApertura && !CajaAbierta)
            {
                //Código para insertar la apertura de la caja
                string resultado = "";
                try
                {
                    dtApertura = NegocioApertura.BuscarAperturaPredefinida(IdAperturaPredefinida);
                    DataRow row = dtApertura.Rows[0];
                    int idAperturaPredefinida = Convert.ToInt32(row["IdAperturaPredefinida"]);
                    decimal montoInicial = Convert.ToDecimal(row["MontoInicial"]);
                    DataTable dtDetalleApertura = NegocioDetalleApertura.MostrarDetallesAperturaPredefinida(idAperturaPredefinida);
                    resultado = NegocioApertura.Insertar(IdCaja, IdEmpleado, DateTime.Now, montoInicial, dtDetalleApertura, "ABIERTA", ref IdAperturaCierre);
                    if (resultado.Equals("OK"))
                    {
                        NotificacionOk("La caja se abrió exitosamente", "Apertura automática");
                        CajaAbierta = true;
                        AbrirCaja = false;
                        GuardarConfiguracion();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.StackTrace);
                }
            }
        }
        #endregion

        #endregion

        #region BOTÓN GUARDAR CONFIGURACIÓN
        private void btnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
        }
        #endregion

        #region GUARDAR CONFIGURACIÓN
        public void GuardarConfiguracion()
        {
            Configuracion.EstablecerStockMinimo = chkEstablecerMinimo.Checked;
            Configuracion.StockMinimo = Convert.ToDecimal(nudEstablecerStockMinimo.Value);
            Configuracion.RecordarReponer = chkRecordarReponer.Checked;

            Configuracion.MostrarMensajeCumpleanios = chkMostrarMensajeCumpleanios.Checked;
            Configuracion.MensajeCumpleanios = rtxtMensajeCumpleanios.Text;
            Configuracion.RutaImgenCumpleanios = pbxImagen.ImageLocation;
            Configuracion.RecordarDeudores = chkRecordarDeudores.Checked;
            Configuracion.PermitirNuevasDeudas = chkPermitirNuevasDeudas.Checked;
            Configuracion.RecordarPagos = chkRecordarPagos.Checked;
            Configuracion.DiasAnticipacion = nudDiasPagos.Value;
            Configuracion.AbrirCaja = AbrirCaja;
            Configuracion.IdCaja = IdCaja;//Convert.ToInt32(cmbCajas.SelectedValue);
            Configuracion.IdAperturaPredefinida = IdAperturaPredefinida;
            Configuracion.IdAperturaCierre = IdAperturaCierre;
            Configuracion.CajaAbierta = CajaAbierta;
            Configuracion.FechaHoraApertura = FechaHoraApertura;
            Configuracion.AbrirCajaSiempre = AbrirCajaSiempre;
            Configuracion.Save();
        }
        #endregion

        #region CARGAR CONFIGURACIÓN

        #region VARIABLES FORMULARIO-CONFIGURACION

        // AUTOMATIZACION DE APERTURA DE CAJAS EN Properties.Settings.settings
        Settings Configuracion = new Settings();
        public bool EstablecerStockMinimo;
        public double StockMinimo;
        public bool RecordarReponer;
        public bool MostrarMensajeCumpleanios;
        public string MensajeCumpleanios;
        public string RutaImagenCumpleanios;
        public bool RecordarDeudores;
        public bool PermitirNuevasDeudas;
        public bool RecordarPagos;
        public int DiasAnticipacion;
        //APERTURA AUTOMÁTICA
        DataTable dtApertura = new DataTable();
        public bool AbrirCaja;
        public int IdCaja;
        public int IdAperturaPredefinida;
        public bool CajaAbierta;
        public DateTime FechaHoraApertura;
        //public string FechaHoraAperturaString; // se define para poder llamarla desde otro formulario ya que la variable FechaHoraApertura
        // es invocada por referencia, lo que produce un error en tiempo de ejecución y un error de lógica al tener un valor nulo.
        // el error provoca que no se pueda ingresar una venta aunque la caja esté abierta y la imposibilidad de cerrar esa caja en el frmAperturasCierres.
        public bool AbrirCajaSiempre;
        #endregion
        public void CargarConfiguracion()
        {
            // Carga en variables
            EstablecerStockMinimo = Configuracion.EstablecerStockMinimo;
            StockMinimo = Convert.ToDouble(Configuracion.StockMinimo);
            RecordarReponer = Configuracion.RecordarReponer;
            MostrarMensajeCumpleanios = Configuracion.MostrarMensajeCumpleanios;
            MensajeCumpleanios = Configuracion.MensajeCumpleanios;
            RutaImagenCumpleanios = Configuracion.RutaImgenCumpleanios;
            RecordarDeudores = Configuracion.RecordarDeudores;
            PermitirNuevasDeudas = Configuracion.PermitirNuevasDeudas;
            RecordarPagos = Configuracion.RecordarPagos;
            DiasAnticipacion = Configuracion.DiasAnticipacion;
            AbrirCaja = Configuracion.AbrirCaja;
            IdCaja = Configuracion.IdCaja;
            IdAperturaPredefinida = Configuracion.IdAperturaPredefinida;
            IdAperturaCierre = Configuracion.IdAperturaCierre;
            CajaAbierta = Configuracion.CajaAbierta;
            FechaHoraApertura = Configuracion.FechaHoraApertura;
            //FechaHoraAperturaString = FechaHoraApertura.ToString();
            AbrirCajaSiempre = Configuracion.AbrirCajaSiempre;
        }

        public void CargarControles()
        {
            // Carga en controles
            chkEstablecerMinimo.Checked = EstablecerStockMinimo;
            nudEstablecerStockMinimo.Value = StockMinimo;
            chkRecordarReponer.Checked = RecordarReponer;
            chkMostrarMensajeCumpleanios.Checked = MostrarMensajeCumpleanios;
            rtxtMensajeCumpleanios.Text = MensajeCumpleanios;
            pbxImagen.ImageLocation = RutaImagenCumpleanios;
            chkRecordarDeudores.Checked = RecordarDeudores;
            chkPermitirNuevasDeudas.Checked = PermitirNuevasDeudas;
            chkRecordarPagos.Checked = RecordarPagos;
            nudDiasPagos.Value = DiasAnticipacion;
            cmbCajas.SelectedValue = IdCaja;
            Habilitar(EstablecerStockMinimo, RecordarPagos);
        }

        #endregion

        #region MOSTRAR MENSAJE DE FELIZ CUMPLEAÑOS
        private void Felicitar()
        {

        }
        #endregion

        #endregion

        #region ARTÍCULOS CON POCAS EXISTENCIAS
        private void tbpArticulos_Click(object sender, EventArgs e)
        {
            decimal stockMinimo = Convert.ToDecimal(nudEstablecerStockMinimo.Value);
            Mostrar(stockMinimo);
        }

        private void Mostrar(decimal stockMinimo)
        {
            if (chkRecordarReponer.Checked)
            {
                dgvArticulosReponer.DataSource = NegocioArticulo.Mostrar(stockMinimo);
                if (dgvArticulosReponer.RowCount > 1)
                {
                    MessageBox.Show("¡Atención!: Debe reponer artículos!. Puede consultar los artículos que necesitan reponerse en la sección -Acerca de- en la pestaña -Artículos a reponer-.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region DEUDORES
        private void tbpDeudores_Click(object sender, EventArgs e)
        {
            MostrarDeudores();
        }
        
        private void MostrarDeudores()
        {
            dgvDeudores.DataSource = NegocioVenta.MostrarDeudores();
        }

        #region DATAGRIDVIEW DEUDORES - DOBLE CLICK
        private void dgvDeudores_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Informes.frmInformeFactura formFactura = Informes.frmInformeFactura.GetInstancia();
                formFactura.IdVenta = Convert.ToInt32(dgvDeudores.CurrentRow.Cells["IdVenta"].Value);
                formFactura.ShowDialog();
                formFactura.BringToFront();
            }
            catch { }
        }
        #endregion
        #endregion

        #endregion

        private void mtiEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas formEstadisticas = frmEstadisticas.GetInstancia();
            formEstadisticas.MdiParent = (this);
            formEstadisticas.Show();
            formEstadisticas.BringToFront();
        }

        private void btnRestablecerPrimerInicio_Click(object sender, EventArgs e)
        {
            if (Acceso == "Administrador")
            {
                ReestablecerPrimerInicio();
            }
            else
            {
                MessageBox.Show("Sólo el administrador amo y señor del universo tiene acceso a esta funcionalidad!! >:(", "NO TIENE ACCESO A ESTA FUNCIONALIDAD", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ReestablecerPrimerInicio()
        {
            Settings Configuracion = new Settings();
            Configuracion.PrimerInicioSistema = true;
            MessageBox.Show("Debe guardar la configuración para que se aplique el primer reinicio", "AVISO IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sniFacturacion_Click(object sender, EventArgs e)
        {
            snMenu.MaximumSize = new Size(AreaTrabajo / 2, snMenu.Height);
            snMenu.EnableMaximize = false;
            AnchoExp = 334;
            if (!(snMenu.IsMenuExpanded))
            {
                snMenu.Width = AnchoExp - diferencia;
            }
            else
            {
                snMenu.Width = AnchoExp;
            }
        }

        private void btnAperturasCajas_Click(object sender, EventArgs e)
        {
            try
            {
                frmAperturaCierreCaja formAperturaCierreCaja = frmAperturaCierreCaja.GetInstancia();
                formAperturaCierreCaja.MdiParent = this;
                formAperturaCierreCaja.Show();
                formAperturaCierreCaja.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}