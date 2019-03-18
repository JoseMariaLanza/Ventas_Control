using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalle_Deuda
    {
        private int _IdDetalle_Deuda;
        private int _IdDeuda;
        private int _Numero_Pago;
        private decimal _Monto;
        private DateTime _Fecha_Pago;

        #region PROPIEDADDES
        public int IdDetalle_Deuda
        {
            get
            {
                return _IdDetalle_Deuda;
            }

            set
            {
                _IdDetalle_Deuda = value;
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

        public int Numero_Pago
        {
            get
            {
                return _Numero_Pago;
            }

            set
            {
                _Numero_Pago = value;
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

        public DateTime Fecha_Pago
        {
            get
            {
                return _Fecha_Pago;
            }

            set
            {
                _Fecha_Pago = value;
            }
        }

        #endregion

        public DatosDetalle_Deuda()
        {

        }

        public DatosDetalle_Deuda(int iddetalle_deuda, int iddeuda, int numero_pago, decimal monto, DateTime fecha_pago)
        {
            IdDetalle_Deuda = iddetalle_deuda;
            IdDeuda = iddeuda;
            Numero_Pago = numero_pago;
            Monto = monto;
            Fecha_Pago = fecha_pago;
        }

        #region INSERTAR
        public string Insertar(DatosDetalle_Deuda Detalle_Deuda, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "insertar_detalle_deuda";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Deuda = new MySqlParameter();
                parametroIdDetalle_Deuda.ParameterName = "pariddetalle_deuda";
                parametroIdDetalle_Deuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Deuda.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalle_Deuda);

                MySqlParameter parametroIdDeuda = new MySqlParameter();
                parametroIdDeuda.ParameterName = "pariddeuda";
                parametroIdDeuda.MySqlDbType = MySqlDbType.Int32;
                parametroIdDeuda.Value = Detalle_Deuda.IdDeuda;
                ComandoMySql.Parameters.Add(parametroIdDeuda);

                MySqlParameter parametroNumero_Pago = new MySqlParameter();
                parametroNumero_Pago.ParameterName = "parnumero_pago";
                parametroNumero_Pago.MySqlDbType = MySqlDbType.Int32;
                parametroNumero_Pago.Value = Detalle_Deuda.Numero_Pago;
                ComandoMySql.Parameters.Add(parametroNumero_Pago);

                MySqlParameter parametroMonto = new MySqlParameter();
                parametroMonto.ParameterName = "parmonto";
                parametroMonto.MySqlDbType = MySqlDbType.Decimal;
                parametroMonto.Value = Detalle_Deuda.Monto;
                ComandoMySql.Parameters.Add(parametroMonto);

                MySqlParameter parametroFecha_Pago = new MySqlParameter();
                parametroFecha_Pago.ParameterName = "parfecha_pago";
                parametroFecha_Pago.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha_Pago.Value = Detalle_Deuda.Fecha_Pago;
                ComandoMySql.Parameters.Add(parametroFecha_Pago);

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
