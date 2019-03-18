using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosApertura
    {
        private int _IdApertura;
        private int _IdCaja;
        private int _IdEmpleado;
        private DateTime _FechaHora;
        private decimal _MontoInicial;

        #region APERTURA PREDEFINIDA
        private int _IdAperturaPredefinida;
        private string _Descripcion;
        #endregion

        #region PROPIEDADES
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

        public decimal MontoInicial
        {
            get
            {
                return _MontoInicial;
            }

            set
            {
                _MontoInicial = value;
            }
        }

        public int IdAperturaPredefinida
        {
            get
            {
                return _IdAperturaPredefinida;
            }

            set
            {
                _IdAperturaPredefinida = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }
        #endregion

        public DatosApertura() { }

        public DatosApertura(int idApertura, int idCaja, int idEmpleado, DateTime fechaHora, decimal montoInicial, bool aperturaPorDefecto, 
            int idAperturaPredefinida, string descripcion)
        {
            IdApertura = idApertura;
            IdCaja = idCaja;
            IdEmpleado = idEmpleado;
            FechaHora = fechaHora;
            MontoInicial = montoInicial;
            IdAperturaPredefinida = idAperturaPredefinida;
            Descripcion = descripcion;
        }

        #region MOSTRAR
        public DataTable Mostrar(int idCaja)
        {
            DataTable listado = new DataTable("Apertura");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarApertura";

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = idCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listado);
            }
            catch
            {
                listado = null;
            }
            return listado;
        }

        public DataTable MostrarAperturasPredefinidas()
        {
            DataTable listado = new DataTable("AperturasPredefinidas");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarAperturasPredefinidas";

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

        #region BUSCAR
        public DataTable BuscarAperturaPredefinida(int idAperturaPredefinida)
        {
            DataTable AperturaPorDefecto = new DataTable("AperturaPorDefecto");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spBuscarAperturaPredefinida";

                MySqlParameter parametroIdAperturaPredefinida = new MySqlParameter();
                parametroIdAperturaPredefinida.ParameterName = "parIdAperturaPredefinida";
                parametroIdAperturaPredefinida.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaPredefinida.Value = idAperturaPredefinida;
                ComandoMySql.Parameters.Add(parametroIdAperturaPredefinida);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(AperturaPorDefecto);

            }
            catch
            {
                AperturaPorDefecto = null;
            }
            return AperturaPorDefecto;

        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosApertura Apertura, List<DatosDetalleApertura> Detalle, DatosAperturaCierre AperturaCierre, ref int idAperturaCierre)
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
                ComandoMySql.CommandText = "spInsertarApertura";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdApertura = new MySqlParameter();
                parametroIdApertura.ParameterName = "parIdApertura";
                parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdApertura.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Apertura.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Apertura.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFechaHora = new MySqlParameter();
                parametroFechaHora.ParameterName = "parFechaHora";
                parametroFechaHora.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaHora.Value = Apertura.FechaHora;
                ComandoMySql.Parameters.Add(parametroFechaHora);

                MySqlParameter parametroMontoInicial = new MySqlParameter();
                parametroMontoInicial.ParameterName = "parMontoInicial";
                parametroMontoInicial.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoInicial.Value = Apertura.MontoInicial;
                ComandoMySql.Parameters.Add(parametroMontoInicial);

                //MySqlParameter parametroAperturaPorDefecto = new MySqlParameter();
                //parametroAperturaPorDefecto.ParameterName = "parAperturaPorDefecto";
                //parametroAperturaPorDefecto.MySqlDbType = MySqlDbType.Byte;
                //parametroAperturaPorDefecto.Value = Apertura.AperturaPorDefecto;
                //ComandoMySql.Parameters.Add(parametroAperturaPorDefecto);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdApertura = Convert.ToInt32(ComandoMySql.Parameters["parIdApertura"].Value);
                    foreach (DatosDetalleApertura detalle in Detalle)
                    {
                        detalle.IdApertura = IdApertura;
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        //DatosAperturaCierre AperturaCierre = new DatosAperturaCierre();
                        AperturaCierre.IdApertura = IdApertura;
                        respuesta = AperturaCierre.Insertar(AperturaCierre, ref idAperturaCierre, ref MySqlConexion, ref MySqlTransaccion);
                    }
                }
                
                if (respuesta.Equals("OK"))
                {
                    DatosCaja Caja = new DatosCaja();
                    Caja.IdCaja = IdCaja;
                    respuesta = Caja.Abrir(Caja, ref MySqlConexion, ref MySqlTransaccion);
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

        public string InsertarAperturaPredefinida(DatosApertura Apertura, List<DatosDetalleApertura> Detalle, ref int IdAperturaPorDefecto)
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
                ComandoMySql.CommandText = "spInsertarAperturaPredefinida";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdAperturaPredefinida = new MySqlParameter();
                parametroIdAperturaPredefinida.ParameterName = "parIdAperturaPredefinida";
                parametroIdAperturaPredefinida.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaPredefinida.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdAperturaPredefinida);

                //MySqlParameter parametroIdApertura = new MySqlParameter();
                //parametroIdApertura.ParameterName = "parIdApertura";
                //parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                //parametroIdApertura.Value = Apertura.IdApertura;
                //ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Apertura.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Apertura.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFechaHora = new MySqlParameter();
                parametroFechaHora.ParameterName = "parFechaHora";
                parametroFechaHora.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaHora.Value = Apertura.FechaHora;
                ComandoMySql.Parameters.Add(parametroFechaHora);

                MySqlParameter parametroMontoInicial = new MySqlParameter();
                parametroMontoInicial.ParameterName = "parMontoInicial";
                parametroMontoInicial.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoInicial.Value = Apertura.MontoInicial;
                ComandoMySql.Parameters.Add(parametroMontoInicial);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.String;
                parametroDescripcion.Value = Apertura.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdAperturaPredefinida = Convert.ToInt32(ComandoMySql.Parameters["parIdAperturaPredefinida"].Value);
                    IdAperturaPorDefecto = IdAperturaPredefinida;
                    
                    foreach (DatosDetalleApertura detalle in Detalle)
                    {
                        detalle.IdAperturaPredefinida = IdAperturaPredefinida;
                        respuesta = detalle.InsertarDetalleAperturaPredefinida(detalle, ref MySqlConexion, ref MySqlTransaccion);
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
        public string Editar(DatosApertura Apertura, List<DatosDetalleApertura> Detalle)
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
                ComandoMySql.CommandText = "spEditarApertura";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdApertura = new MySqlParameter();
                parametroIdApertura.ParameterName = "parIdApertura";
                parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdApertura.Value = Apertura.IdApertura;
                ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "paridCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Apertura.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Apertura.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFechaHora = new MySqlParameter();
                parametroFechaHora.ParameterName = "parFechaHora";
                parametroFechaHora.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaHora.Value = Apertura.FechaHora;
                ComandoMySql.Parameters.Add(parametroFechaHora);

                MySqlParameter parametroMontoInicial = new MySqlParameter();
                parametroMontoInicial.ParameterName = "parMontoIncial";
                parametroMontoInicial.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoInicial.Value = Apertura.MontoInicial;
                ComandoMySql.Parameters.Add(parametroMontoInicial);

                //MySqlParameter parametroAperturaPorDefecto = new MySqlParameter();
                //parametroAperturaPorDefecto.ParameterName = "parAperturaPorDefecto";
                //parametroAperturaPorDefecto.MySqlDbType = MySqlDbType.Byte;
                //parametroAperturaPorDefecto.Value = Apertura.AperturaPorDefecto;
                //ComandoMySql.Parameters.Add(parametroAperturaPorDefecto);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdApertura = Convert.ToInt32(ComandoMySql.Parameters["parIdApertura"].Value);
                    foreach (DatosDetalleApertura detalle in Detalle)
                    {
                        respuesta = detalle.Editar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        ////DatosAperturaCierre AperturaCierre = new DatosAperturaCierre();
                        ////AperturaCierre.IdAperturaCierre = idaperturacierre;
                        //AperturaCierre.IdApertura = IdApertura;
                        ////AperturaCierre.Estado = estado;
                        //respuesta = AperturaCierre.Insertar(AperturaCierre, ref MySqlConexion, ref MySqlTransaccion);
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

        public string EditarAperturaPredefinida(DatosApertura Apertura, List<DatosDetalleApertura> Detalle)
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
                ComandoMySql.CommandText = "spEditarAperturaPredefinida";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdAperturaPredefinida = new MySqlParameter();
                parametroIdAperturaPredefinida.ParameterName = "parIdAperturaPredefinida";
                parametroIdAperturaPredefinida.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaPredefinida.Value = Apertura.IdAperturaPredefinida;
                ComandoMySql.Parameters.Add(parametroIdAperturaPredefinida);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "paridCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Apertura.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Apertura.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFechaHora = new MySqlParameter();
                parametroFechaHora.ParameterName = "parFechaHora";
                parametroFechaHora.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaHora.Value = Apertura.FechaHora;
                ComandoMySql.Parameters.Add(parametroFechaHora);

                MySqlParameter parametroMontoInicial = new MySqlParameter();
                parametroMontoInicial.ParameterName = "parMontoIncial";
                parametroMontoInicial.MySqlDbType = MySqlDbType.Decimal;
                parametroMontoInicial.Value = Apertura.MontoInicial;
                ComandoMySql.Parameters.Add(parametroMontoInicial);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.String;
                parametroDescripcion.Value = Apertura.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                //MySqlParameter parametroAperturaPorDefecto = new MySqlParameter();
                //parametroAperturaPorDefecto.ParameterName = "parAperturaPorDefecto";
                //parametroAperturaPorDefecto.MySqlDbType = MySqlDbType.Byte;
                //parametroAperturaPorDefecto.Value = Apertura.AperturaPorDefecto;
                //ComandoMySql.Parameters.Add(parametroAperturaPorDefecto);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdAperturaPredefinida = Convert.ToInt32(ComandoMySql.Parameters["parIdAperturaPredefinida"].Value);
                    foreach (DatosDetalleApertura detalle in Detalle)
                    {
                        respuesta = detalle.EditarDetalleAperturaPredefinida(detalle, ref MySqlConexion, ref MySqlTransaccion);
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
