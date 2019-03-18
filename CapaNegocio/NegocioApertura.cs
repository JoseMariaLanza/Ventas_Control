using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioApertura
    {
        public static string Insertar(int idCaja, int idEmpleado, DateTime fechaHora,
            decimal montoInicial, DataTable dtDetalle, string estado, ref int idAperturaCierre)
        {
            DatosApertura Apertura = new DatosApertura();
            Apertura.IdCaja = idCaja;
            Apertura.IdEmpleado = idEmpleado;
            Apertura.FechaHora = fechaHora;
            Apertura.MontoInicial = montoInicial;
            List<DatosDetalleApertura> Detalles = new List<DatosDetalleApertura>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DatosDetalleApertura detalle = new DatosDetalleApertura();
                detalle.Moneda = row["Moneda"].ToString();
                detalle.Denominacion = row["Denominacion"].ToString();
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                Detalles.Add(detalle);
            }
            DatosAperturaCierre AperturaCierre = new DatosAperturaCierre();
            AperturaCierre.Estado = estado;
            return Apertura.Insertar(Apertura, Detalles, AperturaCierre, ref idAperturaCierre);
        }

        public static string InsertarAperturaPredefinida(int idCaja, int idEmpleado, DateTime fechaHora,
            decimal montoInicial, DataTable dtDetalle, string descripcion, ref int IdAperturaPorDefecto)
        {
            DatosApertura Apertura = new DatosApertura();
            Apertura.IdCaja = idCaja;
            Apertura.IdEmpleado = idEmpleado;
            Apertura.FechaHora = fechaHora;
            Apertura.MontoInicial = montoInicial;
            Apertura.Descripcion = descripcion;
            List<DatosDetalleApertura> Detalles = new List<DatosDetalleApertura>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DatosDetalleApertura detalle = new DatosDetalleApertura();
                detalle.Moneda = row["Moneda"].ToString();
                detalle.Denominacion = row["Denominacion"].ToString();
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                Detalles.Add(detalle);
            }
            return Apertura.InsertarAperturaPredefinida(Apertura, Detalles, ref IdAperturaPorDefecto);
        }

        public static string Editar(int idApertura, int idCaja, int idEmpleado, DateTime fechaHora,
            decimal montoInicial, DataTable dtDetalle)
        {
            DatosApertura Apertura = new DatosApertura();
            Apertura.IdApertura = idApertura;
            Apertura.IdCaja = idCaja;
            Apertura.IdEmpleado = idEmpleado;
            Apertura.FechaHora = fechaHora;
            Apertura.MontoInicial = montoInicial;
            List<DatosDetalleApertura> Detalles = new List<DatosDetalleApertura>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DatosDetalleApertura detalle = new DatosDetalleApertura();
                detalle.IdDetalleApertura = Convert.ToInt32(row["IdDetalleApertura"]);
                detalle.IdApertura = Convert.ToInt32(row["IdAperturaPredefinida"]);
                detalle.Moneda = row["Moneda"].ToString();
                detalle.Denominacion = row["Denominacion"].ToString();
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                Detalles.Add(detalle);
            }
            //DatosAperturaCierre AperturaCierre = new DatosAperturaCierre();
            //AperturaCierre.IdAperturaCierre = idAperturaCierre;
            return Apertura.Editar(Apertura, Detalles);
        }

        public static string EditarAperturaPredefinida(int idAperturaPredefinida, int idCaja, int idEmpleado, DateTime fechaHora,
            decimal montoInicial, DataTable dtDetalle, string descripcion)
        {
            DatosApertura Apertura = new DatosApertura();
            Apertura.IdAperturaPredefinida = idAperturaPredefinida;
            Apertura.IdCaja = idCaja;
            Apertura.IdEmpleado = idEmpleado;
            Apertura.FechaHora = fechaHora;
            Apertura.MontoInicial = montoInicial;
            Apertura.Descripcion = descripcion;
            List<DatosDetalleApertura> Detalles = new List<DatosDetalleApertura>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DatosDetalleApertura detalle = new DatosDetalleApertura();
                detalle.IdDetalleApertura = Convert.ToInt32(row["IdDetalleAperturaPredefinida"]);
                detalle.IdApertura = Convert.ToInt32(row["IdApertura"]);
                detalle.Moneda = row["Moneda"].ToString();
                detalle.Denominacion = row["Denominacion"].ToString();
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                Detalles.Add(detalle);
            }
            return Apertura.EditarAperturaPredefinida(Apertura, Detalles);
        }

        public static DataTable Mostrar(int idApertura)
        {
            return new DatosApertura().Mostrar(idApertura);
        }

        public static DataTable MostrarAperturasPredefinidas()
        {
            return new DatosApertura().MostrarAperturasPredefinidas();
        }

        public static DataTable BuscarAperturaPredefinida(int idAperturaPredefinida)
        {
            return new DatosApertura().BuscarAperturaPredefinida(idAperturaPredefinida);
        }
    }
}
