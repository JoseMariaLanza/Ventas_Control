using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleCierre
    {
        private int _IdDetalleCierre;
        private int _IdCierre;
        private string _Moneda; // Longitud 20
        private string _Denominacion; // Longitud 20
        private int _Cantidad;
        private decimal _Subtotal;

        #region PROPIEDADES
        public int IdDetalleCierre
        {
            get
            {
                return _IdDetalleCierre;
            }

            set
            {
                _IdDetalleCierre = value;
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

        public string Moneda
        {
            get
            {
                return _Moneda;
            }

            set
            {
                _Moneda = value;
            }
        }

        public string Denominacion
        {
            get
            {
                return _Denominacion;
            }

            set
            {
                _Denominacion = value;
            }
        }

        public int Cantidad
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

        public decimal Subtotal
        {
            get
            {
                return _Subtotal;
            }

            set
            {
                _Subtotal = value;
            }
        }
        #endregion

        public DatosDetalleCierre() { }

        public DatosDetalleCierre(int idDetalleCierre, int idCierre, string moneda,
            string denominacion, int cantidad, decimal subtotal)
        {
            IdDetalleCierre = idDetalleCierre;
            IdCierre = idCierre;
            Moneda = moneda;
            Denominacion = denominacion;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }

        #region MOSTRAR
        public DataTable Mostrar(int idCierre)
        {
            DataTable listadoApertura = new DataTable("DetallesCierres");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDetallesCierres";

                MySqlParameter parametroIdCierre = new MySqlParameter();
                parametroIdCierre.ParameterName = "parIdCierre";
                parametroIdCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdCierre.Value = idCierre;
                ComandoMySql.Parameters.Add(parametroIdCierre);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoApertura);

            }
            catch
            {
                listadoApertura = null;
            }
            return listadoApertura;
        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosDetalleCierre Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleCierre";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleCierre = new MySqlParameter();
                parametroIdDetalleCierre.ParameterName = "parIdDetalleCierre";
                parametroIdDetalleCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleCierre.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleCierre);

                MySqlParameter parametroIdCierre = new MySqlParameter();
                parametroIdCierre.ParameterName = "parIdCierre";
                parametroIdCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdCierre.Value = Detalle.IdCierre;
                ComandoMySql.Parameters.Add(parametroIdCierre);

                MySqlParameter parametroMoneda = new MySqlParameter();
                parametroMoneda.ParameterName = "parMoneda";
                parametroMoneda.MySqlDbType = MySqlDbType.VarChar;
                parametroMoneda.Value = Detalle.Moneda;
                ComandoMySql.Parameters.Add(parametroMoneda);

                MySqlParameter parametroDenominacion = new MySqlParameter();
                parametroDenominacion.ParameterName = "parDenominacion";
                parametroDenominacion.MySqlDbType = MySqlDbType.VarChar;
                parametroDenominacion.Value = Detalle.Denominacion;
                ComandoMySql.Parameters.Add(parametroDenominacion);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = Detalle.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = Detalle.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region EDITAR
        public string Editar(DatosDetalleCierre Detalle, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarDetalleCierre";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleCierre = new MySqlParameter();
                parametroIdDetalleCierre.ParameterName = "parIdDetalleCierre";
                parametroIdDetalleCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleCierre.Value = Detalle.IdDetalleCierre;
                ComandoMySql.Parameters.Add(parametroIdDetalleCierre);

                MySqlParameter parametroIdCierre = new MySqlParameter();
                parametroIdCierre.ParameterName = "parIdCierre";
                parametroIdCierre.MySqlDbType = MySqlDbType.Int32;
                parametroIdCierre.Value = Detalle.IdCierre;
                ComandoMySql.Parameters.Add(parametroIdCierre);

                MySqlParameter parametroMoneda = new MySqlParameter();
                parametroMoneda.ParameterName = "parMoneda";
                parametroMoneda.MySqlDbType = MySqlDbType.VarChar;
                parametroMoneda.Value = Detalle.Moneda;
                ComandoMySql.Parameters.Add(parametroMoneda);

                MySqlParameter parametroDenominacion = new MySqlParameter();
                parametroDenominacion.ParameterName = "parDenominacion";
                parametroDenominacion.MySqlDbType = MySqlDbType.VarChar;
                parametroDenominacion.Value = Detalle.Denominacion;
                ComandoMySql.Parameters.Add(parametroDenominacion);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = Detalle.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = Detalle.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

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
