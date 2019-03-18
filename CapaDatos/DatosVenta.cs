using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosVenta
    {
        private int _IdVenta;
        private int _IdCaja;
        private int _IdCliente;
        private int _IdEmpleado;
        private DateTime _Fecha;
        private string _TipoComprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _IVA;
        private decimal _Descuento;
        private decimal _Total;
        private string _Estado;
        private int _IdDescuento;
        private bool _InsertarDescuento;

        #region PROPIEDADES
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

        public int IdCliente
        {
            get
            {
                return _IdCliente;
            }

            set
            {
                _IdCliente = value;
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

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public string TipoComprobante
        {
            get
            {
                return _TipoComprobante;
            }

            set
            {
                _TipoComprobante = value;
            }
        }

        public string Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
            }
        }

        public string Correlativo
        {
            get
            {
                return _Correlativo;
            }

            set
            {
                _Correlativo = value;
            }
        }

        public decimal IVA
        {
            get
            {
                return _IVA;
            }

            set
            {
                _IVA = value;
            }
        }

        public decimal Total
        {
            get
            {
                return _Total;
            }

            set
            {
                _Total = value;
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
        #endregion

        public DatosVenta()
        {

        }

        public DatosVenta(int idVenta, int idCaja, int idCliente, int idEmpleado, DateTime fecha, string tipoComprobante, string serie, string correlativo, decimal iva, decimal descuento, decimal total, string estado, int idDescuento, bool insertarDescuento)
        {
            IdVenta = idVenta;
            IdCaja = idCaja;
            IdCliente = idCliente;
            IdEmpleado = idEmpleado;
            Fecha = fecha;
            TipoComprobante = tipoComprobante;
            Serie = serie;
            Correlativo = correlativo;
            IVA = iva;
            Descuento = descuento;
            Total = total;
            Estado = estado;
            IdDescuento = idDescuento;
            InsertarDescuento = insertarDescuento;
        }

        //Metodos
        #region MOSTRAR

        #region MOSTRAR VENTA
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Ventas");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarVentas";

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

        #region MOSTRAR DEUDORES
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

        #region MOSTRAR DETALLE DE LA VENTA
        public DataTable Mostrar(int idVenta)
        {
            DataTable listado = new DataTable("DetallesVenta");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spMostrarDetallesVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = idVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

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

        //#region MOSTRAR ARTICULOS

        //DESHABILITADO PORQUE SE ELIMINÓ EL SP "mostrar_articulo_venta" DE LA BASE DE DATOS
        //#region MOSTRAR ARTICULOS DISPONIBLES PARA LA VENTA
        //public DataTable MostrarArticuloVenta()
        //{
        //    DataTable listado = new DataTable("articuloVenta");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;
        //        ComandoMySql.CommandText = "mostrar_articulo_venta";

        //        MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
        //        DatosMySql.Fill(listado);
        //    }
        //    catch //(Exception ex)
        //    {
        //        listado = null;
        //    }
        //    return listado;
        //}
        //#endregion


        //#region POR NOMBRE
        //public DataTable MostrarArticuloVentaNombre(String TextoBuscar)
        //{
        //    DataTable listado = new DataTable("articulo");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_articulo_venta_nombre";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = TextoBuscar;
        //        ComandoMySql.Parameters.Add(parametroTextoBuscar);

        //        MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
        //        DatosMySql.Fill(listado);

        //    }
        //    catch //(Exception ex)
        //    {
        //        listado = null;
        //    }
        //    return listado;
        //}
        //#endregion

        //#region POR CODIGO
        //public DataTable MostrarArticuloVentaCodigo(String TextoBuscar)
        //{
        //    DataTable listado = new DataTable("articulo");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_articulo_venta_codigo";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = TextoBuscar;
        //        ComandoMySql.Parameters.Add(parametroTextoBuscar);

        //        MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
        //        DatosMySql.Fill(listado);

        //    }
        //    catch //(Exception ex)
        //    {
        //        listado = null;
        //    }
        //    return listado;
        //}
        //#endregion

        //#region POR CATEGORÍA
        //public DataTable MostrarArticuloVentaCategoria(String TextoBuscar)
        //{
        //    DataTable listado = new DataTable("articulo");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_articulo_venta_categoria";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = TextoBuscar;
        //        ComandoMySql.Parameters.Add(parametroTextoBuscar);

        //        MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
        //        DatosMySql.Fill(listado);

        //    }
        //    catch //(Exception ex)
        //    {
        //        listado = null;
        //    }
        //    return listado;
        //}
        //#endregion
        //#endregion
        #endregion

        #region BUSCAR VENTAS
        public DataTable Buscar(DateTime desde, DateTime hasta)
        {
            DataTable listado = new DataTable("Ventas");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarVentas";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroDesde = new MySqlParameter();
                parametroDesde.ParameterName = "parDesde";
                parametroDesde.MySqlDbType = MySqlDbType.DateTime;
                parametroDesde.Size = 50;
                parametroDesde.Value = desde;
                ComandoMySql.Parameters.Add(parametroDesde);

                MySqlParameter parametroHasta = new MySqlParameter();
                parametroHasta.ParameterName = "parHasta";
                parametroHasta.MySqlDbType = MySqlDbType.DateTime;
                parametroHasta.Size = 50;
                parametroHasta.Value = hasta;
                ComandoMySql.Parameters.Add(parametroHasta);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listado);

            }
            catch //(Exception ex)
            {
                listado = null;
            }
            return listado;
        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosVenta Venta, List<DatosDetalleVenta> Detalle)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                //Transaccion
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spInsertarVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Venta.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Venta.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Venta.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Venta.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipoComprobante = new MySqlParameter();
                parametroTipoComprobante.ParameterName = "parTipoComprobante";
                parametroTipoComprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoComprobante.Size = 20;
                parametroTipoComprobante.Value = Venta.TipoComprobante;
                ComandoMySql.Parameters.Add(parametroTipoComprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parSerie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Venta.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parCorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Venta.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "parIVA";
                parametroIVA.MySqlDbType = MySqlDbType.Decimal;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Venta.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroDescuento = new MySqlParameter();
                parametroDescuento.ParameterName = "parDescuento";
                parametroDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroDescuento.Precision = 8;
                parametroDescuento.Scale = 2;
                parametroDescuento.Value = Venta.Descuento;
                ComandoMySql.Parameters.Add(parametroDescuento);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "parTotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Venta.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 20;
                parametroEstado.Value = Venta.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdVenta = Convert.ToInt32(ComandoMySql.Parameters["parIdVenta"].Value);
                    //int cantidad_Descuentos = 0;
                    foreach (DatosDetalleVenta detalle in Detalle)
                    {
                        detalle.IdVenta = IdVenta;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizar Stock
                            respuesta = DisminuirStock(detalle.IdArticulo, detalle.Cantidad, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
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

        #region INSERTAR VENTA + VENTA_DESCUENTO
        public string Insertar(DatosVenta Venta, List<DatosDetalleVenta> Detalle, List<DatosDescuento> VentaDescuento)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                #region PARÁMETROS
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                //Transaccion
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Venta.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Venta.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Venta.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Venta.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipoComprobante = new MySqlParameter();
                parametroTipoComprobante.ParameterName = "parTipoComprobante";
                parametroTipoComprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoComprobante.Size = 20;
                parametroTipoComprobante.Value = Venta.TipoComprobante;
                ComandoMySql.Parameters.Add(parametroTipoComprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parSerie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Venta.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parCorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Venta.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "parIVA";
                parametroIVA.MySqlDbType = MySqlDbType.Decimal;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Venta.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroDescuento = new MySqlParameter();
                parametroDescuento.ParameterName = "parDescuento";
                parametroDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroDescuento.Precision = 8;
                parametroDescuento.Scale = 2;
                parametroDescuento.Value = Venta.Descuento;
                ComandoMySql.Parameters.Add(parametroDescuento);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "parTotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Venta.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 20;
                parametroEstado.Value = Venta.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);
                #endregion

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdVenta = Convert.ToInt32(ComandoMySql.Parameters["parIdVenta"].Value);
                    foreach (DatosDetalleVenta detalle in Detalle)
                    {
                        detalle.IdVenta = IdVenta;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizar Stock
                            respuesta = DisminuirStock(detalle.IdArticulo, detalle.Cantidad, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        foreach (DatosDescuento ventaDescuento in VentaDescuento)
                        {
                            ventaDescuento.IdVenta = IdVenta;
                            respuesta = ventaDescuento.Insertar(ventaDescuento, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
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

        #region INSERTAR VENTA DEUDA
        public string Insertar(DatosVenta Venta, List<DatosDetalleVenta> Detalle, List<DatosDeuda> Deuda, List<DatosDetalleDeuda> DetalleDeuda)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                //Transaccion
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Venta.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Venta.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Venta.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Venta.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipoComprobante = new MySqlParameter();
                parametroTipoComprobante.ParameterName = "parTipoComprobante";
                parametroTipoComprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoComprobante.Size = 20;
                parametroTipoComprobante.Value = Venta.TipoComprobante;
                ComandoMySql.Parameters.Add(parametroTipoComprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parSerie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Venta.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parCorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Venta.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "parIVA";
                parametroIVA.MySqlDbType = MySqlDbType.Decimal;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Venta.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroDescuento = new MySqlParameter();
                parametroDescuento.ParameterName = "parDescuento";
                parametroDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroDescuento.Precision = 8;
                parametroDescuento.Scale = 2;
                parametroDescuento.Value = Venta.Descuento;
                ComandoMySql.Parameters.Add(parametroDescuento);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "parTotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Venta.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 20;
                parametroEstado.Value = Venta.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdVenta = Convert.ToInt32(ComandoMySql.Parameters["parIdVenta"].Value);
                    foreach (DatosDetalleVenta detalle in Detalle)
                    {
                        detalle.IdVenta = IdVenta;
                        //Llamar al metodo insertar de la clase detalle_venta
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizar Stock
                            respuesta = DisminuirStock(detalle.IdArticulo, detalle.Cantidad, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }

                    if (respuesta.Equals("OK"))
                    {
                        foreach (DatosDeuda deuda in Deuda)
                        {
                            //Llamar al metodo insertar de la clase deuda
                            deuda.IdVenta = IdVenta;
                            respuesta = deuda.Insertar(deuda, DetalleDeuda, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }


                    if (respuesta.Equals("OK"))
                    {
                        DatosCliente cliente = new DatosCliente();
                        cliente.IdCliente = IdCliente;
                        cliente.Estado = "REGISTRA DEUDAS";
                        respuesta = cliente.EditarEstado(cliente, ref MySqlConexion, ref MySqlTransaccion);
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

        #region INSERTAR VENTA DEUDA + DESCUENTOS
        public string Insertar(DatosVenta Venta, List<DatosDetalleVenta> Detalle, List<DatosDeuda> Deuda, List<DatosDetalleDeuda> DetalleDeuda, List<DatosDescuento> VentaDescuento)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                #region PARÁMETROS
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                //Transaccion
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdCaja = new MySqlParameter();
                parametroIdCaja.ParameterName = "parIdCaja";
                parametroIdCaja.MySqlDbType = MySqlDbType.Int32;
                parametroIdCaja.Value = Venta.IdCaja;
                ComandoMySql.Parameters.Add(parametroIdCaja);

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Venta.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Venta.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Venta.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipoComprobante = new MySqlParameter();
                parametroTipoComprobante.ParameterName = "parTipoComprobante";
                parametroTipoComprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoComprobante.Size = 20;
                parametroTipoComprobante.Value = Venta.TipoComprobante;
                ComandoMySql.Parameters.Add(parametroTipoComprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parSerie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Venta.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parCorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Venta.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "parIVA";
                parametroIVA.MySqlDbType = MySqlDbType.Decimal;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Venta.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroDescuento = new MySqlParameter();
                parametroDescuento.ParameterName = "parDescuento";
                parametroDescuento.MySqlDbType = MySqlDbType.Decimal;
                parametroDescuento.Precision = 8;
                parametroDescuento.Scale = 2;
                parametroDescuento.Value = Venta.Descuento;
                ComandoMySql.Parameters.Add(parametroDescuento);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "parTotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Venta.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 20;
                parametroEstado.Value = Venta.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                #endregion

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdVenta = Convert.ToInt32(ComandoMySql.Parameters["parIdVenta"].Value);
                    foreach (DatosDetalleVenta detalle in Detalle)
                    {
                        detalle.IdVenta = IdVenta;
                        //Llamar al metodo insertar de la clase DetalleVenta
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizar Stock
                            respuesta = DisminuirStock(detalle.IdArticulo, detalle.Cantidad, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        foreach (DatosDeuda deuda in Deuda)
                        {
                            //Llamar al metodo insertar de la clase deuda
                            deuda.IdVenta = IdVenta;
                            respuesta = deuda.Insertar(deuda, DetalleDeuda, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        foreach (DatosDescuento ventaDescuento in VentaDescuento)
                        {
                            ventaDescuento.IdVenta = IdVenta;
                            respuesta = ventaDescuento.Insertar(ventaDescuento, ref MySqlConexion, ref MySqlTransaccion);
                            if (!respuesta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                    if (respuesta.Equals("OK"))
                    {
                        DatosCliente cliente = new DatosCliente();
                        cliente.IdCliente = IdCliente;
                        cliente.Estado = "REGISTRA DEUDAS";
                        respuesta = cliente.EditarEstado(cliente, ref MySqlConexion, ref MySqlTransaccion);
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

        #region DISMINUIR STOCK
        public string DisminuirStock(int idArticulo, decimal cantidad, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spDisminuirStock";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = idArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar actualizar el stock. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region ELIMINAR
        public string Eliminar(DatosVenta Venta, List<DatosDetalleVenta> Detalle)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                //Transaccion
                MySqlTransaction MySqlTransaccion = MySqlConexion.BeginTransaction();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarVenta";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = Venta.IdVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                ////Aquí se pone "OK" en ambos casos ya que igualmente se ejecutará el trigger "trdisminuir_stock"
                //respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "OK";
                //Aquí se cambia la declaración anterior ya que al eliminar la venta no se ejecuta el trigger del detalle de la venta,
                // sólo se activa cuando se elimina directamente el registro de la tabla detalle de venta, no así de la tabla venta
                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar actualizar el stock. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    IdVenta = Convert.ToInt32(ComandoMySql.Parameters["parIdVenta"].Value);
                    foreach (DatosDetalleVenta detalle in Detalle)
                    {
                        detalle.IdVenta = IdVenta;
                        respuesta = RestablecerStock(detalle.IdArticulo, detalle.Cantidad, ref MySqlConexion, ref MySqlTransaccion);
                        //if (!respuesta.Equals("OK"))
                        //{
                        //    break;
                        //}
                        //else
                        //{
                        //    if (!respuesta.Equals("OK"))
                        //    {
                        //        break;
                        //    }
                        //}
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

        #region RESTABLECER STOCK
        public string RestablecerStock(int idArticulo, decimal cantidad, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spRestablecerStock";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = idArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar actualizar el stock. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region REPORTE FACTURA
        public DataTable Informe(int idVenta)
        {
            string respuesta = "";
            DataTable listado = new DataTable("Factura");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spFactura";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = idVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar actualizar el stock. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return listado;
        }
        #endregion

        #region CALCULAR VENTAS
        public DataTable CalcularVentas(DatosVenta Venta, DateTime desde, DateTime hasta)
        {
            DataTable dtTotalVentas = new DataTable("TotalVentas");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spCalcularVentas";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroDesde = new MySqlParameter();
                parametroDesde.ParameterName = "parDesde";
                parametroDesde.MySqlDbType = MySqlDbType.DateTime;
                parametroDesde.Size = 50;
                parametroDesde.Value = desde;
                ComandoMySql.Parameters.Add(parametroDesde);

                MySqlParameter parametroHasta = new MySqlParameter();
                parametroHasta.ParameterName = "parHasta";
                parametroHasta.MySqlDbType = MySqlDbType.DateTime;
                parametroHasta.Size = 50;
                parametroHasta.Value = hasta;
                ComandoMySql.Parameters.Add(parametroHasta);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(dtTotalVentas);

            }
            catch //(Exception ex)
            {
                dtTotalVentas = null;
            }
            return dtTotalVentas;
        }
        #endregion
    }
}
