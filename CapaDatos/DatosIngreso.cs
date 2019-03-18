using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosIngreso
    {
        private int _IdIngreso;
        private int _IdTrabajador;
        private int _IdProveedor;
        private DateTime _Fecha;
        private string _TipoComprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _IVA;
        private string _Estado;
        private decimal _Total;

        #region SETTER & GETTER
        public int IdIngreso
        {
            get
            {
                return _IdIngreso;
            }

            set
            {
                _IdIngreso = value;
            }
        }

        public int IdTrabajador
        {
            get
            {
                return _IdTrabajador;
            }

            set
            {
                _IdTrabajador = value;
            }
        }

        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
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
        #endregion

        //Constructores
        public DatosIngreso()
        {

        }

        public DatosIngreso(int idIngreso, int idTrabajador, int idProveedor, DateTime fecha, string tipoComprobante, string serie,
            string correlativo, decimal iva, string estado, decimal total)
        {
            IdIngreso = idIngreso;
            IdTrabajador = idTrabajador;
            IdProveedor = idProveedor;
            Fecha = fecha;
            TipoComprobante = tipoComprobante;
            Serie = serie;
            Correlativo = correlativo;
            IVA = iva;
            Estado = estado;
            Total = total;
        }

        //Metodos
        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Ingreso");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarIngresos";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listado);
            }
            catch
            {
                listado = null;
            }
            return listado;
        }

        public DataTable Mostrar(int idingreso)
        {
            DataTable listado = new DataTable("DetallesIngreso");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spMostrarDetallesIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "parIdIngreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Value = idingreso;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

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

        #region BUSCAR INGRESOS
        public DataTable Buscar(DateTime? desde, DateTime? hasta, int? idProveedor)
        {
            DataTable listado = new DataTable("Ingreso");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarIngresos";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroDesde = new MySqlParameter();
                parametroDesde.ParameterName = "parDesde";
                parametroDesde.MySqlDbType = MySqlDbType.DateTime;
                parametroDesde.Value = desde;
                ComandoMySql.Parameters.Add(parametroDesde);

                MySqlParameter parametroHasta = new MySqlParameter();
                parametroHasta.ParameterName = "parHasta";
                parametroHasta.MySqlDbType = MySqlDbType.DateTime;
                parametroHasta.Value = hasta;
                ComandoMySql.Parameters.Add(parametroHasta);

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "parIdProveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Value = idProveedor;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

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

        //#region BUSCAR PROVEEDOR
        //public DataTable BuscarProveedor(int idproveedor)
        //{
        //    DataTable listado = new DataTable("Ingreso");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_ingreso_proveedor";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroIdProveedor = new MySqlParameter();
        //        parametroIdProveedor.ParameterName = "paridproveedor";
        //        parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
        //        parametroIdProveedor.Value = idproveedor;
        //        ComandoMySql.Parameters.Add(parametroIdProveedor);

        //        MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
        //        DatosMySql.Fill(listado);

        //    }
        //    catch
        //    {
        //        listado = null;
        //    }
        //    return listado;
        //}
        //#endregion

        #region INSERTAR
        #region FORMA ORIGINAL DEL MÉTODO INSERTAR
        /*
         public string Insertar(DatosIngreso Ingreso, List<DatosDetalle_Ingreso> Detalle)
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
                ComandoMySql.CommandText = "insertar_ingreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "paridingreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                MySqlParameter parametroIdTrabajador = new MySqlParameter();
                parametroIdTrabajador.ParameterName = "paridtrabajador";
                parametroIdTrabajador.MySqlDbType = MySqlDbType.Int32;
                parametroIdTrabajador.Value = Ingreso.IdTrabajador;
                ComandoMySql.Parameters.Add(parametroIdTrabajador);

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "paridproveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Value = Ingreso.IdProveedor;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parfecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Ingreso.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipo_Comprobante = new MySqlParameter();
                parametroTipo_Comprobante.ParameterName = "partipo_comprobante";
                parametroTipo_Comprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipo_Comprobante.Size = 20;
                parametroTipo_Comprobante.Value = Ingreso.Tipo_Comprobante;
                ComandoMySql.Parameters.Add(parametroTipo_Comprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parserie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Ingreso.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parcorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Ingreso.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "pariva";
                parametroIVA.MySqlDbType = MySqlDbType.Decimal;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Ingreso.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parestado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 7;
                parametroEstado.Value = Ingreso.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "partotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Ingreso.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdIngreso = Convert.ToInt32(ComandoMySql.Parameters["paridingreso"].Value);
                    foreach (DatosDetalle_Ingreso detalle in Detalle)
                    {
                        detalle.IdIngreso = IdIngreso;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        detalle.IdDetalle_Ingreso = Convert.ToInt32(ComandoMySql.Parameters["pariddetalle_ingreso"].Value);
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
        }*/
        #endregion
        public string Insertar(DatosIngreso Ingreso, List<DatosDetalleIngreso> Detalle, List<DatosArticulo> Articulos)
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
                ComandoMySql.CommandText = "spInsertarIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "parIdIngreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Ingreso.IdTrabajador;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "parIdProveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Value = Ingreso.IdProveedor;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Ingreso.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipoComprobante = new MySqlParameter();
                parametroTipoComprobante.ParameterName = "parTipoComprobante";
                parametroTipoComprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoComprobante.Size = 20;
                parametroTipoComprobante.Value = Ingreso.TipoComprobante;
                ComandoMySql.Parameters.Add(parametroTipoComprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parSerie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Ingreso.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parCorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Ingreso.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "parIVA";
                parametroIVA.MySqlDbType = MySqlDbType.VarChar;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Ingreso.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 7;
                parametroEstado.Value = Ingreso.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "parTotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Ingreso.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdIngreso = Convert.ToInt32(ComandoMySql.Parameters["parIdIngreso"].Value);
                    foreach (DatosDetalleIngreso detalle in Detalle)
                    {
                        detalle.IdIngreso = IdIngreso;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Insertar(detalle, Articulos, ref MySqlConexion, ref MySqlTransaccion);
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
        public string Editar(DatosIngreso Ingreso, List<DatosDetalleIngreso> Detalle, List<DatosArticulo> Producto)
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
                ComandoMySql.CommandText = "spEditarIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "parIdIngreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Value = Ingreso.IdIngreso;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                MySqlParameter parametroIdTrabajador = new MySqlParameter();
                parametroIdTrabajador.ParameterName = "parIdTrabajador";
                parametroIdTrabajador.MySqlDbType = MySqlDbType.Int32;
                parametroIdTrabajador.Value = Ingreso.IdTrabajador;
                ComandoMySql.Parameters.Add(parametroIdTrabajador);

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "parIdProveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Value = Ingreso.IdProveedor;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

                MySqlParameter parametroFecha = new MySqlParameter();
                parametroFecha.ParameterName = "parFecha";
                parametroFecha.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha.Value = Ingreso.Fecha;
                ComandoMySql.Parameters.Add(parametroFecha);

                MySqlParameter parametroTipoComprobante = new MySqlParameter();
                parametroTipoComprobante.ParameterName = "parTipoComprobante";
                parametroTipoComprobante.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoComprobante.Size = 20;
                parametroTipoComprobante.Value = Ingreso.TipoComprobante;
                ComandoMySql.Parameters.Add(parametroTipoComprobante);

                MySqlParameter parametroSerie = new MySqlParameter();
                parametroSerie.ParameterName = "parserie";
                parametroSerie.MySqlDbType = MySqlDbType.VarChar;
                parametroSerie.Size = 4;
                parametroSerie.Value = Ingreso.Serie;
                ComandoMySql.Parameters.Add(parametroSerie);

                MySqlParameter parametroCorrelativo = new MySqlParameter();
                parametroCorrelativo.ParameterName = "parCorrelativo";
                parametroCorrelativo.MySqlDbType = MySqlDbType.VarChar;
                parametroCorrelativo.Size = 7;
                parametroCorrelativo.Value = Ingreso.Correlativo;
                ComandoMySql.Parameters.Add(parametroCorrelativo);

                MySqlParameter parametroIVA = new MySqlParameter();
                parametroIVA.ParameterName = "parIVA";
                parametroIVA.MySqlDbType = MySqlDbType.Decimal;
                parametroIVA.Precision = 8;
                parametroIVA.Scale = 2;
                parametroIVA.Value = Ingreso.IVA;
                ComandoMySql.Parameters.Add(parametroIVA);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 7;
                parametroEstado.Value = Ingreso.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                MySqlParameter parametroTotal = new MySqlParameter();
                parametroTotal.ParameterName = "parTotal";
                parametroTotal.MySqlDbType = MySqlDbType.Decimal;
                parametroTotal.Precision = 8;
                parametroTotal.Scale = 2;
                parametroTotal.Value = Ingreso.Total;
                ComandoMySql.Parameters.Add(parametroTotal);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdIngreso = Convert.ToInt32(ComandoMySql.Parameters["parIdIngreso"].Value);
                    foreach (DatosDetalleIngreso detalle in Detalle)
                    {
                        detalle.IdIngreso = IdIngreso;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Editar(detalle, ref MySqlConexion, ref MySqlTransaccion);
                        detalle.IdDetalleIngreso = Convert.ToInt32(ComandoMySql.Parameters["parIdDetalleIngreso"].Value);
                        foreach (DatosArticulo producto in Producto)
                        {
                            producto.IdArticulo = detalle.IdArticulo;
                            respuesta = producto.Editar(producto, ref MySqlConexion, ref MySqlTransaccion);
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

        #region ANULAR
        public string Anular(DatosIngreso Ingreso)
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
                ComandoMySql.CommandText = "spAnularIngreso";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdIngreso = new MySqlParameter();
                parametroIdIngreso.ParameterName = "parIdIngreso";
                parametroIdIngreso.MySqlDbType = MySqlDbType.Int32;
                parametroIdIngreso.Value = Ingreso.IdIngreso;
                ComandoMySql.Parameters.Add(parametroIdIngreso);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar anular el registro. Intente nuevamente.";

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
