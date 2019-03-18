using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioDetalle_Descuento
    {
        public static DataTable MostrarDetalle_Descuento(int iddescuento)
        {
            return new DatosDetalle_Descuento().MostrarDetalle_Descuento(iddescuento);
        }

        public static string Eliminar(int iddetalle_descuento)
        {
            DatosDetalle_Descuento Detalle_Descuento = new DatosDetalle_Descuento();
            Detalle_Descuento.IdDetalle_Descuento = iddetalle_descuento;
            return Detalle_Descuento.Eliminar(Detalle_Descuento);
        }
    }
}
