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

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro.ColorTables;

namespace CapaPresentacion
{
    public partial class frmNota : MetroForm
    {
        public int IdNota;
        string Nota;
        int posicionX;
        int posicionY;
        int Ancho;
        int Alto;
        public bool isPadre;

        #region VARIABLES SIZEGRIP
        Rectangle sizeGripRectangulo;
        const int GRIP_SIZE = 15;
        bool inSizeDrag = false;
        // se declara la mitad del tamaño del SizeGrip
        const int GRIP_SIZE_OVER_TWO = GRIP_SIZE / 2;
        #endregion

        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;

        // Declaraciones del API 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        // 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // 

        public frmNota()
        {
            InitializeComponent();
            // Mover formulario al hacer click en cualquier parte de él
            //MouseMove += new MouseEventHandler(mtbOpcionesNota_MouseMove); // deshabilidato para poder modificar tamaño de formulario
            labelItem4.MouseMove += new MouseEventHandler(mtbOpcionesNota_MouseMove);
            labelItem1.MouseMove += new MouseEventHandler(mtbOpcionesNota_MouseMove);
            // Dibujando las líneas transversales del SizeGrip (Notación lambda, es lo mismo que los eventos)
            Paint += (o, ea) => { ControlPaint.DrawSizeGrip(ea.Graphics, BackColor, sizeGripRectangulo); };
            // Definiendo el área del rectángulo dibujado
            sizeGripRectangulo.Width = sizeGripRectangulo.Height = GRIP_SIZE;
            // Llamando al método que adapta el rectángulo al tamaño del formulario
            AdaptarRectanguloGrip();
            // Detectando cuando el mouse hace clic sobre el SizeGrip
            MouseDown += (o, ea) => { if (IsInSizeGrip(ea.Location)) inSizeDrag = true; };
            // Detectando si se suelta el click iaquierdo del mouse
            MouseUp += (o, ea) => { if (ea.Button == MouseButtons.Left) Editar(); inSizeDrag = false; };
            // Evento que captura el movimiento del mouse notación lambda
            MouseMove += (o, ea) =>
            {
                if (inSizeDrag)
                {
                    Width = ea.Location.X + GRIP_SIZE_OVER_TWO;
                    Height = ea.Location.Y + GRIP_SIZE_OVER_TWO;
                    AdaptarRectanguloGrip();
                    Invalidate();
                }
            };

            //StyleManager.MetroColorGeneratorParameters = new MetroColorGeneratorParameters(Color.Goldenrod, Color.Goldenrod);
        }

        #region EVENTOS
        private void frmNota_SizeChanged(object sender, EventArgs e)
        {
            Ancho = Height;
            Alto = Width;
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }
        #endregion

        private void frmNota_Load(object sender, EventArgs e)
        {
            txtNota.BackColor = Color.Goldenrod;
            AdaptarRectanguloGrip();
        }

        #region SIZEGRIP
        // Método que adapta la ubicación del rectángulo al tamaño del formulario
        private void AdaptarRectanguloGrip()
        {
            sizeGripRectangulo.X = Width - GRIP_SIZE;
            sizeGripRectangulo.Y = Height - GRIP_SIZE;
            labelItem1.Width = Width / 2;
        }

        // Método que captura la posición del mouse y determina si éste se encuentra sobre el rectángulo del SizeGrip
        private bool IsInSizeGrip(Point ubicacion)
        {
            if (ubicacion.X >= sizeGripRectangulo.X
                && ubicacion.X <= Width
                && ubicacion.Y >= sizeGripRectangulo.Y
                && ubicacion.Y <= Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        public void CargarNota(int idnota, string nota, int posx, int posy, int ancho, int alto)
        {
            IdNota = idnota;
            Nota = nota;
            posicionX = Left;
            posicionY = Top;
            Ancho = Width;
            Alto = Height;
            txtNota.Text = Nota;
        }

        private void Insertar()
        {
            string agregar = "";
            try
            {
                agregar = NegocioNota.Insertar(Nota, posicionX, posicionY, Ancho, Alto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            DataTable registroNota = NegocioNota.Mostrar();
            foreach (DataRow row in registroNota.Rows)
            {
                int idnota = Convert.ToInt32(row[0]);
                IdNota = idnota;
            }
        }

        private void Editar()
        {
            Nota = txtNota.Text;
            posicionX = Left;
            posicionY = Top;
            Ancho = Width;
            Alto = Height;
            string editar = "";
            try
            {
                editar = NegocioNota.Editar(IdNota, Nota, posicionX, posicionY, Ancho, Alto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Eliminar()
        {
            string Respuesta;
            Respuesta = NegocioNota.Eliminar(IdNota);
        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            Nota = txtNota.Text;
            posicionX = Left;
            posicionY = Top;
            Ancho = Width;
            Alto = Height;
            Editar();
        }

        private void frmNota_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Nota = txtNota.Text;
                posicionX = Left;
                posicionY = Top;
                Ancho = Width;
                Alto = Height;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Realmente desea eliminar la nota?",
                "Eliminando registro" + " " + isPadre, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                Eliminar();
                Close();
            }
        }

        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }

        private void mtbOpcionesNota_MouseMove(object sender, MouseEventArgs e)
        {
            moverForm();
            Editar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IdNota == 0)
            {
                Insertar();
            }
            else
            {
                Editar();
            }
        }

        private void txtNota_BackColorChanged(object sender, EventArgs e)
        {
            if (txtNota.BackColor != Color.Goldenrod)
            {
                txtNota.BackColor = Color.Goldenrod;
            }
        }
    }
}
