using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioEstadisticas
    {
        public static DataTable Mostrar(DateTime desde, DateTime hasta, string consulta, string tipo)
        {
            return new DatosEstadisticas().Mostrar(desde, hasta, consulta, tipo);
        }
    }
}
