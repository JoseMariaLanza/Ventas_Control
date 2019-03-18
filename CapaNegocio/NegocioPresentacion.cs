using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioPresentacion
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSPRESENTACION" DE LA CAPADATOS*/
        public static string Insertar(string presentacion, string descripcion)
        {
            DatosPresentacion Presentacion = new DatosPresentacion();
            Presentacion.Presentacion = presentacion;
            Presentacion.Descripcion = descripcion;
            return Presentacion.Insertar(Presentacion);
        }
        
        public static string Editar(int idPresentacion, string presentacion, string descripcion)
        {
            DatosPresentacion Presentacion = new DatosPresentacion();
            Presentacion.IdPresentacion = idPresentacion;
            Presentacion.Presentacion = presentacion;
            Presentacion.Descripcion = descripcion;
            return Presentacion.Editar(Presentacion);
        }
        
        public static string Eliminar(int idPresentacion)
        {
            DatosPresentacion Presentacion = new DatosPresentacion();
            Presentacion.IdPresentacion = idPresentacion;
            return Presentacion.Eliminar(Presentacion);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosPresentacion().Mostrar();
        }
        
        public static DataTable Buscar(string buscar)
        {
            DatosPresentacion Presentacion = new DatosPresentacion();
            Presentacion.Buscar = buscar;
            return Presentacion.BuscarPresentacion(Presentacion);
        }
    }
}
