using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleCaja
    {
        private int _IdDetalleCaja;
        private int _IdCaja;
        private int _IdCategoria;

        #region PROPIEDADES
        public int IdDetalleCaja
        {
            get
            {
                return _IdDetalleCaja;
            }

            set
            {
                _IdDetalleCaja = value;
            }
        }

        public int IdCaja
        {
            get
            {
                return _IdCaja;
            }

            set
            {
                _IdCaja = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }

            set
            {
                _IdCategoria = value;
            }
        }
        #endregion

        public DatosDetalleCaja() { }

        public DatosDetalleCaja(int idDetalleCaja, int idCaja, int idCategoria)
        {
            IdDetalleCaja = idDetalleCaja;
            IdCaja = idCaja;
            IdCategoria = idCategoria;

        }

        #region INSERTAR
        public string Insertar(DatosDetalleCaja Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleCaja = new MySqlParameter();
                parametroIdDetalleCaja.ParameterName = "parIdDetalleCaja";
                parametroIdDetalleCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleCaja.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleCaja);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Detalle.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Detalle.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region MOSTRAR
        public DataTable Mostrar(int idCaja)
        {
            DataTable listadoCaja = new DataTable("DetallesCaja");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDetallesCaja";

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = idCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoCaja);

            }
            catch
            {
                listadoCaja = null;
            }
            return listadoCaja;

        }
        #endregion

        #region EDITAR
        public string Editar(DatosDetalleCaja Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarDetalleCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleCaja = new MySqlParameter();
                parametroIdDetalleCaja.ParameterName = "parIdDetalleCaja";
                parametroIdDetalleCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleCaja.Value = Detalle.IdDetalleCaja;
                ComandoMySql.Parameters.Add(parametroIdDetalleCaja);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Detalle.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Detalle.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

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
        public string Eliminar(DatosDetalleCaja Detalle)
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
                ComandoMySql.CommandText = "spEliminarDetalleCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleCaja = new MySqlParameter();
                parametroIdDetalleCaja.ParameterName = "parIdDetalleCaja";
                parametroIdDetalleCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleCaja.Value = Detalle.IdDetalleCaja;
                ComandoMySql.Parameters.Add(parametroIdDetalleCaja);

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

        public string Eliminar(DatosDetalleCaja Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySQL
                //MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                //MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEliminarDetalleCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleCaja = new MySqlParameter();
                parametroIdDetalleCaja.ParameterName = "parIdDetalleCaja";
                parametroIdDetalleCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleCaja.Value = Detalle.IdDetalleCaja;
                ComandoMySql.Parameters.Add(parametroIdDetalleCaja);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar eliminar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion
    }
}
