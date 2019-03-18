using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioDetalleDescuento
    {
        public static DataTable Mostrar(int idDescuento)
        {
            return new DatosDetalleDescuento().Mostrar(idDescuento);
        }

        public static string Eliminar(int idDetalleDescuento)
        {
            DatosDetalleDescuento DetalleDescuento = new DatosDetalleDescuento();
            DetalleDescuento.IdDetalleDescuento = idDetalleDescuento;
            return DetalleDescuento.Eliminar(DetalleDescuento);
        }
    }
}
