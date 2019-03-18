using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosAperturaCierre
    {
        private int _IdAperturaCierre;
        private int _IdApertura;
        private int _IdCierre;
        private decimal _Diferencia;
        private string _Estado;

        #region PROPIEDADES
        public int IdAperturaCierre
        {
            get
            {
                return _IdAperturaCierre;
            }

            set
            {
                _IdAperturaCierre = value;
            }
        }

        public int IdApertura
        {
            get
            {
                return _IdApertura;
            }

            set
            {
                _IdApertura = value;
            }
        }

        public int IdCierre
        {
            get
            {
                return _IdCierre;
            }

            set
            {
                _IdCierre = value;
            }
        }

        public decimal Diferencia
        {
            get
            {
                return _Diferencia;
            }

            set
            {
                _Diferencia = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }
        #endregion

        public DatosAperturaCierre() { }

        public DatosAperturaCierre(int idAperturaCierre, int idApertura, int idCierre, decimal diferencia, string estado)
        {
            IdAperturaCierre = idAperturaCierre;
            IdApertura = idApertura;
            IdCierre = idCierre;
            Diferencia = diferencia;
            Estado = estado;
        }
        
        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listadoAperturaCierre = new DataTable("AperturasCierres");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarAperturasCierres";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoAperturaCierre);

            }
            catch
            {
                listadoAperturaCierre = null;
            }
            return listadoAperturaCierre;
        }
        #endregion

        #region BUSCAR
        public DataTable Buscar(DateTime desde, DateTime hasta)
        {
            DataTable listadoAperturaCierre = new DataTable("AperturasCierres");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spBuscarAperturasCierres";

                MySqlParameter parametroDesde = new MySqlParameter();
                parametroDesde.ParameterName = "parDesde";
                parametroDesde.MySqlDbType = MySqlDbType.DateTime;
                parametroDesde.Value = desde;
                ComandoMySql.Parameters.Add(parametroDesde);

                MySqlParameter parametroHasta = new MySqlParameter();
                parametroHasta.ParameterName = "parHasta";
                parametroHasta.MySqlDbType = MySqlDbType.DateTime;
                parametroHasta.Value = hasta;
                ComandoMySql.Parameters.Add(parametroHasta);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoAperturaCierre);

            }
            catch
            {
                listadoAperturaCierre = null;
            }
            return listadoAperturaCierre;

        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosAperturaCierre AperturaCierre, ref int idAperturaCierre, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarAperturaCierre";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdAperturaCierre = new MySqlParameter();
                parametroIdAperturaCierre.ParameterName = "parIdAperturaCierre";
                parametroIdAperturaCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaCierre.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdAperturaCierre);

                MySqlParameter parametroIdApertura = new MySqlParameter();
                parametroIdApertura.ParameterName = "parIdApertura";
                parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdApertura.Value = AperturaCierre.IdApertura;
                ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Value = AperturaCierre.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                idAperturaCierre = Convert.ToInt32(ComandoMySql.Parameters["parIdAperturaCierre"].Value);
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            //finally
            //{
            //    if (MySqlConexion.State == ConnectionState.Open) MySqlConexion.Close();
            //}
            return respuesta;
        }
        #endregion

        #region EDITAR
        public string Editar(DatosAperturaCierre AperturaCierre, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarAperturaCierre";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdAperturaCierre = new MySqlParameter();
                parametroIdAperturaCierre.ParameterName = "parIdAperturaCierre";
                parametroIdAperturaCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaCierre.Value = AperturaCierre.IdAperturaCierre;
                ComandoMySql.Parameters.Add(parametroIdAperturaCierre);

                MySqlParameter parametroIdCierre = new MySqlParameter();
                parametroIdCierre.ParameterName = "parIdCierre";
                parametroIdCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdCierre.Value = AperturaCierre.IdCierre;
                ComandoMySql.Parameters.Add(parametroIdCierre);

                MySqlParameter parametroDiferencia = new MySqlParameter();
                parametroDiferencia.ParameterName = "parDiferencia";
                parametroDiferencia.MySqlDbType = MySqlDbType.Decimal;
                parametroDiferencia.Value = AperturaCierre.Diferencia;
                ComandoMySql.Parameters.Add(parametroDiferencia);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Value = AperturaCierre.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

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
