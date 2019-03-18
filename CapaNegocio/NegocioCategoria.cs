using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioCategoria
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSCATEGORIA" DE LA CAPADATOS*/
        public static string Insertar(string categoria, string descripcion)
        {
            DatosCategoria Categoria = new DatosCategoria();
            Categoria.Categoria = categoria;
            Categoria.Descripcion = descripcion;
            return Categoria.Insertar(Categoria);
        }

        public static string Editar(int idCategoria, string categoria, string descripcion)
        {
            DatosCategoria Categoria = new DatosCategoria();
            Categoria.IdCategoria = idCategoria;
            Categoria.Categoria = categoria;
            Categoria.Descripcion = descripcion;
            return Categoria.Editar(Categoria);
        }
        
        public static string Eliminar(int idCategoria)
        {
            DatosCategoria Categoria = new DatosCategoria();
            Categoria.IdCategoria = idCategoria;
            return Categoria.Eliminar(Categoria);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosCategoria().Mostrar();
        }
        
        public static DataTable Buscar(string buscar)
        {
            DatosCategoria Categoria = new DatosCategoria();
            Categoria.Buscar = buscar;
            return Categoria.BuscarCategoria(Categoria);
        }
    }
}
