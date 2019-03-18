using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioNota
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSNOTA" DE LA CAPADATOS*/
        public static string Insertar(string nota, int x, int y, int ancho, int alto)
        {
            DatosNota Nota = new DatosNota();
            Nota.Nota = nota;
            Nota.X = x;
            Nota.Y = y;
            Nota.Ancho = ancho;
            Nota.Alto = alto;
            return Nota.Insertar(Nota);
        }
        
        public static string Editar(int idNota, string nota, int x, int y, int ancho, int alto)
        {
            DatosNota Nota = new DatosNota();
            Nota.IdNota = idNota;
            Nota.Nota = nota;
            Nota.X = x;
            Nota.Y = y;
            Nota.Ancho = ancho;
            Nota.Alto = alto;
            return Nota.Editar(Nota);
        }
        
        public static string Eliminar(int idNota)
        {
            DatosNota Nota = new DatosNota();
            Nota.IdNota = idNota;
            return Nota.Eliminar(Nota);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosNota().Mostrar();
        }

        public static int Contar()
        {
            return new DatosNota().Contar();
        }
    }
}
