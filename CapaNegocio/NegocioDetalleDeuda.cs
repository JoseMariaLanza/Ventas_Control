using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioDetalleDeuda
    {
        public static DataTable Mostrar(int idDeuda)
        {
            DatosDetalleDeuda detalleDeuda = new DatosDetalleDeuda();
            detalleDeuda.IdDeuda = idDeuda;
            return detalleDeuda.Mostrar(detalleDeuda);
        }
    }
}
