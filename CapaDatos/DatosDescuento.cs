using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosDescuento
    {
        private int _IdVenta;
        private int _IdDescuento;
        private string _NombreDescuento;
        private string _Descripcion;
        private int _CantidadDescuentos;
        private bool _Habilitado;
        private string _Buscar;

        #region PROPIEDADES
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

        public string NombreDescuento
        {
            get
            {
                return _NombreDescuento;
            }

            set
            {
                _NombreDescuento = value;
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

        public string Buscar
        {
            get
            {
                return _Buscar;
            }

            set
            {
                _Buscar = value;
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

        public int CantidadDescuentos
        {
            get
            {
                return _CantidadDescuentos;
            }

            set
            {
                _CantidadDescuentos = value;
            }
        }

        public bool Habilitado
        {
            get
            {
                return _Habilitado;
            }

            set
            {
                _Habilitado = value;
            }
        }
        #endregion

        public DatosDescuento()
        {

        }

        public DatosDescuento(int idVenta, int idDescuento, string nombreDescuento, string descripcion, int cantidadDescuentos, bool habilitado, string buscar)
        {
            IdVenta = idVenta;
            IdDescuento = idDescuento;
            NombreDescuento = nombreDescuento;
            Descripcion = descripcion; 
            CantidadDescuentos = cantidadDescuentos;
            Habilitado = habilitado;
            Buscar = buscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listadoDescuento = new DataTable("Descuentos");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDescuentos";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoDescuento);

            }
            catch
            {
                listadoDescuento = null;
            }
            return listadoDescuento;

        }

        public DataTable MostrarPromosHabilitadas()
        {
            DataTable listadoDescuento = new DataTable("Descuentos");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarDescuentosHabilitados";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoDescuento);

            }
            catch
            {
                listadoDescuento = null;
            }
            return listadoDescuento;

        }
        #endregion

        #region BUSCAR
        public DataTable BuscarNombre(DatosDescuento Descuento)
        {
            DataTable listadoDescuento = new DataTable("Descuentos");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroBuscar = new MySqlParameter();
                parametroBuscar.ParameterName = "parBuscar";
                parametroBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroBuscar.Size = 100;
                parametroBuscar.Value = Descuento.Buscar;
                ComandoMySql.Parameters.Add(parametroBuscar);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoDescuento);

            }
            catch
            {
                listadoDescuento = null;
            }
            return listadoDescuento;
        }
        public DataTable BuscarDescuentosHabilitados(DatosDescuento Descuento)
        {
            DataTable listadoDescuento = new DataTable("Descuentos");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarDescuentosHabilitados";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroBuscar = new MySqlParameter();
                parametroBuscar.ParameterName = "parBuscar";
                parametroBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroBuscar.Size = 100;
                parametroBuscar.Value = Descuento.Buscar;
                ComandoMySql.Parameters.Add(parametroBuscar);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoDescuento);

            }
            catch
            {
                listadoDescuento = null;
            }
            return listadoDescuento;
        }

        /*public DataTable BuscarIdArticulo(DatosDescuento Descuento)
        {
            DataTable listadoDescuento = new DataTable("descuento");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {                                                                       // VERIFICAR MÁS ADELANTE SI ES NECESARIA ESTA PORCIÓN DE CÓDIGO AQUÍ O ES MEJOR UBICARLA EN DETALLE_DESCUENTO
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_descuento_idarticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "paridarticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = Descuento.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoDescuento);

            }
            catch (Exception ex)
            {
                listadoDescuento = null;
            }
            return listadoDescuento;
        }*/
        #endregion

        #region INSERTAR
        public string Insertar(DatosDescuento Descuento, List<DatosDetalleDescuento> Detalle)
        {
            string respuesta = "";
            //SqlConnection SqlConexion = new SqlConnection(); //SQL SERVER
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
                ComandoMySql.CommandText = "spInsertarDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlParameter parametroNombreDescuento = new MySqlParameter();
                parametroNombreDescuento.ParameterName = "parNombreDescuento";
                parametroNombreDescuento.MySqlDbType = MySqlDbType.VarChar;
                parametroNombreDescuento.Value = Descuento.NombreDescuento;
                ComandoMySql.Parameters.Add(parametroNombreDescuento);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Descuento.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";

                // COLOCAR AQUÍ EL CÓDIGO DE DATOSDETALLE_DESCUENTO AL IGUAL QUE CON LOS INGRESOS Y LAS VENTAS, DEBE HACERSE CON UNA TRANSACCIÓN

                if (respuesta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    IdDescuento = Convert.ToInt32(ComandoMySql.Parameters["parIdDescuento"].Value);
                    foreach (DatosDetalleDescuento detalle in Detalle)
                    {
                        detalle.IdDescuento = IdDescuento;
                        //Llamar al metodo insertar de la clase detalle_ingreso
                        respuesta = detalle.Insertar(detalle, ref MySqlConexion, ref MySqlTransaccion);
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

        #region INSERTAR VENTA DESCUENTO
        public string Insertar(DatosDescuento VentaDescuento, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                //MySql
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spInsertarVentaDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdVentaDescuento = new MySqlParameter();
                parametroIdVentaDescuento.ParameterName = "parIdVentaDescuento";
                parametroIdVentaDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdVentaDescuento.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdVentaDescuento);

                MySqlParameter parametroIdVenta = new MySqlParameter();
                parametroIdVenta.ParameterName = "parIdVenta";
                parametroIdVenta.MySqlDbType = MySqlDbType.Int32;
                parametroIdVenta.Value = VentaDescuento.IdVenta;
                ComandoMySql.Parameters.Add(parametroIdVenta);

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = VentaDescuento.IdDescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Int32;
                parametroCantidad.Value = VentaDescuento.CantidadDescuentos;
                ComandoMySql.Parameters.Add(parametroCantidad);

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
        public string Editar(DatosDescuento Descuento, List<DatosDetalleDescuento> Detalle)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = Descuento.IdDescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlParameter parametroNombreDescuento = new MySqlParameter();
                parametroNombreDescuento.ParameterName = "parNombreDescuento";
                parametroNombreDescuento.MySqlDbType = MySqlDbType.VarChar;
                parametroNombreDescuento.Value = Descuento.NombreDescuento;
                ComandoMySql.Parameters.Add(parametroNombreDescuento);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Descuento.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                // HACER EL FOREACH CORRESPONDIENTE PARA EDITAR EL DESCUENTO

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

        public string Habilitar(DatosDescuento Descuento)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spHabilitarDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = Descuento.IdDescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

                MySqlParameter parametroHabilitar = new MySqlParameter();
                parametroHabilitar.ParameterName = "parHabilitar";
                parametroHabilitar.MySqlDbType = MySqlDbType.TinyBlob;
                parametroHabilitar.Value = Descuento.Habilitado;
                ComandoMySql.Parameters.Add(parametroHabilitar);

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

        #region ELIMINAR
        public string Eliminar(DatosDescuento Descuento)
        {
            string respuesta = "";
            //SqlConnection SqlConexion = new SqlConnection(); //SQL SERVER
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarDescuento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdDescuento = new MySqlParameter();
                parametroIdDescuento.ParameterName = "parIdDescuento";
                parametroIdDescuento.MySqlDbType = MySqlDbType.Int32;
                parametroIdDescuento.Value = Descuento.IdDescuento;
                ComandoMySql.Parameters.Add(parametroIdDescuento);

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
