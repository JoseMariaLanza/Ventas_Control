using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioAperturaCierre
    {
        public static DataTable Mostrar()
        {
            return new DatosAperturaCierre().Mostrar();
        }
    }
}
