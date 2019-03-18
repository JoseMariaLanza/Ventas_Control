using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosGastos
    {
        private int _IdGasto;
        private string _Concepto;
        private string _Descripcíon;
        private decimal _Monto;
        private string _Periodo;
        private DateTime _Fecha;

        #region PROPIEDADES
        public int IdGasto
        {
            get
            {
                return _IdGasto;
            }

            set
            {
                _IdGasto = value;
            }
        }

        public string Concepto
        {
            get
            {
                return _Concepto;
            }

            set
            {
                _Concepto = value;
            }
        }

        public string Descripcíon
        {
            get
            {
                return _Descripcíon;
            }

            set
            {
                _Descripcíon = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return _Monto;
            }

            set
            {
                _Monto = value;
            }
        }

        public string Periodo
        {
            get
            {
                return _Periodo;
            }

            set
            {
                _Periodo = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        #endregion

        public DatosGastos()
        {

        }

        public DatosGastos(int idGasto, string concepto, string descripcion, decimal monto, string periodo, DateTime fecha)
        {
            IdGasto = idGasto;
            Concepto = concepto;
            Descripcíon = descripcion;
            Monto = monto;
            Periodo = periodo;
            Fecha = fecha;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listadoGastos = new DataTable("Gastos");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarGastos";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoGastos);

            }
            catch
            {
                listadoGastos = null;
            }
            return listadoGastos;

        }
        #endregion

        #region MOSTRAR ENTRE FECHAS
        public DataTable Mostrar(DateTime desde, DateTime hasta)
        {
            DataTable listadoGastos = new DataTable("Gastos");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySQL = new MySqlCommand();
                ComandoMySQL.Connection = MySqlConexion;
                ComandoMySQL.CommandType = CommandType.StoredProcedure;
                ComandoMySQL.CommandText = "spBuscarGastos";

                MySqlParameter parametroDesde = new MySqlParameter();
                parametroDesde.ParameterName = "parDesde";
                parametroDesde.MySqlDbType = MySqlDbType.DateTime;
                parametroDesde.Value = desde;
                ComandoMySQL.Parameters.Add(parametroDesde);

                MySqlParameter parametroHasta = new MySqlParameter();
                parametroHasta.ParameterName = "parHasta";
                parametroHasta.MySqlDbType = MySqlDbType.DateTime;
                parametroHasta.Value = hasta;
                ComandoMySQL.Parameters.Add(parametroHasta);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySQL);
                DatosMySql.Fill(listadoGastos);

            }
            catch
            {
                listadoGastos = null;
            }
            return listadoGastos;

        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosGastos Gastos)
        {
            string respuesta = "";
            //SqlConnection SqlConexion = new SqlConnection(); //SQL SERVER
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spInsertarGasto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdGasto = new MySqlParameter();
                parametroIdGasto.ParameterName = "parIdGasto";
                parametroIdGasto.MySqlDbType = MySqlDbType.Int32;
                parametroIdGasto.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdGasto);

                MySqlParameter parametroConcepto = new MySqlParameter();
                parametroConcepto.ParameterName = "parConcepto";
                parametroConcepto.MySqlDbType = MySqlDbType.VarChar;
                parametroConcepto.Value = Gastos.Concepto;
                ComandoMySql.Parameters.Add(parametroConcepto);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 255;
                parametroDescripcion.Value = Gastos.Descripcíon;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroMonto = new MySqlParameter();
                parametroMonto.ParameterName = "parMonto";
                parametroMonto.MySqlDbType = MySqlDbType.Decimal;
                parametroMonto.Value = Gastos.Monto;
                ComandoMySql.Parameters.Add(parametroMonto);

                MySqlParameter parametroPeriodo = new MySqlParameter();
                parametroPeriodo.ParameterName = "parPeriodo";
                parametroPeriodo.MySqlDbType = MySqlDbType.VarChar;
                parametroPeriodo.Size = 15;
                parametroPeriodo.Value = Gastos.Periodo;
                ComandoMySql.Parameters.Add(parametroPeriodo);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                //parametroFecha.Size = 6;
                parametroFecha.Value = Gastos.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

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

        #region EDITAR
        public string Editar(DatosGastos Gastos)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarGasto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdGasto = new MySqlParameter();
                parametroIdGasto.ParameterName = "parIdGasto";
                parametroIdGasto.MySqlDbType = MySqlDbType.Int32;
                parametroIdGasto.Value = Gastos.IdGasto;
                ComandoMySql.Parameters.Add(parametroIdGasto);

                MySqlParameter parametroConcepto = new MySqlParameter();
                parametroConcepto.ParameterName = "parConcepto";
                parametroConcepto.MySqlDbType = MySqlDbType.VarChar;
                parametroConcepto.Value = Gastos.Concepto;
                ComandoMySql.Parameters.Add(parametroConcepto);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 255;
                parametroDescripcion.Value = Gastos.Descripcíon;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroMonto = new MySqlParameter();
                parametroMonto.ParameterName = "parMonto";
                parametroMonto.MySqlDbType = MySqlDbType.Decimal;
                parametroMonto.Value = Gastos.Monto;
                ComandoMySql.Parameters.Add(parametroMonto);

                MySqlParameter parametroPeriodo = new MySqlParameter();
                parametroPeriodo.ParameterName = "parPeriodo";
                parametroPeriodo.MySqlDbType = MySqlDbType.VarChar;
                parametroPeriodo.Size = 15;
                parametroPeriodo.Value = Gastos.Periodo;
                ComandoMySql.Parameters.Add(parametroPeriodo);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                //parametroFecha.Size = 6;
                parametroFecha.Value = Gastos.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                // HACER EL FOREACH CORRESPONDIENTE PARA EDITAR EL DESCUENTO

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

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

        #region ELIMINAR
        public string Eliminar(DatosGastos Gastos)
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
                ComandoMySql.CommandText = "spEliminarGasto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdGasto = new MySqlParameter();
                parametroIdGasto.ParameterName = "parIdGasto";
                parametroIdGasto.MySqlDbType = MySqlDbType.Int32;
                parametroIdGasto.Value = Gastos.IdGasto;
                ComandoMySql.Parameters.Add(parametroIdGasto);

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
