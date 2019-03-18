using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleApertura
    {
        private int _IdDetalleApertura;
        private int _IdApertura;
        private string _FormaCobro; // Longitud 20
        private string _Moneda; // Longitud 20
        private string _Denominacion; // Longitud 20
        private int _Cantidad;
        private decimal _Subtotal;

        #region DETALLES APERTURA PREDEFINIDA
        private int _IdDetalleAperturaPredefinida;
        private int _IdAperturaPredefinida;
        #endregion

        #region PROPIEDADES
        public int IdDetalleApertura
        {
            get
            {
                return _IdDetalleApertura;
            }

            set
            {
                _IdDetalleApertura = value;
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

        public int IdDetalleAperturaPredefinida
        {
            get
            {
                return _IdDetalleAperturaPredefinida;
            }

            set
            {
                _IdDetalleAperturaPredefinida = value;
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
        #endregion

        public DatosDetalleApertura() { }

        public DatosDetalleApertura(int idDetalleApertura, int idApertura, string formaCobro, string moneda,
            string denominacion, int cantidad, decimal subtotal, int idDetalleAperturaPredefinida, int idAperturaPredefinida)
        {
            IdDetalleApertura = idDetalleApertura;
            IdApertura = idApertura;
            FormaCobro = formaCobro;
            Moneda = moneda;
            Denominacion = denominacion;
            Cantidad = cantidad;
            Subtotal = subtotal;
            IdDetalleAperturaPredefinida = idDetalleAperturaPredefinida;
            IdAperturaPredefinida = idAperturaPredefinida;
        }

        #region MOSTRAR
        public DataTable Mostrar(int idApertura)
        {
            DataTable listadoApertura = new DataTable("DetallesApertura");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDetallesApertura";

                MySqlParameter parametroIdApertura = new MySqlParameter();
                parametroIdApertura.ParameterName = "parIdApertura";
                parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdApertura.Value = idApertura;
                ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoApertura);

            }
            catch
            {
                listadoApertura = null;
            }
            return listadoApertura;
        }

        public DataTable MostrarDetallesAperturaPredefinida(int idAperturaPredefinida)
        {
            DataTable listadoApertura = new DataTable("DetallesAperturaPredefinida");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDetallesAperturaPredefinida";

                MySqlParameter parametroIdAperturaPredefinida = new MySqlParameter();
                parametroIdAperturaPredefinida.ParameterName = "parIdAperturaPredefinida";
                parametroIdAperturaPredefinida.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaPredefinida.Value = idAperturaPredefinida;
                ComandoMySql.Parameters.Add(parametroIdAperturaPredefinida);

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
        public string Insertar(DatosDetalleApertura DetalleApertura, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleApertura";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleApertura = new MySqlParameter();
                parametroIdDetalleApertura.ParameterName = "parIdDetalleApertura";
                parametroIdDetalleApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleApertura.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleApertura);

                MySqlParameter parametroIdApertura = new MySqlParameter();
                parametroIdApertura.ParameterName = "parIdApertura";
                parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdApertura.Value = DetalleApertura.IdApertura;
                ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlParameter parametroFormaCobro = new MySqlParameter();
                parametroFormaCobro.ParameterName = "parFormaCobro";
                parametroFormaCobro.MySqlDbType = MySqlDbType.VarChar;
                parametroFormaCobro.Value = DetalleApertura.FormaCobro;
                ComandoMySql.Parameters.Add(parametroFormaCobro);

                MySqlParameter parametroMoneda = new MySqlParameter();
                parametroMoneda.ParameterName = "parMoneda";
                parametroMoneda.MySqlDbType = MySqlDbType.VarChar;
                parametroMoneda.Value = DetalleApertura.Moneda;
                ComandoMySql.Parameters.Add(parametroMoneda);

                MySqlParameter parametroDenominacion = new MySqlParameter();
                parametroDenominacion.ParameterName = "parDenominacion";
                parametroDenominacion.MySqlDbType = MySqlDbType.VarChar;
                parametroDenominacion.Value = DetalleApertura.Denominacion;
                ComandoMySql.Parameters.Add(parametroDenominacion);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = DetalleApertura.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleApertura.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string InsertarDetalleAperturaPredefinida(DatosDetalleApertura DetalleApertura, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleAperturaPredefinida";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleApertura = new MySqlParameter();
                parametroIdDetalleApertura.ParameterName = "parIdDetalleAperturaPredefinida";
                parametroIdDetalleApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleApertura.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleApertura);

                MySqlParameter parametroIdAperturaPredefinida = new MySqlParameter();
                parametroIdAperturaPredefinida.ParameterName = "parIdAperturaPredefinida";
                parametroIdAperturaPredefinida.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaPredefinida.Value = DetalleApertura.IdAperturaPredefinida;
                ComandoMySql.Parameters.Add(parametroIdAperturaPredefinida);

                MySqlParameter parametroFormaCobro = new MySqlParameter();
                parametroFormaCobro.ParameterName = "parFormaCobro";
                parametroFormaCobro.MySqlDbType = MySqlDbType.VarChar;
                parametroFormaCobro.Value = DetalleApertura.FormaCobro;
                ComandoMySql.Parameters.Add(parametroFormaCobro);

                MySqlParameter parametroMoneda = new MySqlParameter();
                parametroMoneda.ParameterName = "parMoneda";
                parametroMoneda.MySqlDbType = MySqlDbType.VarChar;
                parametroMoneda.Value = DetalleApertura.Moneda;
                ComandoMySql.Parameters.Add(parametroMoneda);

                MySqlParameter parametroDenominacion = new MySqlParameter();
                parametroDenominacion.ParameterName = "parDenominacion";
                parametroDenominacion.MySqlDbType = MySqlDbType.VarChar;
                parametroDenominacion.Value = DetalleApertura.Denominacion;
                ComandoMySql.Parameters.Add(parametroDenominacion);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = DetalleApertura.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleApertura.Subtotal;
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
        public string Editar(DatosDetalleApertura DetalleApertura, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarDetalleApertura";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleApertura = new MySqlParameter();
                parametroIdDetalleApertura.ParameterName = "parIdDetalleApertura";
                parametroIdDetalleApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleApertura.Value = DetalleApertura.IdDetalleApertura;
                ComandoMySql.Parameters.Add(parametroIdDetalleApertura);

                MySqlParameter parametroIdApertura = new MySqlParameter();
                parametroIdApertura.ParameterName = "parIdApertura";
                parametroIdApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdApertura.Value = DetalleApertura.IdApertura;
                ComandoMySql.Parameters.Add(parametroIdApertura);

                MySqlParameter parametroFormaCobro = new MySqlParameter();
                parametroFormaCobro.ParameterName = "parFormaCobro";
                parametroFormaCobro.MySqlDbType = MySqlDbType.VarChar;
                parametroFormaCobro.Value = DetalleApertura.FormaCobro;
                ComandoMySql.Parameters.Add(parametroFormaCobro);

                MySqlParameter parametroMoneda = new MySqlParameter();
                parametroMoneda.ParameterName = "parMoneda";
                parametroMoneda.MySqlDbType = MySqlDbType.VarChar;
                parametroMoneda.Value = DetalleApertura.Moneda;
                ComandoMySql.Parameters.Add(parametroMoneda);

                MySqlParameter parametroDenominacion = new MySqlParameter();
                parametroDenominacion.ParameterName = "parDenominacion";
                parametroDenominacion.MySqlDbType = MySqlDbType.VarChar;
                parametroDenominacion.Value = DetalleApertura.Denominacion;
                ComandoMySql.Parameters.Add(parametroDenominacion);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = DetalleApertura.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleApertura.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

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

        public string EditarDetalleAperturaPredefinida(DatosDetalleApertura DetalleApertura, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarDetalleAperturaPredefinida";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleApertura = new MySqlParameter();
                parametroIdDetalleApertura.ParameterName = "parIdDetalleAperturaPredefinida";
                parametroIdDetalleApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleApertura.Value = DetalleApertura.IdDetalleApertura;
                ComandoMySql.Parameters.Add(parametroIdDetalleApertura);

                MySqlParameter parametroIdAperturaPredefinida = new MySqlParameter();
                parametroIdAperturaPredefinida.ParameterName = "parIdAperturaPredefinida";
                parametroIdAperturaPredefinida.MySqlDbType = MySqlDbType.Int32;
                parametroIdAperturaPredefinida.Value = DetalleApertura.IdAperturaPredefinida;
                ComandoMySql.Parameters.Add(parametroIdAperturaPredefinida);

                MySqlParameter parametroFormaCobro = new MySqlParameter();
                parametroFormaCobro.ParameterName = "parFormaCobro";
                parametroFormaCobro.MySqlDbType = MySqlDbType.VarChar;
                parametroFormaCobro.Value = DetalleApertura.FormaCobro;
                ComandoMySql.Parameters.Add(parametroFormaCobro);

                MySqlParameter parametroMoneda = new MySqlParameter();
                parametroMoneda.ParameterName = "parMoneda";
                parametroMoneda.MySqlDbType = MySqlDbType.VarChar;
                parametroMoneda.Value = DetalleApertura.Moneda;
                ComandoMySql.Parameters.Add(parametroMoneda);

                MySqlParameter parametroDenominacion = new MySqlParameter();
                parametroDenominacion.ParameterName = "parDenominacion";
                parametroDenominacion.MySqlDbType = MySqlDbType.VarChar;
                parametroDenominacion.Value = DetalleApertura.Denominacion;
                ComandoMySql.Parameters.Add(parametroDenominacion);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = DetalleApertura.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleApertura.Subtotal;
                ComandoMySql.Parameters.Add(parametroSubtotal);

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

        public string Eliminar(int iddetalleapertura)
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
                ComandoMySql.CommandText = "spEliminarDetalleApertura";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleApertura = new MySqlParameter();
                parametroIdDetalleApertura.ParameterName = "parIdDetalleApertura";
                parametroIdDetalleApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleApertura.Value = iddetalleapertura;
                ComandoMySql.Parameters.Add(parametroIdDetalleApertura);

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

        public string EliminarDetalleAperturaPredefinida(int iddetalleapertura)
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
                ComandoMySql.CommandText = "spEliminarDetalleAperturaPredefinida";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleApertura = new MySqlParameter();
                parametroIdDetalleApertura.ParameterName = "parIdDetalleAperturaPredefinida";
                parametroIdDetalleApertura.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleApertura.Value = iddetalleapertura;
                ComandoMySql.Parameters.Add(parametroIdDetalleApertura);

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