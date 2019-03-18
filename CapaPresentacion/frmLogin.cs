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

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro.ColorTables;
using CapaPresentacion.Properties;

namespace CapaPresentacion
{
    public partial class frmLogin : MetroForm//MaterialForm
    {
        //public int IdTrabajador;
        //public string Apellido;
        //public string Nombre;
        //public string Acceso;
        frmPrincipal formPrincipal = new frmPrincipal();
        Settings Configuracion = new Settings();

        public frmLogin()
        {
            InitializeComponent();
            //Configuracion.Reset();
            //Settings Configuracion = new Settings();
            //Configuracion.PrimerInicioSistema = true;
            //Configuracion.Save();
            VerificarPrimerInicioSistema();
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            lblHora.Text = DateTime.Now.ToString();

            StyleManager.MetroColorGeneratorParameters = new MetroColorGeneratorParameters(Color.WhiteSmoke, Color.FromArgb(1, 69, 79));
        }

        private void VerificarPrimerInicioSistema()
        {
            //Settings Configuracion = new Settings();
            if (Configuracion.PrimerInicioSistema)
            {
                MessageBox.Show("Bienvenido");
                NegocioCliente.Insertar("VENTA AL PÚBLICO EN GENERAL", "", null, DateTime.Now, null, null, null, null, null, null);
                NegocioEmpleado.Insertar("JOSÉ MARÍA", "LANZA", "M", Convert.ToDateTime("07/08/1988"), "33815021", "San Miguel 2257", "4275666", "3815273420", "lanza.josemaria@gmail.com", "Administrador", "admin", "admin");
                DataTable dtCategoriaCaja = new DataTable();
                NegocioCategoria.Insertar("BEBIDAS", "Bebidas con y sin alcohol");
                NegocioCategoria.Insertar("ALIMENTOS", "");
                dtCategoriaCaja = NegocioCategoria.Mostrar();
                NegocioCaja.Insertar("CAJA 1", "Todas", true, Environment.MachineName, dtCategoriaCaja);
                Configuracion.PrimerInicioSistema = false;
                Configuracion.Save();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.SelectAll();
        }

        #region INSTANCIACION
        private static frmLogin _Instancia = null;

        public static frmLogin Instancia
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

        public static frmLogin GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmLogin();
            }
            return Instancia;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region LIMPIAR
        private void Limpiar()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region INGRESAR AL SISTEMA - CAMBIAR DE USUARIO
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Login = NegocioEmpleado.Login(txtUsuario.Text, txtPassword.Text);
                if (Login.Rows.Count == 0)
                {
                    MessageBox.Show("No tiene los permisos para ingresar al sistema", ".:.Inicio de sesión.:.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.SelectAll();
                }
                else
                {
                    // SE VERIFICA SI HAY UNA INSTANCIA PARA QUE MÁS ADELANTE SE PUEDA PONER LA OPCIÓN DE CAMBIAR DE USUARIO
                    //formPrincipal = formPrincipal.GetInstancia(); SE UTILIZA ESTA INSTRUCCIÓN CUANDO SE USA
                    //UN MÉTODO GETINSTANCIA NO ESTÁTICO, DE LO CONTRARIO SE UTILIZA EL SIGUIENTE:
                    #region MDI METRO
                    formPrincipal = frmPrincipal.GetInstancia();
                    formPrincipal.IdEmpleado = Convert.ToInt32(Login.Rows[0][0].ToString());
                    formPrincipal.Apellido = Login.Rows[0][1].ToString();
                    formPrincipal.Nombre = Login.Rows[0][2].ToString();
                    formPrincipal.Acceso = Login.Rows[0][3].ToString();
                    formPrincipal.Show();
                    formPrincipal.BringToFront();
                    Limpiar();
                    this.Hide(); // ANTERIORMENTE EN VEZ DE CERRAR EL FORMULARIO LOGIN SE OCULTABA Y ANDABA PERFECTO - SE LO CONFIGURA
                                 // EN CLOSE PARA LUEGO VER SI SIGUE FUNCIONANDO DE LA MISMA MANERA, SI NO ES ASÍ SE DEBE ESCONDER ESTE FORMULARIO
                                 // NO FUNCA CON Close(), SE CIERRA EL PROGRAMA EL CERRAR frmLogin
                    #endregion

                    #region MDIPRINCIPAL
                    //MDIPrincipal formPrincipal = MDIPrincipal.GetInstancia();
                    //formPrincipal.IdTrabajador = Convert.ToInt32(Login.Rows[0][0].ToString());
                    //formPrincipal.Apellido = Login.Rows[0][1].ToString();
                    //formPrincipal.Nombre = Login.Rows[0][2].ToString();
                    //formPrincipal.Acceso = Login.Rows[0][3].ToString();
                    //formPrincipal.Show();
                    //Limpiar();
                    //this.Hide();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Trace: " + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Hide();
        }
        #endregion

        #region EVENTOS TECLADO

        #region KEYDOWN TECLA ESCAPE
        //EVENTO QUE SE EJECUTARÁ AL PRESIONAR LA TECLA ESCAPE
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                if (txtUsuario.TextLength > 0 && txtPassword.TextLength > 0)
                {
                
                    btnIngresar.PerformClick();
                }
                else if (txtUsuario.Text == string.Empty)
                {
                    txtUsuario.Text = "Ingrese el usuario";
                    txtUsuario.SelectAll();
                }
                else
                {
                    txtPassword.SelectAll();
                }
            }
        }
    }
}