using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosCategoriaCaja
    {
        private int _IdCategoriaCaja;
        private int _IdCaja;
        private int _IdCategoria;

        #region PROPIEDADES
        public int IdCategoriaCaja
        {
            get
            {
                return _IdCategoriaCaja;
            }

            set
            {
                _IdCategoriaCaja = value;
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

        public DatosCategoriaCaja() { }

        public DatosCategoriaCaja(int idcategoriaCaja, int idcaja, int idcategoria)
        {
            IdCategoriaCaja = idcategoriaCaja;
            IdCaja = idcaja;
            IdCategoria = idcategoria;

        }

        #region INSERTAR
        public string Insertar(DatosCategoriaCaja categoriaCaja, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "insertar_categoria_caja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCategoriaCaja = new MySqlParameter();
                parametroIdCategoriaCaja.ParameterName = "parIdCategoriaCaja";
                parametroIdCategoriaCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoriaCaja.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdCategoriaCaja);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = categoriaCaja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = categoriaCaja.IdCategoria;
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

        #region BUSCAR
        public DataTable Buscar(int idcaja)
        {
            DataTable litadoCaja = new DataTable("CategoriaCaja");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "buscar_categoria_caja";

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = idcaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(litadoCaja);

            }
            catch
            {
                litadoCaja = null;
            }
            return litadoCaja;

        }
        #endregion

        #region EDITAR
        public string Editar(DatosCategoriaCaja categoriaCaja, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "editar_categoria_caja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCategoriaCaja = new MySqlParameter();
                parametroIdCategoriaCaja.ParameterName = "parIdCategoriaCaja";
                parametroIdCategoriaCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoriaCaja.Value = categoriaCaja.IdCategoriaCaja;
                ComandoMySql.Parameters.Add(parametroIdCategoriaCaja);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = categoriaCaja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = categoriaCaja.IdCategoria;
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
        public string Eliminar(DatosCategoriaCaja categoriaCaja)
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
                ComandoMySql.CommandText = "eliminar_categoria_caja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCategoriaCaja = new MySqlParameter();
                parametroIdCategoriaCaja.ParameterName = "parIdCategoriaCaja";
                parametroIdCategoriaCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoriaCaja.Value = categoriaCaja.IdCategoriaCaja;
                ComandoMySql.Parameters.Add(parametroIdCategoriaCaja);

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

        public string Eliminar(DatosCategoriaCaja categoriaCaja, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
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
                ComandoMySql.CommandText = "eliminar_categoria_caja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCategoriaCaja = new MySqlParameter();
                parametroIdCategoriaCaja.ParameterName = "parIdCategoriaCaja";
                parametroIdCategoriaCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoriaCaja.Value = categoriaCaja.IdCategoriaCaja;
                ComandoMySql.Parameters.Add(parametroIdCategoriaCaja);

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
