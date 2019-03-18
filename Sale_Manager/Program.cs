using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using CapaPresentacion.Informes;

namespace Sale_Manager
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
       {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message + " Traza: " + ex.StackTrace);
            }
        }
    }
}

// IMPORTANTE!
// HACER MÓDULO PARA PROGRAMACIÓN DE APERTURA PREDEFINIDA EN LAS CONFIGURACIONES DEL FORMULARIO PRINCIPAL!!
// DE ESTA MANERA SERÁ MÁS FÁCIL LA INTEGRACIÓN - LISTO
// PARA RESOLVER EL PROBLEMA DE LA APERTURA AUTOMÁTICA; PROGRAMAR AL MOMENTO DEL INICIO DEL SISTEMA LA INSERCIÓN DE LA APERTURA
// CON LOS DETALLES DE LA APERTURA PREDEFINIDA - LISTO
// IMPORTANTE ESPECIFICAR LA FECHA Y HORA DE APERTURA AUTOMÁTICA!! - LISTO

//IMPORTANTE!! VER LÍNEA 565 frmAperturaCaja.cs