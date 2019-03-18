using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleDescuento
    {
        private int _IdDetalleDescuento;
        private int _IdDescuento;
        private int _IdArticulo;
        private decimal _Cantidad;
        private decimal _PorcentajeGanancia;
        private decimal _MontoInversion;
        private decimal _PrecioVentaDescuento;
        private bool _Actualizar;

        #region PROPIEDADES
        public int IdDetalleDescuento
        {
            get
            {
                return _IdDetalleDescuento;
            }

            set
            {
                _IdDetalleDescuento = value;
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

        public decimal PorcentajeGanancia
        {
            get
            {
                return _PorcentajeGanancia;
            }

            set
            {
                _PorcentajeGanancia = value;
            }
        }

        public decimal MontoInversion
        {
            get
            {
                return _MontoInversion;
            }

            set
            {
                _MontoInversion = value;
            }
        }

        public decimal PrecioVentaDescuento
        {
            get
            {
                return _PrecioVentaDescuento;
            }

            set
            {
                _PrecioVentaDescuento = value;
            }
        }

        public bool Actualizar
        {
            get
            {
                return _Actualizar;
            }

            set
            {
                _Actualizar = value;
            }
        }
        #endregion

        public DatosDetalleDescuento() { }

        public DatosDetalleDescuento(int idDetalleDescuento, int idDescuento, int idArticulo, decimal cantidad, decimal porcentajeGanancia, decimal montoInversion,
            decimal precioVentaDescuento, bool actualizar)
        {
            IdDetalleDescuento = idDetalleDescuento;
            IdDescuento = idDescuento;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            PorcentajeGanancia = porcentajeGanancia;
            MontoInversion = montoInversion;
            PrecioVentaDescuento = precioVentaDescuento;
            Actualizar = actualizar;
        }

        #region MOSTRAR
        //public DataTable Mostrar()
        //{
        //    DataTable listadoDescuento = new DataTable("DetallesDescuento");
        //    MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;
        //        ComandoMySql.CommandText = "spMostrarDetallesDescuento";

        //        MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
        //        DatosMySql.Fill(listadoDescuento);

        //    }
        //    catch
        //    {
        //        listadoDescuento = null;
        //    }
        //    return listadoDescuento;

        //}

        public DataTable Mostrar(int idDescuento)
        {
            DataTable listado = new DataTable("DetallesDescuento");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spMostrarDetallesDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = idDescuento;
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
        public string Insertar(DatosDetalleDescuento Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
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
                ComandoMySql.CommandText = "spInsertarDetalleDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleDescuento = new MySqlParameter();
                parametroIdDetalleDescuento.ParameterName = "parIdDetalleDescuento";
                parametroIdDetalleDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleDescuento.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleDescuento);

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = Detalle.IdDescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = Detalle.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = Detalle.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroPorcentajeGanancia = new MySqlParameter();
                parametroPorcentajeGanancia.ParameterName = "parPorcentajeGanancia";
                parametroPorcentajeGanancia.MySqlDbType = MySqlDbType.Decimal;
                parametroPorcentajeGanancia.Value = Detalle.PorcentajeGanancia;
                ComandoMySql.Parameters.Add(parametroPorcentajeGanancia);

                MySqlParameter parametroMontoInversion = new MySqlParameter();
                parametroMontoInversion.ParameterName = "parMontoInversion";
                parametroMontoInversion.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoInversion.Value = Detalle.MontoInversion;
                ComandoMySql.Parameters.Add(parametroMontoInversion);

                MySqlParameter parametroPrecioVentaDescuento = new MySqlParameter();
                parametroPrecioVentaDescuento.ParameterName = "parPrecioVentaDescuento";
                parametroPrecioVentaDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVentaDescuento.Value = Detalle.PrecioVentaDescuento;
                ComandoMySql.Parameters.Add(parametroPrecioVentaDescuento);

                MySqlParameter parametroActualizar = new MySqlParameter();
                parametroActualizar.ParameterName = "parActualizar";
                parametroActualizar.MySqlDbType = MySqlDbType.Byte;
                parametroActualizar.Value = Detalle.Actualizar;
                ComandoMySql.Parameters.Add(parametroActualizar);

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
        public string Eliminar(DatosDetalleDescuento Detalle)
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
                ComandoMySql.CommandText = "spEliminarDetalleDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleDescuento = new MySqlParameter();
                parametroIdDetalleDescuento.ParameterName = "parIdDetalleDescuento";
                parametroIdDetalleDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleDescuento.Value = Detalle.IdDetalleDescuento;
                ComandoMySql.Parameters.Add(parametroIdDetalleDescuento);

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
