using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleDeuda
    {
        private int _IdDetalleDeuda;
        private int _IdDeuda;
        private int _NumeroPago;
        private decimal _Monto;
        private DateTime _FechaPago;
        private bool _Pagado;

        #region PROPIEDADDES
        public int IdDetalleDeuda
        {
            get
            {
                return _IdDetalleDeuda;
            }

            set
            {
                _IdDetalleDeuda = value;
            }
        }

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

        public int NumeroPago
        {
            get
            {
                return _NumeroPago;
            }

            set
            {
                _NumeroPago = value;
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

        public DateTime FechaPago
        {
            get
            {
                return _FechaPago;
            }

            set
            {
                _FechaPago = value;
            }
        }

        public bool Pagado
        {
            get
            {
                return _Pagado;
            }

            set
            {
                _Pagado = value;
            }
        }

        #endregion

        public DatosDetalleDeuda()
        {

        }

        public DatosDetalleDeuda(int idDetalleDeuda, int idDeuda, int numeroPago, decimal monto, DateTime fechaPago, bool pagado)
        {
            IdDetalleDeuda = idDetalleDeuda;
            IdDeuda = idDeuda;
            NumeroPago = numeroPago;
            Monto = monto;
            FechaPago = fechaPago;
            Pagado = pagado;
        }

        #region MOSTRAR
        public DataTable Mostrar(DatosDetalleDeuda detallesDeuda)
        {
            DataTable listado = new DataTable("DetallesDeuda");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDetallesDeuda";

                MySqlParameter parametroIdDeuda = new MySqlParameter();
                parametroIdDeuda.ParameterName = "parIdDeuda";
                parametroIdDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDeuda.Value = detallesDeuda.IdDeuda;
                ComandoMySql.Parameters.Add(parametroIdDeuda);

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

        #region INSERTAR
        public string Insertar(DatosDetalleDeuda Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleDeuda";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleDeuda = new MySqlParameter();
                parametroIdDetalleDeuda.ParameterName = "parIdDetalleDeuda";
                parametroIdDetalleDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleDeuda.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleDeuda);

                MySqlParameter parametroIdDeuda = new MySqlParameter();
                parametroIdDeuda.ParameterName = "parIdDeuda";
                parametroIdDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDeuda.Value = Detalle.IdDeuda;
                ComandoMySql.Parameters.Add(parametroIdDeuda);

                MySqlParameter parametroNumeroPago = new MySqlParameter();
                parametroNumeroPago.ParameterName = "parNumeroPago";
                parametroNumeroPago.MySqlDbType = MySqlDbType.Int32;
                parametroNumeroPago.Value = Detalle.NumeroPago;
                ComandoMySql.Parameters.Add(parametroNumeroPago);

                MySqlParameter parametroMonto = new MySqlParameter();
                parametroMonto.ParameterName = "parMonto";
                parametroMonto.MySqlDbType = MySqlDbType.Decimal;
                parametroMonto.Value = Detalle.Monto;
                ComandoMySql.Parameters.Add(parametroMonto);

                MySqlParameter parametroFechaPago = new MySqlParameter();
                parametroFechaPago.ParameterName = "parFechaPago";
                parametroFechaPago.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaPago.Value = Detalle.FechaPago;
                ComandoMySql.Parameters.Add(parametroFechaPago);

                MySqlParameter parametroPagado = new MySqlParameter();
                parametroPagado.ParameterName = "parPagado";
                parametroPagado.MySqlDbType = MySqlDbType.Byte;
                parametroPagado.Value = Detalle.Pagado;
                ComandoMySql.Parameters.Add(parametroPagado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region AGREGAR PAGO
        public string AgregarPago(DatosDetalleDeuda detalleDeuda)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                //MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spAgregarPago";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleDeuda = new MySqlParameter();
                parametroIdDetalleDeuda.ParameterName = "parIdDetalleDeuda";
                parametroIdDetalleDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleDeuda.Value = detalleDeuda.IdDetalleDeuda;
                ComandoMySql.Parameters.Add(parametroIdDetalleDeuda);

                MySqlParameter parametroNumeroPago = new MySqlParameter();
                parametroNumeroPago.ParameterName = "parNumeroPago";
                parametroNumeroPago.MySqlDbType = MySqlDbType.Int32;
                parametroNumeroPago.Value = detalleDeuda.NumeroPago;
                ComandoMySql.Parameters.Add(parametroNumeroPago);

                MySqlParameter parametroMonto = new MySqlParameter();
                parametroMonto.ParameterName = "parMonto";
                parametroMonto.MySqlDbType = MySqlDbType.Decimal;
                parametroMonto.Value = detalleDeuda.Monto;
                ComandoMySql.Parameters.Add(parametroMonto);

                MySqlParameter parametroFechaPago = new MySqlParameter();
                parametroFechaPago.ParameterName = "parFechaPago";
                parametroFechaPago.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaPago.Value = detalleDeuda.FechaPago;
                ComandoMySql.Parameters.Add(parametroFechaPago);

                MySqlParameter parametroPagado = new MySqlParameter();
                parametroPagado.ParameterName = "parPagado";
                parametroPagado.MySqlDbType = MySqlDbType.Byte;
                parametroPagado.Value = detalleDeuda.Pagado;
                ComandoMySql.Parameters.Add(parametroPagado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

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
            finally
            {
                if (MySqlConexion.State == ConnectionState.Open) MySqlConexion.Close();
            }
            return respuesta;
        }
        #endregion
    }
}
