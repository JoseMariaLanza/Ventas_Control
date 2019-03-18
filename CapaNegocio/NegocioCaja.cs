using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioCaja
    {
        public static string Insertar(string caja, string formaCobro, bool aperturaAutomatica, string terminal, DataTable dtDetallesCaja)
        {
            DatosCaja Caja = new DatosCaja();
            Caja.Caja = caja;
            Caja.FormaCobro = formaCobro;
            Caja.AperturaAutomatica = aperturaAutomatica;
            Caja.Terminal = terminal;
            List<DatosDetalleCaja> Detalles = new List<DatosDetalleCaja>();
            foreach (DataRow row in dtDetallesCaja.Rows)
            {
                DatosDetalleCaja detalle = new DatosDetalleCaja();
                //detalle.IdCaja = Convert.ToInt32(row["IdCaja"].ToString());
                detalle.IdCategoria = Convert.ToInt32(row["IdCategoria"]);
                Detalles.Add(detalle);
            }
            return Caja.Insertar(Caja, Detalles);
        }

        public static string Editar(int idCaja, string caja, string formaCobro, bool aperturaAutomatica, string terminal, DataTable dtDetallesCaja)
        {
            DatosCaja Caja = new DatosCaja();
            Caja.IdCaja = idCaja;
            Caja.Caja = caja;
            Caja.FormaCobro = formaCobro;
            Caja.AperturaAutomatica = aperturaAutomatica;
            Caja.Terminal = terminal;
            List<DatosDetalleCaja> Detalles = new List<DatosDetalleCaja>();
            foreach (DataRow row in dtDetallesCaja.Rows)
            {
                DatosDetalleCaja detalle = new DatosDetalleCaja();
                detalle.IdDetalleCaja = Convert.ToInt32(row["IdDetalleCaja"].ToString());
                detalle.IdCaja = Convert.ToInt32(row["IdCaja"].ToString());
                detalle.IdCategoria = Convert.ToInt32(row["IdCategoria"].ToString());
                Detalles.Add(detalle);
            }
            return Caja.Editar(Caja, Detalles);
        }

        public static string Eliminar(int idCaja, DataTable dtDetallesCaja)
        {
            DatosCaja Caja = new DatosCaja();
            Caja.IdCaja = idCaja;
            List<DatosDetalleCaja> Detalles = new List<DatosDetalleCaja>();
            foreach (DataRow row in dtDetallesCaja.Rows)
            {
                DatosDetalleCaja detalle = new DatosDetalleCaja();
                detalle.IdDetalleCaja = Convert.ToInt32(row["IdDetalleCaja"].ToString());
                detalle.IdCaja = Convert.ToInt32(row["IdCaja"].ToString());
                detalle.IdCategoria = Convert.ToInt32(row["IdCategoria"].ToString());
                Detalles.Add(detalle);
            }
            return Caja.Eliminar(Caja, Detalles);
        }

        public static DataTable Mostrar()
        {
            return new DatosCaja().Mostrar();
        }

        public static DataTable Buscar(string caja)
        {
            return new DatosCaja().Buscar(caja);
        }
    }
}
