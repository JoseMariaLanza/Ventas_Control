using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosProveedor
    {
        //VAriables
        private int _IdProveedor;
        private string _Nombres;
        private string _Apellidos;
        private string _Rubro;
        private string _TipoDocumento;
        private string _NumeroDocumento;
        private string _Domicilio;
        private string _TelefonoFijo;
        private string _TelefonoCelular;
        private string _Email;
        private string _URL;
        private string _Buscar;

        #region SETTER & GETTERS - PROPIEDADES
        //Propiedades
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

        public string Nombres
        {
            get
            {
                return _Nombres;
            }

            set
            {
                _Nombres = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _Apellidos;
            }

            set
            {
                _Apellidos = value;
            }
        }

        public string Rubro
        {
            get
            {
                return _Rubro;
            }

            set
            {
                _Rubro = value;
            }
        }

        public string TipoDocumento
        {
            get
            {
                return _TipoDocumento;
            }

            set
            {
                _TipoDocumento = value;
            }
        }

        public string NumeroDocumento
        {
            get
            {
                return _NumeroDocumento;
            }

            set
            {
                _NumeroDocumento = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return _Domicilio;
            }

            set
            {
                _Domicilio = value;
            }
        }

        public string TelefonoFijo
        {
            get
            {
                return _TelefonoFijo;
            }

            set
            {
                _TelefonoFijo = value;
            }
        }

        public string TelefonoCelular
        {
            get
            {
                return _TelefonoCelular;
            }

            set
            {
                _TelefonoCelular = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string URL
        {
            get
            {
                return _URL;
            }

            set
            {
                _URL = value;
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
        #endregion

        public DatosProveedor() { }

        public DatosProveedor(int idProveedor, string nombres, string apellidos, string rubro, string tipoDocumento,
            string numeroDocumento, string domicilio, string telefonoFijo, string telefonoCelular, string email, string url, string buscar)
        {
            IdProveedor = idProveedor;
            Nombres = nombres;
            Apellidos = apellidos;
            Rubro = rubro;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Domicilio = domicilio;
            TelefonoFijo = telefonoFijo;
            TelefonoCelular = telefonoCelular;
            Email = email;
            URL = url;
            Buscar = buscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Proveedores");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarProveedores";

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

        #region BUSQUEDA

        #region BUSCAR PROVEEDOR
        public DataTable BuscarProveedor(DatosProveedor Proveedor)
        {
            DataTable listado = new DataTable("Proveedor");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarProveedor";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroBuscar = new MySqlParameter();
                parametroBuscar.ParameterName = "parBuscar";
                parametroBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroBuscar.Size = 50;
                parametroBuscar.Value = Proveedor.Buscar;
                ComandoMySql.Parameters.Add(parametroBuscar);

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

        //#region BUSCAR NUMERO DE DOCUMENTO
        //public DataTable BuscarNum_Documento(DatosProveedor Proveedor)
        //{
        //    DataTable listado = new DataTable("proveedor");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_proveedor_num_documento";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = Proveedor.Buscar;
        //        ComandoMySql.Parameters.Add(parametroTextoBuscar);

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
        #endregion

        #region INSERTAR
        public string Insertar(DatosProveedor Proveedor)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spInsertarProveedor";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "parIdProveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

                MySqlParameter parametroNombres = new MySqlParameter();
                parametroNombres.ParameterName = "parNombres";
                parametroNombres.MySqlDbType = MySqlDbType.VarChar;
                parametroNombres.Size = 50;
                parametroNombres.Value = Proveedor.Nombres;
                ComandoMySql.Parameters.Add(parametroNombres);

                MySqlParameter parametroApellidos = new MySqlParameter();
                parametroApellidos.ParameterName = "parApellidos";
                parametroApellidos.MySqlDbType = MySqlDbType.VarChar;
                parametroApellidos.Size = 50;
                parametroApellidos.Value = Proveedor.Apellidos;
                ComandoMySql.Parameters.Add(parametroApellidos);

                MySqlParameter parametroRubro = new MySqlParameter();
                parametroRubro.ParameterName = "parRubro";
                parametroRubro.MySqlDbType = MySqlDbType.VarChar;
                parametroRubro.Size = 50;
                parametroRubro.Value = Proveedor.Rubro;
                ComandoMySql.Parameters.Add(parametroRubro);

                MySqlParameter parametroTipoDocumento = new MySqlParameter();
                parametroTipoDocumento.ParameterName = "parTipoDocumento";
                parametroTipoDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoDocumento.Size = 20;
                parametroTipoDocumento.Value = Proveedor.TipoDocumento;
                ComandoMySql.Parameters.Add(parametroTipoDocumento);

                MySqlParameter parametroNumeroDocumento = new MySqlParameter();
                parametroNumeroDocumento.ParameterName = "parNumeroDocumento";
                parametroNumeroDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroNumeroDocumento.Size = 11;
                parametroNumeroDocumento.Value = Proveedor.NumeroDocumento;
                ComandoMySql.Parameters.Add(parametroNumeroDocumento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "parDomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Proveedor.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTelefonoFijo = new MySqlParameter();
                parametroTelefonoFijo.ParameterName = "parTelefonoFijo";
                parametroTelefonoFijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoFijo.Size = 10;
                parametroTelefonoFijo.Value = Proveedor.TelefonoFijo;
                ComandoMySql.Parameters.Add(parametroTelefonoFijo);

                MySqlParameter parametroTelefonoCelular = new MySqlParameter();
                parametroTelefonoCelular.ParameterName = "parTelefonoCelular";
                parametroTelefonoCelular.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoCelular.Size = 12;
                parametroTelefonoCelular.Value = Proveedor.TelefonoCelular;
                ComandoMySql.Parameters.Add(parametroTelefonoCelular);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "parEmail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Proveedor.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

                MySqlParameter parametroURL = new MySqlParameter();
                parametroURL.ParameterName = "parURL";
                parametroURL.MySqlDbType = MySqlDbType.VarChar;
                parametroURL.Size = 1024;
                parametroURL.Value = Proveedor.URL;
                ComandoMySql.Parameters.Add(parametroURL);

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

        #region EDITAR
        public string Editar(DatosProveedor Proveedor)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarProveedor";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "parIdProveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Value = Proveedor.IdProveedor;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parNombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Proveedor.Nombres;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroApellido = new MySqlParameter();
                parametroApellido.ParameterName = "parApellido";
                parametroApellido.MySqlDbType = MySqlDbType.VarChar;
                parametroApellido.Size = 50;
                parametroApellido.Value = Proveedor.Apellidos;
                ComandoMySql.Parameters.Add(parametroApellido);

                MySqlParameter parametroRubro = new MySqlParameter();
                parametroRubro.ParameterName = "parRubro";
                parametroRubro.MySqlDbType = MySqlDbType.VarChar;
                parametroRubro.Size = 50;
                parametroRubro.Value = Proveedor.Rubro;
                ComandoMySql.Parameters.Add(parametroRubro);

                MySqlParameter parametroTipoDocumento = new MySqlParameter();
                parametroTipoDocumento.ParameterName = "parTipoDocumento";
                parametroTipoDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoDocumento.Size = 20;
                parametroTipoDocumento.Value = Proveedor.TipoDocumento;
                ComandoMySql.Parameters.Add(parametroTipoDocumento);

                MySqlParameter parametroNumeroDocumento = new MySqlParameter();
                parametroNumeroDocumento.ParameterName = "parNumeroDocumento";
                parametroNumeroDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroNumeroDocumento.Size = 11;
                parametroNumeroDocumento.Value = Proveedor.NumeroDocumento;
                ComandoMySql.Parameters.Add(parametroNumeroDocumento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "parDomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Proveedor.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTelefonoFijo = new MySqlParameter();
                parametroTelefonoFijo.ParameterName = "parTelefonoFijo";
                parametroTelefonoFijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoFijo.Size = 10;
                parametroTelefonoFijo.Value = Proveedor.TelefonoFijo;
                ComandoMySql.Parameters.Add(parametroTelefonoFijo);

                MySqlParameter parametroTelefonoCelular = new MySqlParameter();
                parametroTelefonoCelular.ParameterName = "parTelefonoCelular";
                parametroTelefonoCelular.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoCelular.Size = 12;
                parametroTelefonoCelular.Value = Proveedor.TelefonoCelular;
                ComandoMySql.Parameters.Add(parametroTelefonoCelular);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "parEmail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Proveedor.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

                MySqlParameter parametroURL = new MySqlParameter();
                parametroURL.ParameterName = "parURL";
                parametroURL.MySqlDbType = MySqlDbType.VarChar;
                parametroURL.Size = 1024;
                parametroURL.Value = Proveedor.URL;
                ComandoMySql.Parameters.Add(parametroURL);


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
        public string Eliminar(DatosProveedor Proveedor)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarProveedor";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProveedor = new MySqlParameter();
                parametroIdProveedor.ParameterName = "parIdProveedor";
                parametroIdProveedor.MySqlDbType = MySqlDbType.Int32;
                parametroIdProveedor.Value = Proveedor.IdProveedor;
                ComandoMySql.Parameters.Add(parametroIdProveedor);

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
