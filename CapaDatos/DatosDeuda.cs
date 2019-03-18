using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDeuda
    {
        private int _IdDeuda;
        private int _IdVenta;
        private int _CantidadPagos;
        private decimal _TotalPagado;
        private decimal _Interes;
        private string _Estado;
        private string _Descripcion;

        #region PROPIEDADES
        public int IdDeuda
        {
            get
            {
                return _IdDeuda;
            }

            set
            {
                _IdDeuda = value;
            }
        }

        public int IdVenta
        {
            get
            {
                return _IdVenta;
            }

            set
            {
                _IdVenta = value;
            }
        }

        public int CantidadPagos
        {
            get
            {
                return _CantidadPagos;
            }

            set
            {
                _CantidadPagos = value;
            }
        }

        public decimal TotalPagado
        {
            get
            {
                return _TotalPagado;
            }

            set
            {
                _TotalPagado = value;
            }
        }

        public decimal Interes
        {
            get
            {
                return _Interes;
            }

            set
            {
                _Interes = value;
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

        public DatosDeuda()
        {

        }

        public DatosDeuda(int idDeuda, int idVenta, int cantidadPagos, decimal totalPagado, decimal interes, string descripcion)
        {
            IdDeuda = idDeuda;
            IdVenta = idVenta;
            CantidadPagos = cantidadPagos;
            TotalPagado = totalPagado;
            Interes = interes;
            Descripcion = descripcion;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Deudas");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDeudas";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listado);
            }
            catch // Exception ex
            {
                listado = null;
            }
            return listado;
        }

        public DataTable MostrarDeudores()
        {
            DataTable listado = new DataTable("Deudores");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDeudores";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listado);
            }
            catch // Exception ex
            {
                listado = null;
            }
            return listado;
        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosDeuda Deuda, List<DatosDetalleDeuda> Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                //MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                //MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDeuda";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDeuda = new MySqlParameter();
                parametroIdDeuda.ParameterName = "parIdDeuda";
                parametroIdDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDeuda.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDeuda);

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = Deuda.IdVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroCantidadPagos = new MySqlParameter();
                parametroCantidadPagos.ParameterName = "parCantidadPagos";
                parametroCantidadPagos.MySqlDbType = MySqlDbType.Int32;
                parametroCantidadPagos.Value = Deuda.CantidadPagos;
                ComandoMySql.Parameters.Add(parametroCantidadPagos);

                MySqlParameter parametroTotalPagado = new MySqlParameter();
                parametroTotalPagado.ParameterName = "parTotalPagado";
                parametroTotalPagado.MySqlDbType = MySqlDbType.Decimal;
                parametroTotalPagado.Value = Deuda.TotalPagado;
                ComandoMySql.Parameters.Add(parametroTotalPagado);

                MySqlParameter parametroInteres = new MySqlParameter();
                parametroInteres.ParameterName = "parInteres";
                parametroInteres.MySqlDbType = MySqlDbType.Decimal;
                parametroInteres.Value = Deuda.Interes;
                ComandoMySql.Parameters.Add(parametroInteres);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Value = Deuda.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdDeuda = Convert.ToInt32(ComandoMySql.Parameters["parIdDeuda"].Value);
                    foreach (DatosDetalleDeuda detalle in Detalle)
                    {
                        detalle.IdDeuda = IdDeuda;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                //if (respuesta.Equals("OK"))
                //{
                //    MySqlTransaccion.Commit();
                //}
                //else
                //{
                //    MySqlTransaccion.Rollback();
                //}
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
        public string Editar(DatosDeuda Deuda, DatosCliente Cliente)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarDeuda";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDeuda = new MySqlParameter();
                parametroIdDeuda.ParameterName = "parIdDeuda";
                parametroIdDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDeuda.Value = Deuda.IdDeuda;
                ComandoMySql.Parameters.Add(parametroIdDeuda);

                MySqlParameter parametroTotalPagado = new MySqlParameter();
                parametroTotalPagado.ParameterName = "parTotalPagado";
                parametroTotalPagado.MySqlDbType = MySqlDbType.Decimal;
                parametroTotalPagado.Value = Deuda.TotalPagado;
                ComandoMySql.Parameters.Add(parametroTotalPagado);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 50;
                parametroEstado.Value = Deuda.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    respuesta = Cliente.EditarEstado(Cliente, ref MySqlConexion, ref MySqlTransaccion);
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

        public string Editar(DatosDeuda Deuda)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarDeuda";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDeuda = new MySqlParameter();
                parametroIdDeuda.ParameterName = "parIdDeuda";
                parametroIdDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDeuda.Value = Deuda.IdDeuda;
                ComandoMySql.Parameters.Add(parametroIdDeuda);

                MySqlParameter parametroTotalPagado = new MySqlParameter();
                parametroTotalPagado.ParameterName = "parTotalPagado";
                parametroTotalPagado.MySqlDbType = MySqlDbType.Decimal;
                parametroTotalPagado.Value = Deuda.TotalPagado;
                ComandoMySql.Parameters.Add(parametroTotalPagado);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.Byte;
                parametroEstado.Value = Deuda.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

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
    }
}
