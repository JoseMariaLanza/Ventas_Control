using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosCierre
    {
        private int _IdCierre;
        private int _IdCaja;
        private int _IdEmpleado;
        private DateTime _FechaHora;
        private decimal _MontoFinalSistema;
        private decimal _MontoFinalReal;

        #region PROPIEDADES
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

        public int IdEmpleado
        {
            get
            {
                return _IdEmpleado;
            }

            set
            {
                _IdEmpleado = value;
            }
        }

        public DateTime FechaHora
        {
            get
            {
                return _FechaHora;
            }

            set
            {
                _FechaHora = value;
            }
        }

        public decimal MontoFinalSistema
        {
            get
            {
                return _MontoFinalSistema;
            }

            set
            {
                _MontoFinalSistema = value;
            }
        }

        public decimal MontoFinalReal
        {
            get
            {
                return _MontoFinalReal;
            }

            set
            {
                _MontoFinalReal = value;
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
        #endregion

        public DatosCierre() { }

        public DatosCierre(int idCaja, int idCierre, int idEmpleado, DateTime fechaHora, decimal montoFinalSistema,
            decimal montoFinalReal)
        {
            IdCierre = idCierre;
            IdCaja = idCaja;
            IdEmpleado = idEmpleado;
            FechaHora = fechaHora;
            MontoFinalSistema = montoFinalSistema;
            MontoFinalReal = montoFinalReal;
        }

        #region MOSTRAR
        public DataTable Mostrar(int idCierre)
        {
            DataTable listadoCierre = new DataTable("Cierre");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarCierres";

                MySqlParameter parametroIdCierre = new MySqlParameter();
                parametroIdCierre.ParameterName = "parIdCaja";
                parametroIdCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdCierre.Value = idCierre;
                ComandoMySql.Parameters.Add(parametroIdCierre);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoCierre);

            }
            catch
            {
                listadoCierre = null;
            }
            return listadoCierre;
        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosCierre Cierre, List<DatosDetalleCierre> Detalle, DatosAperturaCierre AperturaCierre)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarCierre";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdcierre = new MySqlParameter();
                parametroIdcierre.ParameterName = "parIdCierre";
                parametroIdcierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdcierre.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdcierre);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Cierre.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Cierre.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFechaHora = new MySqlParameter();
                parametroFechaHora.ParameterName = "parFechaHora";
                parametroFechaHora.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaHora.Value = Cierre.FechaHora;
                ComandoMySql.Parameters.Add(parametroFechaHora);

                MySqlParameter parametroMontoFinalSistema = new MySqlParameter();
                parametroMontoFinalSistema.ParameterName = "parMontoFinalSistema";
                parametroMontoFinalSistema.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoFinalSistema.Value = Cierre.MontoFinalSistema;
                ComandoMySql.Parameters.Add(parametroMontoFinalSistema);

                MySqlParameter parametroMontoFinalReal = new MySqlParameter();
                parametroMontoFinalReal.ParameterName = "parMontoFinalReal";
                parametroMontoFinalReal.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoFinalReal.Value = Cierre.MontoFinalReal;
                ComandoMySql.Parameters.Add(parametroMontoFinalReal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdCierre = Convert.ToInt32(ComandoMySql.Parameters["parIdCierre"].Value);
                    foreach (DatosDetalleCierre detalle in Detalle)
                    {
                        detalle.IdCierre = IdCierre;
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        AperturaCierre.IdCierre = IdCierre;
                        respuesta = AperturaCierre.Editar(AperturaCierre, ref MySqlConexion, ref MySqlTransaccion);
                    }
                }

                if (respuesta.Equals("OK"))
                {
                    DatosCaja Caja = new DatosCaja();
                    Caja.IdCaja = IdCaja;
                    respuesta = Caja.Cerrar(Caja, ref MySqlConexion, ref MySqlTransaccion);
                }

                if (respuesta.Equals("OK"))
                {
                    MySqlTransaccion.Commit();
                }
                else
                {
                    MySqlTransaccion.Rollback();
                }

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
        public string Editar(DatosCierre Cierre, List<DatosDetalleCierre> Detalle, List<DatosAperturaCierre> AperturaCierre)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarCierre";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdcierre = new MySqlParameter();
                parametroIdcierre.ParameterName = "parIdCierre";
                parametroIdcierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdcierre.Value = Cierre.IdCierre;
                ComandoMySql.Parameters.Add(parametroIdcierre);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Cierre.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFechaHora = new MySqlParameter();
                parametroFechaHora.ParameterName = "parFechaHora";
                parametroFechaHora.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaHora.Value = Cierre.FechaHora;
                ComandoMySql.Parameters.Add(parametroFechaHora);

                MySqlParameter parametroMontoFinalSistema = new MySqlParameter();
                parametroMontoFinalSistema.ParameterName = "parMontoFinalSistema";
                parametroMontoFinalSistema.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoFinalSistema.Value = Cierre.MontoFinalSistema;
                ComandoMySql.Parameters.Add(parametroMontoFinalSistema);

                MySqlParameter parametroMontoFinalReal = new MySqlParameter();
                parametroMontoFinalReal.ParameterName = "parMontoFinalReal";
                parametroMontoFinalReal.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoFinalReal.Value = Cierre.MontoFinalReal;
                ComandoMySql.Parameters.Add(parametroMontoFinalReal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdCierre = Convert.ToInt32(ComandoMySql.Parameters["parIdCierre"].Value);
                    foreach (DatosDetalleCierre detalle in Detalle)
                    {
                        respuesta = detalle.Editar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (respuesta.Equals("OK"))
                {
                    foreach (DatosAperturaCierre aperturaCierre in AperturaCierre)
                    {
                        //respuesta = aperturaCierre.Insertar(aperturaCierre, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (respuesta.Equals("OK"))
                {
                    MySqlTransaccion.Commit();
                }
                else
                {
                    MySqlTransaccion.Rollback();
                }

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
