using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioCategoriaCaja
    {
        public static string Eliminar(int idcategoriacaja)
        {
            DatosCategoriaCaja categoriaCaja = new DatosCategoriaCaja();
            categoriaCaja.IdCategoriaCaja = idcategoriacaja;
            return categoriaCaja.Eliminar(categoriaCaja);
        }

        public static DataTable Mostrar()
        {
            return new DatosCaja().Mostrar();
        }

        public static DataTable Buscar(int idcaja)
        {
            return new DatosCategoriaCaja().Buscar(idcaja);
        }
    }
}
