using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleIngreso
    {
        private int _IdDetalleIngreso;
        private int _IdIngreso;
        private int _IdArticulo;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private decimal _Cantidad;
        private DateTime _FechaProduccion;
        private DateTime _FechaVencimiento;
        private decimal _Subtotal;

        #region PROPIEDADES
        public int IdDetalleIngreso
        {
            get
            {
                return _IdDetalleIngreso;
            }

            set
            {
                _IdDetalleIngreso = value;
            }
        }

        public int IdIngreso
        {
            get
            {
                return _IdIngreso;
            }

            set
            {
                _IdIngreso = value;
            }
        }

        public int IdArticulo
        {
            get
            {
                return _IdArticulo;
            }

            set
            {
                _IdArticulo = value;
            }
        }

        public decimal PrecioCompra
        {
            get
            {
                return _PrecioCompra;
            }

            set
            {
                _PrecioCompra = value;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public DateTime FechaProduccion
        {
            get
            {
                return _FechaProduccion;
            }

            set
            {
                _FechaProduccion = value;
            }
        }

        public DateTime FechaVencimiento
        {
            get
            {
                return _FechaVencimiento;
            }

            set
            {
                _FechaVencimiento = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return _Subtotal;
            }

            set
            {
                _Subtotal = value;
            }
        }
        #endregion

        //Constructores
        public DatosDetalleIngreso()
        {

        }

        public DatosDetalleIngreso(int idDetalleIngreso, int idIngreso, int idArticulo, decimal precioCompra, decimal precioVenta,
            decimal cantidad, DateTime fechaProduccion, DateTime fechaVencimiento, decimal subtotal)
        {
            IdDetalleIngreso = idDetalleIngreso;
            IdIngreso = idIngreso;
            IdArticulo = idArticulo;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            Cantidad = cantidad;
            FechaProduccion = fechaProduccion;
            FechaVencimiento = fechaVencimiento;
            Subtotal = subtotal;
        }

        //Método Insertar
        #region INSERTAR
        #region FORMA ORIGINAL DEL MÉTODO INSERTAR
        // Forma original del método Insertar()
        /*public string Insertar(DatosDetalle_Ingreso Detalle_Ingreso, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        /*ATENCIÓN!! Al pasar por referencia ref MySqlConnection y ref MySqlTransaction se hará todo en una sola transacción y no se
         * combinarán los distintos ingresos que puedan estar llevandose a cabo en el mismo momento, esto permitirá que el 
         * programa pueda ser usado en red sin problemas*//*
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "insertar_detalle_ingreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Ingreso = new MySqlParameter();
                parametroIdDetalle_Ingreso.ParameterName = "pariddetalle_ingreso";
                parametroIdDetalle_Ingreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Ingreso.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalle_Ingreso);

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "paridingreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Value = Detalle_Ingreso.IdIngreso;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                MySqlParameter parametroIdProducto = new MySqlParameter();
                parametroIdProducto.ParameterName = "paridproducto";
                parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdProducto.Value = Detalle_Ingreso.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdProducto);

                MySqlParameter parametroPrecio_Compra = new MySqlParameter();
                parametroPrecio_Compra.ParameterName = "parprecio_compra";
                parametroPrecio_Compra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                ComandoMySql.Parameters.Add(parametroPrecio_Compra);

                MySqlParameter parametroPrecio_Venta = new MySqlParameter();
                parametroPrecio_Venta.ParameterName = "parprecio_venta";
                parametroPrecio_Venta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                ComandoMySql.Parameters.Add(parametroPrecio_Venta);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parcantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = Detalle_Ingreso.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroFecha_Produccion = new MySqlParameter();
                parametroFecha_Produccion.ParameterName = "parfecha_produccion";
                parametroFecha_Produccion.MySqlDbType = MySqlDbType.Date;
                parametroFecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                ComandoMySql.Parameters.Add(parametroFecha_Produccion);

                MySqlParameter parametroFecha_Vencimiento = new MySqlParameter();
                parametroFecha_Vencimiento.ParameterName = "parfecha_vencimiento";
                parametroFecha_Vencimiento.MySqlDbType = MySqlDbType.Date;
                parametroFecha_Vencimiento.Value = Detalle_Ingreso.Fecha_Vencimiento;
                ComandoMySql.Parameters.Add(parametroFecha_Vencimiento);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parsubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = Detalle_Ingreso.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }*/
        #endregion
        public string Insertar(DatosDetalleIngreso DetalleIngreso, List<DatosArticulo> Articulo, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
            /*ATENCIÓN!! Al pasar por referencia ref MySqlConnection y ref MySqlTransaction se hará todo en una sola transacción y no se
             * combinarán los distintos ingresos que puedan estar llevandose a cabo en el mismo momento, esto permitirá que el 
             * programa pueda ser usado en red sin problemas*/
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter parametroIdDetalleIngreso = new MySqlParameter();
                parametroIdDetalleIngreso.ParameterName = "parIdDetalleIngreso";
                parametroIdDetalleIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleIngreso.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleIngreso);

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "parIdIngreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Value = DetalleIngreso.IdIngreso;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = DetalleIngreso.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroPrecioCompra = new MySqlParameter();
                parametroPrecioCompra.ParameterName = "parPrecioCompra";
                parametroPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioCompra.Value = DetalleIngreso.PrecioCompra;
                ComandoMySql.Parameters.Add(parametroPrecioCompra);

                MySqlParameter parametroPrecioVenta = new MySqlParameter();
                parametroPrecioVenta.ParameterName = "parPrecioVenta";
                parametroPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVenta.Value = DetalleIngreso.PrecioVenta;
                ComandoMySql.Parameters.Add(parametroPrecioVenta);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = DetalleIngreso.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroFechaProduccion = new MySqlParameter();
                parametroFechaProduccion.ParameterName = "parFechaProduccion";
                parametroFechaProduccion.MySqlDbType = MySqlDbType.Date;
                parametroFechaProduccion.Value = DetalleIngreso.FechaProduccion;
                ComandoMySql.Parameters.Add(parametroFechaProduccion);

                MySqlParameter parametroFechaVencimiento = new MySqlParameter();
                parametroFechaVencimiento.ParameterName = "parFechaVencimiento";
                parametroFechaVencimiento.MySqlDbType = MySqlDbType.Date;
                parametroFechaVencimiento.Value = DetalleIngreso.FechaVencimiento;
                ComandoMySql.Parameters.Add(parametroFechaVencimiento);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleIngreso.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del detalle de ingreso
                    IdDetalleIngreso = Convert.ToInt32(ComandoMySql.Parameters["parIdDetalleIngreso"].Value);
                    // Obtener el id del producto de la tabla detalle_ingreso
                    IdArticulo = Convert.ToInt32(ComandoMySql.Parameters["parIdArticulo"].Value);
                    foreach (DatosArticulo articulo in Articulo)
                    {
                        //producto.IdProducto = IdProducto;
                        //producto.Codigo = producto.Codigo;
                        //producto.Nombre = producto.Nombre;
                        //producto.IdCategoria = producto.IdCategoria;
                        //producto.Precio_Compra = Precio_Compra;
                        //producto.Precio_Venta = Precio_Venta;
                        //producto.Stock = producto.Stock + Cantidad;
                        //producto.IdPresentacion = producto.IdPresentacion;
                        //producto.Ruta_Imagen = producto.Ruta_Imagen;
                        //producto.Descripcion = producto.Descripcion;
                        //Llamar al metodo insertar de la clase DatosProducto
                        respuesta = articulo.Editar(articulo, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region EDITAR
        public string Editar(DatosDetalleIngreso DetalleIngreso, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        /*ATENCIÓN!! Al pasar por referencia ref MySqlConnection y ref MySqlTransaction se hará todo en una sola transacción y no se
         * combinarán los distintos ingresos que puedan estar llevandose a cabo en el mismo momento, esto permitirá que el 
         * programa pueda ser usado en red sin problemas*/
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarDetalleIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleIngreso = new MySqlParameter();
                parametroIdDetalleIngreso.ParameterName = "parIdDetalleIngreso";
                parametroIdDetalleIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleIngreso.Value = DetalleIngreso.IdDetalleIngreso;
                ComandoMySql.Parameters.Add(parametroIdDetalleIngreso);

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "parIdIngreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Value = DetalleIngreso.IdIngreso;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = DetalleIngreso.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroPrecioCompra = new MySqlParameter();
                parametroPrecioCompra.ParameterName = "parPrecioCompra";
                parametroPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioCompra.Value = DetalleIngreso.PrecioCompra;
                ComandoMySql.Parameters.Add(parametroPrecioCompra);

                MySqlParameter parametroPrecioVenta = new MySqlParameter();
                parametroPrecioVenta.ParameterName = "parPrecioVenta";
                parametroPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVenta.Value = DetalleIngreso.PrecioVenta;
                ComandoMySql.Parameters.Add(parametroPrecioVenta);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = DetalleIngreso.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroFechaProduccion = new MySqlParameter();
                parametroFechaProduccion.ParameterName = "parFechaProduccion";
                parametroFechaProduccion.MySqlDbType = MySqlDbType.Date;
                parametroFechaProduccion.Value = DetalleIngreso.FechaProduccion;
                ComandoMySql.Parameters.Add(parametroFechaProduccion);

                MySqlParameter parametroFechaVencimiento = new MySqlParameter();
                parametroFechaVencimiento.ParameterName = "parFechaVencimineto";
                parametroFechaVencimiento.MySqlDbType = MySqlDbType.Date;
                parametroFechaVencimiento.Value = DetalleIngreso.FechaVencimiento;
                ComandoMySql.Parameters.Add(parametroFechaVencimiento);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleIngreso.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region ELIMINAR DETALLE DE INGRESO
        public string EliminarDetalle(DatosDetalleIngreso DetalleIngreso)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarDetalleIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleIngreso = new MySqlParameter();
                parametroIdDetalleIngreso.ParameterName = "parIdDetalleIngreso";
                parametroIdDetalleIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleIngreso.Value = DetalleIngreso.IdDetalleIngreso;
                ComandoMySql.Parameters.Add(parametroIdDetalleIngreso);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar anular el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (MySqlConexion.State == ConnectionState.Open) MySqlConexion.Close();
            }
            return respuesta;
        }
        #endregion
    }
}
