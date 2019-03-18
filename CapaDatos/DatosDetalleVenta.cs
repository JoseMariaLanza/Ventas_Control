using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalleVenta
    {
        private int _IdDetalleVenta;
        private int _IdVenta;
        private int _IdArticulo;
        private decimal _Cantidad;
        private decimal _PrecioVenta;
        private decimal _Descuento;
        private decimal _Subtotal;
        private int _IdDescuento;
        private bool _InsertarDescuento;
        private int _CantidadDescuento;

        #region PROPIEDADDES
        public int IdDetalleVenta
        {
            get
            {
                return _IdDetalleVenta;
            }

            set
            {
                _IdDetalleVenta = value;
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

        public int IdArticulo
        {
            get
            {
                return _IdArticulo;
            }

            set
            {
                _IdArticulo = value;
            }
        }

        public decimal Cantidad
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

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
            }
        }

        public decimal Descuento
        {
            get
            {
                return _Descuento;
            }

            set
            {
                _Descuento = value;
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

        public int IdDescuento
        {
            get
            {
                return _IdDescuento;
            }

            set
            {
                _IdDescuento = value;
            }
        }

        public bool InsertarDescuento
        {
            get
            {
                return _InsertarDescuento;
            }

            set
            {
                _InsertarDescuento = value;
            }
        }

        public int CantidadDescuento
        {
            get
            {
                return _CantidadDescuento;
            }

            set
            {
                _CantidadDescuento = value;
            }
        }
        #endregion

        public DatosDetalleVenta()
        {

        }

        public DatosDetalleVenta(int idDetalleVenta, int idVenta, int idArticulo, decimal cantidad, decimal precioVenta,
            decimal descuento, decimal subtotal, int idDescuento, bool insertarDescuento, int cantidadDescuento)
        {
            IdDetalleVenta = idDetalleVenta;
            IdVenta = idVenta;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            PrecioVenta = precioVenta;
            Descuento = descuento;
            Subtotal = subtotal;
            IdDescuento = idDescuento;
            InsertarDescuento = insertarDescuento;
            CantidadDescuento = cantidadDescuento;
        }
        //Método Insertar
        #region INSERTAR
        public string Insertar(DatosDetalleVenta DetalleVenta, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        /*ATENCIÓN!! Al pasar por referencia ref MySqlConnection y ref MySqlTransaction se hará todo en una sola transacción y no se
         * combinarán los distintos ingresos que puedan estar llevandose a cabo en el mismo momento, esto permitirá que el 
         * programa pueda ser usado en red sin problemas*/
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarDetalleVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalleVenta = new MySqlParameter();
                parametroIdDetalleVenta.ParameterName = "parIdDetalleVenta";
                parametroIdDetalleVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalleVenta.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalleVenta);

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = DetalleVenta.IdVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = DetalleVenta.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = DetalleVenta.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroPrecioVenta = new MySqlParameter();
                parametroPrecioVenta.ParameterName = "parPrecioVenta";
                parametroPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVenta.Value = DetalleVenta.PrecioVenta;
                ComandoMySql.Parameters.Add(parametroPrecioVenta);

                MySqlParameter parametroDescuento = new MySqlParameter();
                parametroDescuento.ParameterName = "parDescuento";
                parametroDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroDescuento.Value = DetalleVenta.Descuento;
                ComandoMySql.Parameters.Add(parametroDescuento);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parSubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = DetalleVenta.Subtotal;
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
