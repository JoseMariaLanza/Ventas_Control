using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioVenta
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSVENTA" DE LA CAPADATOS*/
        public static string Insertar(int idCaja, int idCliente, int idEmpleado, DateTime fecha, string tipoComprobante, string serie,
            string correlativo, decimal iva, decimal descuento, decimal total, string estado, DataTable dtDetalles)
        {
            DatosVenta Venta = new DatosVenta();
            Venta.IdCaja = idCaja;
            Venta.IdCliente = idCliente;
            Venta.IdEmpleado = idEmpleado;
            Venta.Fecha = fecha;
            Venta.TipoComprobante = tipoComprobante;
            Venta.Serie = serie;
            Venta.Correlativo = correlativo;
            Venta.IVA = iva;
            Venta.Descuento = descuento;
            Venta.Total = total;
            Venta.Estado = estado;
            List<DatosDetalleVenta> Detalles = new List<DatosDetalleVenta>();
            foreach (DataRow rowDetalle in dtDetalles.Rows)
            {
                DatosDetalleVenta detalle = new DatosDetalleVenta();
                detalle.IdDetalleVenta = Convert.ToInt32(rowDetalle["IdDetalleVenta"].ToString());
                detalle.IdArticulo = Convert.ToInt32(rowDetalle["IdArticulo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(rowDetalle["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(rowDetalle["PrecioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(rowDetalle["Descuento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(rowDetalle["Subtotal"].ToString());
                detalle.IdDescuento = Convert.ToInt32(rowDetalle["IdDescuento"].ToString());
                detalle.InsertarDescuento = Convert.ToBoolean(rowDetalle["InsertarDescuento"].ToString());
                detalle.CantidadDescuento = Convert.ToInt32(rowDetalle["CantidadDescuentos"].ToString());
                Detalles.Add(detalle);
            }
            return Venta.Insertar(Venta, Detalles);
        }

        public static string Insertar(int idCaja, int idCliente, int idEmpleado, DateTime fecha, string tipoComprobante, string serie,
            string correlativo, decimal iva, decimal descuento, decimal total, string estado, DataTable dtDetalles, DataTable dtVentasDescuentos)
        {
            DatosVenta Venta = new DatosVenta();
            Venta.IdCaja = idCaja;
            Venta.IdCliente = idCliente;
            Venta.IdEmpleado = idEmpleado;
            Venta.Fecha = fecha;
            Venta.TipoComprobante = tipoComprobante;
            Venta.Serie = serie;
            Venta.Correlativo = correlativo;
            Venta.IVA = iva;
            Venta.Descuento = descuento;
            Venta.Total = total;
            Venta.Estado = estado;
            List<DatosDetalleVenta> Detalles = new List<DatosDetalleVenta>();
            foreach (DataRow rowDetalle in dtDetalles.Rows)
            {
                DatosDetalleVenta detalle = new DatosDetalleVenta();
                detalle.IdDetalleVenta = Convert.ToInt32(rowDetalle["IdDetalleVenta"].ToString());
                detalle.IdArticulo = Convert.ToInt32(rowDetalle["IdArticulo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(rowDetalle["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(rowDetalle["PrecioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(rowDetalle["Descuento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(rowDetalle["Subtotal"].ToString());
                detalle.IdDescuento = Convert.ToInt32(rowDetalle["IdDescuento"].ToString());
                detalle.InsertarDescuento = Convert.ToBoolean(rowDetalle["InsertarDescuento"].ToString());
                detalle.CantidadDescuento = Convert.ToInt32(rowDetalle["CantidadDescuentos"].ToString());
                Detalles.Add(detalle);
            }
            List<DatosDescuento> VentasDescuentos = new List<DatosDescuento>();
            foreach (DataRow rowVentaDescuento in dtVentasDescuentos.Rows)
            {
                DatosDescuento ventaDescuento = new DatosDescuento();
                ventaDescuento.IdDescuento = Convert.ToInt32(rowVentaDescuento["IdDescuento"].ToString());
                ventaDescuento.CantidadDescuentos = Convert.ToInt32(rowVentaDescuento["CantidadDescuentos"].ToString());
                VentasDescuentos.Add(ventaDescuento);
            }
            return Venta.Insertar(Venta, Detalles, VentasDescuentos);
        }

        public static string Insertar(int idCaja, int idCliente, int idEmpleado, DateTime fecha, string tipoComprobante, string serie,
           string correlativo, decimal iva, decimal descuento, decimal total, string estado, DataTable dtDetalles, DataTable dtDeuda, DataTable dtDetallesDeuda, bool primerPago)
        {
            DatosVenta Venta = new DatosVenta();
            Venta.IdCaja = idCaja;
            Venta.IdCliente = idCliente;
            Venta.IdEmpleado = idEmpleado;
            Venta.Fecha = fecha;
            Venta.TipoComprobante = tipoComprobante;
            Venta.Serie = serie;
            Venta.Correlativo = correlativo;
            Venta.IVA = iva;
            Venta.Descuento = descuento;
            Venta.Total = total;
            Venta.Estado = estado;
            List<DatosDetalleVenta> Detalles = new List<DatosDetalleVenta>();
            foreach (DataRow rowDetalle in dtDetalles.Rows)
            {
                DatosDetalleVenta detalle = new DatosDetalleVenta();
                detalle.IdDetalleVenta = Convert.ToInt32(rowDetalle["IdDetalleVenta"].ToString());
                detalle.IdArticulo = Convert.ToInt32(rowDetalle["IdArticulo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(rowDetalle["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(rowDetalle["PrecioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(rowDetalle["Descuento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(rowDetalle["Subtotal"].ToString());
                Detalles.Add(detalle);
            }
            List<DatosDeuda> Deuda = new List<DatosDeuda>();
            List<DatosDetalleDeuda> DetallesDeuda = new List<DatosDetalleDeuda>();
            DatosDeuda deuda = new DatosDeuda();
            deuda.CantidadPagos = Convert.ToInt32(dtDeuda.Rows[0]["CantidadPagos"].ToString());
            deuda.TotalPagado = Convert.ToDecimal(dtDeuda.Rows[0]["TotalPagado"].ToString());
            deuda.Interes = Convert.ToDecimal(dtDeuda.Rows[0]["Interes"].ToString());
            deuda.Descripcion = Convert.ToString(dtDeuda.Rows[0]["Descripcion"].ToString());
            Deuda.Add(deuda);
            foreach (DataRow rowDetalleDeuda in dtDetallesDeuda.Rows)
            {
                DatosDetalleDeuda detalleDeuda = new DatosDetalleDeuda();
                detalleDeuda.NumeroPago = Convert.ToInt32(rowDetalleDeuda["NumeroPago"].ToString());
                detalleDeuda.Monto = Convert.ToDecimal(rowDetalleDeuda["Monto"].ToString());
                detalleDeuda.FechaPago = Convert.ToDateTime(rowDetalleDeuda["FechaPago"].ToString());
                if (primerPago)
                {
                    detalleDeuda.Pagado = true;
                    primerPago = false;
                }
                DetallesDeuda.Add(detalleDeuda);
            }
            return Venta.Insertar(Venta, Detalles, Deuda, DetallesDeuda);
        }

        public static string Insertar(int idCaja, int idCliente, int idEmpleado, DateTime fecha, string tipoComprobante, string serie,
           string correlativo, decimal iva, decimal descuento, decimal total, string estado, DataTable dtDetalles, DataTable dtDeuda,
           DataTable dtDetallesDeuda, bool primerPago, DataTable dtVentasDescuento)
        {
            DatosVenta Venta = new DatosVenta();
            Venta.IdCaja = idCaja;
            Venta.IdCliente = idCliente;
            Venta.IdEmpleado = idEmpleado;
            Venta.Fecha = fecha;
            Venta.TipoComprobante = tipoComprobante;
            Venta.Serie = serie;
            Venta.Correlativo = correlativo;
            Venta.IVA = iva;
            Venta.Descuento = descuento;
            Venta.Total = total;
            Venta.Estado = estado;
            List<DatosDetalleVenta> DetallesVenta = new List<DatosDetalleVenta>();
            foreach (DataRow rowDetalle in dtDetalles.Rows)
            {
                DatosDetalleVenta detalle = new DatosDetalleVenta();
                detalle.IdDetalleVenta = Convert.ToInt32(rowDetalle["IdDetalleVenta"].ToString());
                detalle.IdArticulo = Convert.ToInt32(rowDetalle["IdArticulo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(rowDetalle["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(rowDetalle["PrecioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(rowDetalle["Descuento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(rowDetalle["Subtotal"].ToString());
                DetallesVenta.Add(detalle);
            }
            List<DatosDeuda> Deuda = new List<DatosDeuda>();
            List<DatosDetalleDeuda> DetallesDeuda = new List<DatosDetalleDeuda>();
            DatosDeuda deuda = new DatosDeuda();
            deuda.CantidadPagos = Convert.ToInt32(dtDeuda.Rows[0]["CantidadPagos"].ToString());
            deuda.TotalPagado = Convert.ToDecimal(dtDeuda.Rows[0]["totalPagado"].ToString());
            deuda.Interes = Convert.ToDecimal(dtDeuda.Rows[0]["Interes"].ToString());
            deuda.Descripcion = Convert.ToString(dtDeuda.Rows[0]["Descripcion"].ToString());
            Deuda.Add(deuda);
            foreach (DataRow rowDetalleDeuda in dtDetallesDeuda.Rows)
            {
                DatosDetalleDeuda detalleDeuda = new DatosDetalleDeuda();
                detalleDeuda.NumeroPago = Convert.ToInt32(rowDetalleDeuda["NumeroPago"].ToString());
                detalleDeuda.Monto = Convert.ToDecimal(rowDetalleDeuda["Monto"].ToString());
                detalleDeuda.FechaPago = Convert.ToDateTime(rowDetalleDeuda["FechaPago"].ToString());
                if (primerPago)
                {
                    detalleDeuda.Pagado = true;
                    primerPago = false;
                }
                DetallesDeuda.Add(detalleDeuda);
            }
            List<DatosDescuento> VentasDescuentos = new List<DatosDescuento>();
            foreach (DataRow rowVentaDescuento in dtVentasDescuento.Rows)
            {
                DatosDescuento ventaDescuento = new DatosDescuento();
                ventaDescuento.IdDescuento = Convert.ToInt32(rowVentaDescuento["IdDescuento"].ToString());
                ventaDescuento.CantidadDescuentos = Convert.ToInt32(rowVentaDescuento["CantidadDescuentos"].ToString());
                VentasDescuentos.Add(ventaDescuento);
            }
            return Venta.Insertar(Venta, DetallesVenta, Deuda, DetallesDeuda, VentasDescuentos);
        }
        
        public static string Eliminar(int idVenta, DataTable dtDetalles)
        {
            DatosVenta Venta = new DatosVenta();
            Venta.IdVenta = idVenta;
            List<DatosDetalleVenta> Detalles = new List<DatosDetalleVenta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DatosDetalleVenta detalle = new DatosDetalleVenta();
                detalle.IdDetalleVenta = Convert.ToInt32(row["IdDetalleVenta"].ToString());
                detalle.IdVenta = Convert.ToInt32(row["IdVenta"].ToString());
                detalle.IdArticulo = Convert.ToInt32(row["IdArticulo"].ToString());
                detalle.Cantidad = Convert.ToDecimal(row["Cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["PrecioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(row["Subtotal"].ToString());
                Detalles.Add(detalle);
            }
            return Venta.Eliminar(Venta, Detalles);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosVenta().Mostrar();
        }

        public static DataTable MostrarDeudores()
        {
            return new DatosVenta().MostrarDeudores();
        }

        /* DESHABILITADO PORQUE SE ELIMINÓ EL SP "mostrar_articulo_venta" DE LA BASE DE DATOS
        /*MÉTODO MostrarArticuloVenta QUE LLAMA AL MÉTODO MostrarArticuloVenta DE LA CLASE DATOSVENTA DE LA CAPADATOS
        public static DataTable MostrarArticuloVenta()
        {
            return new DatosVenta().MostrarArticuloVenta();
        }
        */
        
        public static DataTable Buscar(DateTime desde, DateTime hasta)
        {
            DatosVenta Venta = new DatosVenta();
            return Venta.Buscar(desde, hasta);
        }
        
        public static DataTable Mostrar(int idVenta)
        {
            DatosVenta Venta = new DatosVenta();
            return Venta.Mostrar(idVenta);
        }
        
        //public static DataTable MostrarArticuloVentaNombre(string textobuscar)
        //{
        //    DatosVenta Venta = new DatosVenta();
        //    return Venta.MostrarArticuloVentaNombre(textobuscar);
        //}
        
        //public static DataTable MostrarArticuloVentaCodigo(string textobuscar)
        //{
        //    DatosVenta Venta = new DatosVenta();
        //    return Venta.MostrarArticuloVentaCodigo(textobuscar);
        //}

        //public static DataTable MostrarArticuloVentaCategoria(string textobuscar)
        //{
        //    DatosVenta Venta = new DatosVenta();
        //    return Venta.MostrarArticuloVentaCategoria(textobuscar);
        //}

        public static DataTable Informe(int idVenta)
        {
            DatosVenta Venta = new DatosVenta();
            return Venta.Informe(idVenta);
        }

        public static DataTable CalcularVentas(DateTime desde, DateTime hasta)
        {
            DatosVenta Venta = new DatosVenta();
            return Venta.CalcularVentas(Venta, desde, hasta);
        }
    }
}
