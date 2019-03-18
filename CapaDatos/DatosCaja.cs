using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosCaja
    {
        #region VARIABLES
        private int _IdCaja;
        private string _Caja;
        private string _FormaCobro;
        private bool _AperturaAutomatica;
        private string _Terminal;
        #endregion

        #region PROPIEDADES
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

        public string Caja
        {
            get
            {
                return _Caja;
            }

            set
            {
                _Caja = value;
            }
        }

        public string FormaCobro
        {
            get
            {
                return _FormaCobro;
            }

            set
            {
                _FormaCobro = value;
            }
        }

        public bool AperturaAutomatica
        {
            get
            {
                return _AperturaAutomatica;
            }

            set
            {
                _AperturaAutomatica = value;
            }
        }

        public string Terminal
        {
            get
            {
                return _Terminal;
            }

            set
            {
                _Terminal = value;
            }
        }
        #endregion

        public DatosCaja() { }

        public DatosCaja(int idCaja, string caja, string formaCobro, bool aperturaAutomatica, string terminal)
        {
            IdCaja = idCaja;
            Caja = caja;
            FormaCobro = formaCobro;
            AperturaAutomatica = aperturaAutomatica;
            Terminal = terminal;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listadoCaja = new DataTable("Caja");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarCajas";

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

        #region BUSCAR
        public DataTable Buscar(string caja)
        {
            DataTable litadoCaja = new DataTable("Caja");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spBuscarCaja";

                MySqlParameter parametroCaja = new MySqlParameter();
                parametroCaja.ParameterName = "parCaja";
                parametroCaja.MySqlDbType = MySqlDbType.VarChar;
                parametroCaja.Size = 30;
                parametroCaja.Value = caja;
                ComandoMySql.Parameters.Add(parametroCaja);

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

        #region INSERTAR
        public string Insertar(DatosCaja Caja, List<DatosDetalleCaja> DetallesCaja)
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
                ComandoMySql.CommandText = "spInsertarCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroCaja = new MySqlParameter();
                parametroCaja.ParameterName = "parCaja";
                parametroCaja.MySqlDbType = MySqlDbType.VarChar;
                parametroCaja.Size = 30;
                parametroCaja.Value = Caja.Caja;
                ComandoMySql.Parameters.Add(parametroCaja);

                MySqlParameter parametroFormaCobro = new MySqlParameter();
                parametroFormaCobro.ParameterName = "parFormaCobro";
                parametroFormaCobro.MySqlDbType = MySqlDbType.VarChar;
                parametroFormaCobro.Size = 20;
                parametroFormaCobro.Value = Caja.FormaCobro;
                ComandoMySql.Parameters.Add(parametroFormaCobro);

                MySqlParameter parametroAperturaAutomatica = new MySqlParameter();
                parametroAperturaAutomatica.ParameterName = "parAperturaAutomatica";
                parametroAperturaAutomatica.MySqlDbType = MySqlDbType.Byte;
                parametroAperturaAutomatica.Value = Caja.AperturaAutomatica;
                ComandoMySql.Parameters.Add(parametroAperturaAutomatica);

                MySqlParameter parametroTerminal = new MySqlParameter();
                parametroTerminal.ParameterName = "parTerminal";
                parametroTerminal.MySqlDbType = MySqlDbType.VarChar;
                parametroTerminal.Size = 45;
                parametroTerminal.Value = Caja.Terminal;
                ComandoMySql.Parameters.Add(parametroTerminal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdCaja = Convert.ToInt32(ComandoMySql.Parameters["parIdCaja"].Value);
                    foreach (DatosDetalleCaja detalleCaja in DetallesCaja)
                    {
                        detalleCaja.IdCaja = IdCaja;
                        respuesta = detalleCaja.Insertar(detalleCaja, ref MySqlConexion, ref MySqlTransaccion);
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

        #region EDITAR
        public string Editar(DatosCaja Caja, List<DatosDetalleCaja> DetallesCaja)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Caja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroCaja = new MySqlParameter();
                parametroCaja.ParameterName = "parCaja";
                parametroCaja.MySqlDbType = MySqlDbType.VarChar;
                parametroCaja.Size = 30;
                parametroCaja.Value = Caja.Caja;
                ComandoMySql.Parameters.Add(parametroCaja);

                MySqlParameter parametroFormaCobro = new MySqlParameter();
                parametroFormaCobro.ParameterName = "parFormaCobro";
                parametroFormaCobro.MySqlDbType = MySqlDbType.VarChar;
                parametroFormaCobro.Size = 20;
                parametroFormaCobro.Value = Caja.FormaCobro;
                ComandoMySql.Parameters.Add(parametroFormaCobro);

                MySqlParameter parametroAperturaAutomatica = new MySqlParameter();
                parametroAperturaAutomatica.ParameterName = "parAperturaAutomatica";
                parametroAperturaAutomatica.MySqlDbType = MySqlDbType.Byte;
                parametroAperturaAutomatica.Value = Caja.AperturaAutomatica;
                ComandoMySql.Parameters.Add(parametroAperturaAutomatica);

                MySqlParameter parametroTerminal = new MySqlParameter();
                parametroTerminal.ParameterName = "parTerminal";
                parametroTerminal.MySqlDbType = MySqlDbType.VarChar;
                parametroTerminal.Size = 45;
                parametroTerminal.Value = Caja.Terminal;
                ComandoMySql.Parameters.Add(parametroTerminal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    foreach (DatosDetalleCaja detalleCaja in DetallesCaja)
                    {
                        if (detalleCaja.IdDetalleCaja < 1)
                        {
                            respuesta = detalleCaja.Insertar(detalleCaja, ref MySqlConexion, ref MySqlTransaccion);
                        }
                        else
                        {
                            respuesta = detalleCaja.Editar(detalleCaja, ref MySqlConexion, ref MySqlTransaccion);
                        }
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

        #region ELIMINAR
        public string Eliminar(DatosCaja Caja)
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
                ComandoMySql.CommandText = "spEliminarCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Caja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

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

        public string Eliminar(DatosCaja Caja, List<DatosDetalleCaja> DetallesCaja)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Caja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar eliminar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    foreach (DatosDetalleCaja detalleCaja in DetallesCaja)
                    {
                        detalleCaja.IdDetalleCaja = Convert.ToInt32(ComandoMySql.Parameters["parIdDetalleCaja"].Value);
                        respuesta = detalleCaja.Eliminar(detalleCaja, ref MySqlConexion, ref MySqlTransaccion);
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

        #region ABRIR
        public string Abrir(DatosCaja Caja, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spAbrirCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Caja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region CERRAR
        public string Cerrar(DatosCaja Caja, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spCerrarCaja";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Caja.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

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
