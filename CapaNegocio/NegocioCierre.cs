using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioCierre
    {
        public static string Insertar(int idAperturacierre, int idCaja, int idEmpleado, DateTime fechaHora,
            decimal montoFinalSistema, decimal montoFinalReal, DataTable dtDetalle,
            decimal diferencia, string estado)
        {
            DatosCierre Cierre = new DatosCierre();
            Cierre.IdCaja = idCaja;
            Cierre.IdEmpleado = idEmpleado;
            Cierre.FechaHora = fechaHora;
            Cierre.MontoFinalSistema = montoFinalSistema;
            Cierre.MontoFinalReal = montoFinalReal;
            List<DatosDetalleCierre> Detalles = new List<DatosDetalleCierre>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DatosDetalleCierre detalle = new DatosDetalleCierre();
                detalle.Moneda = row["Moneda"].ToString();
                detalle.Denominacion = row["Denominacion"].ToString();
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                Detalles.Add(detalle);
            }
            DatosAperturaCierre AperturaCierre = new DatosAperturaCierre();
            AperturaCierre.IdAperturaCierre = idAperturacierre;
            AperturaCierre.Diferencia = diferencia;
            AperturaCierre.Estado = estado;
            return Cierre.Insertar(Cierre, Detalles, AperturaCierre);
        }

        /*
        public static string Editar(int iddetallecierre, int idcierre, int idcaja, int idtrabajador, 
            DateTime fechahora, decimal montofinalsistema, decimal montofinalreal, DataTable dtDetalle, DataTable dtAperturaCierre)
        {
            DatosCierre Cierre = new DatosCierre();
            Cierre.IdTrabajador = idtrabajador;
            Cierre.FechaHora = fechahora;
            Cierre.MontoFinalSistema = montofinalsistema;
            Cierre.MontoFinalReal = montofinalreal;
            List<DatosDetalleCierre> Detalles = new List<DatosDetalleCierre>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DatosDetalleCierre detalle = new DatosDetalleCierre();
                detalle.IdDetalleCierre = Convert.ToInt32(row["IdDetalleCierre"]);
                detalle.IdCierre = Convert.ToInt32(row["IdCierre"]);
                detalle.FormaCobro = row["FormaCobro"].ToString();
                detalle.Moneda = row["Moneda"].ToString();
                detalle.Denominacion = row["Denominacion"].ToString();
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                Detalles.Add(detalle);
            }
            List<DatosAperturaCierre> AperturaCierre = new List<DatosAperturaCierre>();
            foreach (DataRow row in dtAperturaCierre.Rows)
            {
                DatosAperturaCierre aperturaCierre = new DatosAperturaCierre();
                aperturaCierre.IdAperturaCierre = Convert.ToInt32(row["IdAperturaCierre"]);
                aperturaCierre.IdApertura = Convert.ToInt32(row["IdApertura"]);
                aperturaCierre.IdCierre = Convert.ToInt32(row["IdCierre"]);
                aperturaCierre.Diferencia = Convert.ToDecimal(row["Diferencia"]);
                aperturaCierre.Estado = row["Estado"].ToString();
                AperturaCierre.Add(aperturaCierre);
            }
            return Cierre.Editar(Cierre, Detalles, AperturaCierre);
        }
        */

        public static DataTable Mostrar(int idCierre)
        {
            return new DatosCierre().Mostrar(idCierre);
        }
    }
}
