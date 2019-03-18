using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioDescuento
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSDESCUENTO" DE LA CAPADATOS*/
        public static string Insertar(string nombreDescuento, string descripcion, DataTable dtDetalleDescuento)
        {
            DatosDescuento Descuento = new DatosDescuento();
            Descuento.NombreDescuento = nombreDescuento;
            Descuento.Descripcion = descripcion;
            List<DatosDetalleDescuento> DetalleDescuento = new List<DatosDetalleDescuento>();
            foreach (DataRow row in dtDetalleDescuento.Rows)
            {
                DatosDetalleDescuento detalleDescuento = new DatosDetalleDescuento();
                detalleDescuento.IdArticulo = Convert.ToInt32(row["IdArticulo"].ToString());
                detalleDescuento.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalleDescuento.PorcentajeGanancia = Convert.ToDecimal(row["PorcentajeGanancia"].ToString());
                detalleDescuento.MontoInversion = Convert.ToDecimal(row["MontoInversion"].ToString());
                detalleDescuento.PrecioVentaDescuento = Convert.ToDecimal(row["PrecioVentaDescuento"].ToString());
                detalleDescuento.Actualizar = Convert.ToBoolean(row["Actualizar"].ToString());
                DetalleDescuento.Add(detalleDescuento);
            }
            return Descuento.Insertar(Descuento, DetalleDescuento);
        }

        public static string Editar(int idDescuento, string nombreDescuento, string descripcion, DataTable dtDetalleDescuento)
        {
            DatosDescuento Descuento = new DatosDescuento();
            Descuento.NombreDescuento = nombreDescuento;
            Descuento.Descripcion = descripcion;
            List<DatosDetalleDescuento> DetalleDescuento = new List<DatosDetalleDescuento>();
            foreach (DataRow row in dtDetalleDescuento.Rows)
            {
                DatosDetalleDescuento detalleDescuento = new DatosDetalleDescuento();
                detalleDescuento.IdDetalleDescuento = Convert.ToInt32(row["IdDetalleDescuento"].ToString());
                detalleDescuento.IdDescuento = Convert.ToInt32(row["IdDescuento"].ToString());
                detalleDescuento.IdArticulo = Convert.ToInt32(row["IdArticulo"].ToString());
                detalleDescuento.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalleDescuento.PorcentajeGanancia = Convert.ToDecimal(row["ProcentajeGanancia"].ToString());
                detalleDescuento.MontoInversion = Convert.ToDecimal(row["MontoInversion"].ToString());
                detalleDescuento.PrecioVentaDescuento = Convert.ToDecimal(row["PrecioVentaDescuento"].ToString());
                detalleDescuento.Actualizar = Convert.ToBoolean(row["Actualizar"].ToString());
                DetalleDescuento.Add(detalleDescuento);
            }
            return Descuento.Editar(Descuento, DetalleDescuento);
        }

        public static string Habilitar(int idDescuento, bool habilitado)
        {
            DatosDescuento Descuento = new DatosDescuento();
            Descuento.IdDescuento = idDescuento;
            Descuento.Habilitado = habilitado;
            return Descuento.Habilitar(Descuento);

        }

        public static string Eliminar(int idDescuento)
        {
            DatosDescuento Descuento = new DatosDescuento();
            Descuento.IdDescuento = idDescuento;
            return Descuento.Eliminar(Descuento);
        }

        public static DataTable Mostrar()
        {
            return new DatosDescuento().Mostrar();
        }

        public static DataTable MostrarPromosHabilitadas()
        {
            return new DatosDescuento().MostrarPromosHabilitadas();
        }

        public static DataTable Buscar(string buscar)
        {
            DatosDescuento Descuento = new DatosDescuento();
            Descuento.Buscar = buscar;
            return Descuento.BuscarNombre(Descuento);
        }

        public static DataTable BuscarDescuentosHabilitados(string buscar)
        {
            DatosDescuento Descuento = new DatosDescuento();
            Descuento.Buscar = buscar;
            return Descuento.BuscarDescuentosHabilitados(Descuento);
        }
    }
}
