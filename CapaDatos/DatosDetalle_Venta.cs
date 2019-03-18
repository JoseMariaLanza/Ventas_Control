using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDetalle_Venta
    {
        private int _IdDetalle_Venta;
        private int _IdVenta;
        private int _IdProducto;
        private decimal _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;
        private decimal _Subtotal;
        private int _IdDescuento;
        private bool _Insertar_Descuento;
        private int _Cantidad_Descuentos;

        #region PROPIEDADDES
        public int IdDetalle_Venta
        {
            get
            {
                return _IdDetalle_Venta;
            }

            set
            {
                _IdDetalle_Venta = value;
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

        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }

            set
            {
                _IdProducto = value;
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

        public decimal Precio_Venta
        {
            get
            {
                return _Precio_Venta;
            }

            set
            {
                _Precio_Venta = value;
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

        public bool Insertar_Descuento
        {
            get
            {
                return _Insertar_Descuento;
            }

            set
            {
                _Insertar_Descuento = value;
            }
        }

        public int Cantidad_Descuentos
        {
            get
            {
                return _Cantidad_Descuentos;
            }

            set
            {
                _Cantidad_Descuentos = value;
            }
        }
        #endregion

        public DatosDetalle_Venta()
        {

        }

        public DatosDetalle_Venta(int iddetalle_venta, int idventa, int idproducto, decimal cantidad, decimal precio_venta, decimal descuento, decimal subtotal, int iddescuento, bool insertar_descuento, int cantidad_descuentos)
        {
            IdDetalle_Venta = iddetalle_venta;
            IdVenta = idventa;
            IdProducto = idproducto;
            Cantidad = cantidad;
            Precio_Venta = precio_venta;
            Descuento = descuento;
            Subtotal = subtotal;
            IdDescuento = iddescuento;
            Insertar_Descuento = insertar_descuento;
            Cantidad_Descuentos = cantidad_descuentos;
        }
        //Método Insertar
        #region INSERTAR
        public string Insertar(DatosDetalle_Venta Detalle_Venta, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
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
                ComandoMySql.CommandText = "insertar_detalle_venta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDetalle_Venta = new MySqlParameter();
                parametroIdDetalle_Venta.ParameterName = "pariddetalle_venta";
                parametroIdDetalle_Venta.MySqlDbType = MySqlDbType.Int32;
                parametroIdDetalle_Venta.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDetalle_Venta);

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "paridventa";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = Detalle_Venta.IdVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdProducto = new MySqlParameter();
                parametroIdProducto.ParameterName = "paridproducto";
                parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdProducto.Value = Detalle_Venta.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdProducto);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parcantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = Detalle_Venta.Cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                MySqlParameter parametroPrecio_Venta = new MySqlParameter();
                parametroPrecio_Venta.ParameterName = "parprecio_venta";
                parametroPrecio_Venta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Venta.Value = Detalle_Venta.Precio_Venta;
                ComandoMySql.Parameters.Add(parametroPrecio_Venta);

                MySqlParameter parametroDescuento = new MySqlParameter();
                parametroDescuento.ParameterName = "pardescuento";
                parametroDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroDescuento.Value = Detalle_Venta.Descuento;
                ComandoMySql.Parameters.Add(parametroDescuento);

                MySqlParameter parametroSubtotal = new MySqlParameter();
                parametroSubtotal.ParameterName = "parsubtotal";
                parametroSubtotal.MySqlDbType = MySqlDbType.Decimal;
                parametroSubtotal.Value = Detalle_Venta.Subtotal;
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
