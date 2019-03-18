using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioIngreso
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSINGRESO" DE LA CAPADATOS*/
        public static string Insertar(int idEmpleado, int idProveedor, DateTime fecha, string tipoComprobante, string serie,
            string correlativo, decimal iva, string estado, decimal total, DataTable dtDetalles, DataTable dtArticulo)
        {
            DatosIngreso Ingreso = new DatosIngreso();
            Ingreso.IdTrabajador = idEmpleado;
            Ingreso.IdProveedor = idProveedor;
            Ingreso.Fecha = fecha;
            Ingreso.TipoComprobante = tipoComprobante;
            Ingreso.Serie = serie;
            Ingreso.Correlativo = correlativo;
            Ingreso.IVA = iva;
            Ingreso.Estado = estado;
            Ingreso.Total = total;
            List<DatosDetalleIngreso> Detalles = new List<DatosDetalleIngreso>();
            List<DatosArticulo> Articulo = new List<DatosArticulo>();
            foreach (DataRow filaDetalle in dtDetalles.Rows)
            {
                DatosDetalleIngreso detalle = new DatosDetalleIngreso();
                detalle.IdDetalleIngreso = Convert.ToInt32(filaDetalle["IdDetalleIngreso"].ToString());
                detalle.IdArticulo = Convert.ToInt32(filaDetalle["IdArticulo"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(filaDetalle["PrecioCompra"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(filaDetalle["PrecioVenta"].ToString());
                detalle.Cantidad = Convert.ToDecimal(filaDetalle["Cantidad"].ToString());
                detalle.FechaProduccion = Convert.ToDateTime(filaDetalle["FechaProduccion"].ToString());
                detalle.FechaVencimiento = Convert.ToDateTime(filaDetalle["FechaVencimiento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(filaDetalle["Subtotal"].ToString());
                Detalles.Add(detalle);
                foreach (DataRow filaArticulo in dtArticulo.Rows)
                {
                    if (detalle.IdArticulo == Convert.ToInt32(filaArticulo["IdArticulo"]))
                    {
                        DatosArticulo articulo = new DatosArticulo();
                        articulo.IdArticulo = Convert.ToInt32(filaArticulo["IdArticulo"].ToString());
                        articulo.Codigo = filaArticulo["Codigo"].ToString();
                        articulo.Articulo = filaArticulo["Articulo"].ToString();
                        articulo.IdCategoria = Convert.ToInt32(filaArticulo["IdCategoria"].ToString());
                        articulo.PrecioCompra = Convert.ToDecimal(filaArticulo["PrecioCompra"].ToString());
                        articulo.PrecioVenta = Convert.ToDecimal(filaArticulo["PrecioVenta"].ToString());
                        articulo.Stock = Convert.ToDecimal(filaArticulo["Stock"].ToString());
                        articulo.IdPresentacion = Convert.ToInt32(filaArticulo["IdPresentacion"].ToString());
                        articulo.RutaImagen = filaArticulo["RutaImagen"].ToString();
                        articulo.Descripcion = filaArticulo["Descripcion"].ToString();
                        Articulo.Add(articulo);
                    }
                }
            }
            return Ingreso.Insertar(Ingreso, Detalles, Articulo);
        }

        public static string Editar(int idIngreso, int idEmpleado, int idProveedor, DateTime fecha, string tipoComprobante, string serie,
            string correlativo, decimal iva, string estado, decimal total, DataTable dtDetalles, DataTable dtArticulo)
        {
            DatosIngreso Ingreso = new DatosIngreso();
            Ingreso.IdTrabajador = idEmpleado;
            Ingreso.IdProveedor = idProveedor;
            Ingreso.Fecha = fecha;
            Ingreso.TipoComprobante = tipoComprobante;
            Ingreso.Serie = serie;
            Ingreso.Correlativo = correlativo;
            Ingreso.IVA = iva;
            Ingreso.Estado = estado;
            Ingreso.Total = total;
            List<DatosDetalleIngreso> Detalles = new List<DatosDetalleIngreso>();
            List<DatosArticulo> Articulo = new List<DatosArticulo>();
            foreach (DataRow filaDetalle in dtDetalles.Rows)
            {
                DatosDetalleIngreso detalle = new DatosDetalleIngreso();
                detalle.IdDetalleIngreso = Convert.ToInt32(filaDetalle["IdDetalleIngreso"].ToString());
                detalle.IdArticulo = Convert.ToInt32(filaDetalle["IdArticulo"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(filaDetalle["PrecioCompra"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(filaDetalle["PrecioVenta"].ToString());
                detalle.Cantidad = Convert.ToDecimal(filaDetalle["Cantidad"].ToString());
                detalle.FechaProduccion = Convert.ToDateTime(filaDetalle["FechaProduccion"].ToString());
                detalle.FechaVencimiento = Convert.ToDateTime(filaDetalle["FechaVencimiento"].ToString());
                detalle.Subtotal = Convert.ToDecimal(filaDetalle["Subtotal"].ToString());
                Detalles.Add(detalle);
                foreach (DataRow filaArticulo in dtArticulo.Rows)
                {
                    DatosArticulo articulo = new DatosArticulo();
                    articulo.IdArticulo = Convert.ToInt32(filaArticulo["IdArticulo"].ToString());
                    articulo.Codigo = filaArticulo["Codigo"].ToString();
                    articulo.Articulo = filaArticulo["Articulo"].ToString();
                    articulo.IdCategoria = Convert.ToInt32(filaArticulo["IdCategoria"].ToString());
                    articulo.PrecioCompra = Convert.ToDecimal(filaArticulo["PrecioCompra"].ToString());
                    articulo.PrecioVenta = Convert.ToDecimal(filaArticulo["PrecioVenta"].ToString());
                    articulo.Stock = Convert.ToDecimal(filaArticulo["Stock"].ToString());
                    articulo.IdPresentacion = Convert.ToInt32(filaArticulo["IdPresentacion"].ToString());
                    articulo.RutaImagen = filaArticulo["RutaImagen"].ToString();
                    articulo.Descripcion = filaArticulo["Descripcion"].ToString();
                    Articulo.Add(articulo);
                }
            }
            return Ingreso.Editar(Ingreso, Detalles, Articulo);
        }
        
        public static string Anular(int idIngreso)
        {
            DatosIngreso Ingreso = new DatosIngreso();
            Ingreso.IdIngreso = idIngreso;
            return Ingreso.Anular(Ingreso);
        }

        public static string Eliminar(int idDetalleIngreso)
        {
            DatosDetalleIngreso DetalleIngreso = new DatosDetalleIngreso();
            DetalleIngreso.IdDetalleIngreso = idDetalleIngreso;
            return DetalleIngreso.EliminarDetalle(DetalleIngreso);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosIngreso().Mostrar();
        }
        
        public static DataTable Buscar(DateTime? desde, DateTime? hasta, int? idProveedor)
        {
            DatosIngreso Ingreso = new DatosIngreso();
            return Ingreso.Buscar(desde, hasta, idProveedor);
        }

        //public static DataTable BuscarProveedor(int idproveedor)
        //{
        //    DatosIngreso Ingreso = new DatosIngreso();
        //    return Ingreso.BuscarProveedor(idproveedor);
        //}
        
        public static DataTable Mostrar(int idIngreso)
        {
            DatosIngreso Ingreso = new DatosIngreso();
            return Ingreso.Mostrar(idIngreso);
        }
    }
}
