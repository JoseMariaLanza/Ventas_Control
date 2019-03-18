using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioDetalleCaja
    {
        public static string Eliminar(int idDetalleCaja)
        {
            DatosDetalleCaja detallesCaja = new DatosDetalleCaja();
            detallesCaja.IdDetalleCaja = idDetalleCaja;
            return detallesCaja.Eliminar(detallesCaja);
        }

        public static DataTable Mostrar()
        {
            return new DatosCaja().Mostrar();
        }

        public static DataTable Mostrar(int idCaja)
        {
            return new DatosDetalleCaja().Mostrar(idCaja);
        }
    }
}
