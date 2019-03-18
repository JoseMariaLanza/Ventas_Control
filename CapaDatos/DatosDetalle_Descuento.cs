using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalle_Descuento
    {
        private int _IdDetalle_Descuento;
        private int _IdDescuento;
        private int _IdProducto;
        private decimal _Cantidad;
        private decimal _Porcentaje_Ganancia;
        private decimal _Precio_Inversion;
        private decimal _Precio_Venta_Descuento;
        private bool _Actualizacion_Automatica;


        #region PROPIEDADES
        public int IdDetalle_Descuento
        {
            get
            {
                return _IdDetalle_Descuento;
            }

            set
            {
                _IdDetalle_Descuento = value;
            }
        }

        public int IdDescuento
        {
            get
            {
                return _IdDescuento;
            }

            set
            {
                _IdDescuento = value;
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

        public decimal Porcentaje_Ganancia
        {
            get
            {
                return _Porcentaje_Ganancia;
            }

            set
            {
                _Porcentaje_Ganancia = value;
            }
        }

        public decimal Precio_Inversion
        {
            get
            {
                return _Precio_Inversion;
            }

            set
            {
                _Precio_Inversion = value;
            }
        }

        public decimal Precio_Venta_Descuento
        {
            get
            {
                return _Precio_Venta_Descuento;
            }

            set
            {
                _Precio_Venta_Descuento = value;
            }
        }

        public bool Actualizacion_Automatica
        {
            get
            {
                return _Actualizacion_Automatica;
            }

            set
            {
                _Actualizacion_Automatica = value;
            }
        }
        #endregion

        public DatosDetalle_Descuento() { }

        public DatosDetalle_Descuento(int iddetalle_descuento, int iddescuento, int idproducto, decimal cantidad, decimal porcentaje_ganancia, decimal precio_inversion,
            decimal precio_venta_descuento, bool actualizacion_automatica)
        {
            IdDetalle_Descuento = iddetalle_descuento;
            IdDescuento = iddescuento;
            IdProducto = idproducto;
            Cantidad = cantidad;
            Porcentaje_Ganancia = porcentaje_ganancia;
            Precio_Inversion = precio_inversion;
            Precio_Venta_Descuento = precio_venta_descuento;
            Actualizacion_Automatica = actualizacion_automatica;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listadoDescuento = new DataTable("detalle_descuento");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "mostrar_detalle_descuento";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoDescuento);

            }
            catch
            {
                listadoDescuento = null;
            }
            return listadoDescuento;

        }

        public DataTable MostrarDetalle_Descuento(int iddescuento)
        {
            DataTable listado = new DataTable("detalle_descuento");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "mostrar_detalle_descuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "pariddescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = iddescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listado);

            }
            catch
            {
                listado = null;
            }
            return listado;
        }
        #endregion

        //Método Insertar
        #region INSERTAR
        public string Insertar(DatosDetalle_Descuento Detalle_Descuento, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
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
                ComandoMySql.CommandText = "insertar_detalle_descuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Descuento = new MySqlParameter();
                parametroIdDetalle_Descuento.ParameterName = "pariddetalle_descuento";
                parametroIdDetalle_Descuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Descuento.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalle_Descuento);

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "pariddescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = Detalle_Descuento.IdDescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlParameter parametroIdProducto = new MySqlParameter();
                parametroIdProducto.ParameterName = "paridproducto";
                parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdProducto.Value = Detalle_Descuento.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdProducto);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parcantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = Detalle_Descuento.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroPorcentaje_Ganancia = new MySqlParameter();
                parametroPorcentaje_Ganancia.ParameterName = "parporcentaje_ganancia";
                parametroPorcentaje_Ganancia.MySqlDbType = MySqlDbType.Decimal;
                parametroPorcentaje_Ganancia.Value = Detalle_Descuento.Porcentaje_Ganancia;
                ComandoMySql.Parameters.Add(parametroPorcentaje_Ganancia);

                MySqlParameter parametroPrecio_Inversion = new MySqlParameter();
                parametroPrecio_Inversion.ParameterName = "parprecio_inversion";
                parametroPrecio_Inversion.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Inversion.Value = Detalle_Descuento.Precio_Inversion;
                ComandoMySql.Parameters.Add(parametroPrecio_Inversion);

                MySqlParameter parametroPrecio_Venta_Descuento = new MySqlParameter();
                parametroPrecio_Venta_Descuento.ParameterName = "parprecio_venta_descuento";
                parametroPrecio_Venta_Descuento.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Venta_Descuento.Value = Detalle_Descuento.Precio_Venta_Descuento;
                ComandoMySql.Parameters.Add(parametroPrecio_Venta_Descuento);

                MySqlParameter parametroActualizacion_Automatica = new MySqlParameter();
                parametroActualizacion_Automatica.ParameterName = "paractualizacion_automatica";
                parametroActualizacion_Automatica.MySqlDbType = MySqlDbType.Byte;
                parametroActualizacion_Automatica.Value = Detalle_Descuento.Actualizacion_Automatica;
                ComandoMySql.Parameters.Add(parametroActualizacion_Automatica);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region ELIMINAR
        public string Eliminar(DatosDetalle_Descuento Detalle_Descuento)
        {
            string respuesta = "";
            //SqlConnection SqlConexion = new SqlConnection(); //SQL SERVER
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "eliminar_detalle_descuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Descuento = new MySqlParameter();
                parametroIdDetalle_Descuento.ParameterName = "pariddetalle_descuento";
                parametroIdDetalle_Descuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Descuento.Value = Detalle_Descuento.IdDetalle_Descuento;
                ComandoMySql.Parameters.Add(parametroIdDetalle_Descuento);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar eliminar el registro. Intente nuevamente.";

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
