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
    public class DatosDetalle_Ingreso
    {
        private int _IdDetalle_Ingreso;
        private int _IdIngreso;
        private int _IdProducto;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private decimal _Cantidad;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;
        private decimal _Subtotal;

        public int IdDetalle_Ingreso
        {
            get
            {
                return _IdDetalle_Ingreso;
            }

            set
            {
                _IdDetalle_Ingreso = value;
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

        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }

            set
            {
                _IdProducto = value;
            }
        }

        public decimal Precio_Compra
        {
            get
            {
                return _Precio_Compra;
            }

            set
            {
                _Precio_Compra = value;
            }
        }

        public decimal Precio_Venta
        {
            get
            {
                return _Precio_Venta;
            }

            set
            {
                _Precio_Venta = value;
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

        public DateTime Fecha_Produccion
        {
            get
            {
                return _Fecha_Produccion;
            }

            set
            {
                _Fecha_Produccion = value;
            }
        }

        public DateTime Fecha_Vencimiento
        {
            get
            {
                return _Fecha_Vencimiento;
            }

            set
            {
                _Fecha_Vencimiento = value;
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

        //Constructores
        public DatosDetalle_Ingreso()
        {

        }

        public DatosDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idproducto, decimal precio_compra, decimal precio_venta,
            decimal cantidad, DateTime fecha_produccion, DateTime fecha_vencimiento, decimal subtotal)
        {
            IdDetalle_Ingreso = iddetalle_ingreso;
            IdIngreso = idingreso;
            IdProducto = idproducto;
            Precio_Compra = precio_compra;
            Precio_Venta = precio_venta;
            Cantidad = cantidad;
            Fecha_Produccion = fecha_produccion;
            Fecha_Vencimiento = fecha_vencimiento;
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
        public string Insertar(DatosDetalle_Ingreso Detalle_Ingreso, List<DatosProducto> Producto, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
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

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del detalle de ingreso
                    IdDetalle_Ingreso = Convert.ToInt32(ComandoMySql.Parameters["pariddetalle_ingreso"].Value);
                    // Obtener el id del producto de la tabla detalle_ingreso
                    IdProducto = Convert.ToInt32(ComandoMySql.Parameters["paridproducto"].Value);
                    foreach (DatosProducto producto in Producto)
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
                        respuesta = producto.Editar(producto, ref MySqlConexion, ref MySqlTransaccion);
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
        public string Editar(DatosDetalle_Ingreso Detalle_Ingreso, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
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
                ComandoMySql.CommandText = "editar_detalle_ingreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Ingreso = new MySqlParameter();
                parametroIdDetalle_Ingreso.ParameterName = "pariddetalle_ingreso";
                parametroIdDetalle_Ingreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Ingreso.Value = Detalle_Ingreso.IdDetalle_Ingreso;
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
        }
        #endregion

        #region ELIMINAR DETALLE DE INGRESO
        public string EliminarDetalle(DatosDetalle_Ingreso Detalle_Ingreso)
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
                ComandoMySql.CommandText = "eliminar_detalle_ingreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Ingreso = new MySqlParameter();
                parametroIdDetalle_Ingreso.ParameterName = "pariddetalle_ingreso";
                parametroIdDetalle_Ingreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Ingreso.Value = Detalle_Ingreso.IdDetalle_Ingreso;
                ComandoMySql.Parameters.Add(parametroIdDetalle_Ingreso);

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
