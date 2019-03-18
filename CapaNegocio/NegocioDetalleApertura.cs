using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioDetalleApertura
    {
        public static string Eliminar(int idDetalleApertura)
        {
            DatosDetalleApertura DetalleApertura = new DatosDetalleApertura();
            return DetalleApertura.Eliminar(idDetalleApertura);
        }

        public static string EliminarDetalleAperturaPredefinida(int idDetalleApertura)
        {
            DatosDetalleApertura DetalleApertura = new DatosDetalleApertura();
            return DetalleApertura.EliminarDetalleAperturaPredefinida(idDetalleApertura);
        }

        public static DataTable Mostrar(int idApertura)
        {
            return new DatosDetalleApertura().Mostrar(idApertura);
        }

        public static DataTable MostrarDetallesAperturaPredefinida(int idAperturaPredefinida)
        {
            return new DatosDetalleApertura().MostrarDetallesAperturaPredefinida(idAperturaPredefinida);
        }
    }
}
