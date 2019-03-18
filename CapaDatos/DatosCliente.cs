using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosCliente
    {
        private int _IdCliente;
        private string _Nombres;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _TipoDocumento;
        private string _NumeroDocumento;
        private string _Domicilio;
        private string _TelefonoFijo;
        private string _TelefonoCelular;
        private string _Email;
        private string _Estado;
        private string _Buscar;

        #region SETTERS & GETTERS
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

        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return _FechaNacimiento;
            }

            set
            {
                _FechaNacimiento = value;
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
        #endregion

        public DatosCliente() { }

        public DatosCliente(int idcliente, string nombres, string apellidos, string sexo, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string domicilio, string telefonoFijo, string telefonoCelular,
            string email, string estado, string buscar)
        {
            IdCliente = idcliente;
            Nombres = nombres;
            Apellidos = apellidos;
            Sexo = sexo;
            FechaNacimiento = fechaNacimiento;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Domicilio = domicilio;
            TelefonoFijo = telefonoFijo;
            TelefonoCelular = telefonoCelular;
            Email = email;
            Estado = estado;
            Buscar = buscar;
        }


        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Clientes");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarClientes";

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

        #region CLIENTE DEFAULT
        public DataTable ClienteDefault()
        {
            DataTable listado = new DataTable("Clientes");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spClienteDefault";

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

        #region BUSCAR
        public DataTable BuscarCliente(DatosCliente Cliente)
        {
            DataTable listado = new DataTable("Clientes");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarCliente";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "parBuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Cliente.Buscar;
                ComandoMySql.Parameters.Add(parametroTextoBuscar);

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
        //public DataTable BuscarNum_Documento(DatosCliente Cliente)
        //{
        //    DataTable listado = new DataTable("cliente");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_cliente_num_documento";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 11;
        //        parametroTextoBuscar.Value = Cliente.Buscar;
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
        public string Insertar(DatosCliente Cliente)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySql
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spInsertarCliente";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroNombres = new MySqlParameter();
                parametroNombres.ParameterName = "parNombres";
                parametroNombres.MySqlDbType = MySqlDbType.VarChar;
                parametroNombres.Size = 50;
                parametroNombres.Value = Cliente.Nombres;
                ComandoMySql.Parameters.Add(parametroNombres);

                MySqlParameter parametroApellidos = new MySqlParameter();
                parametroApellidos.ParameterName = "parApellidos";
                parametroApellidos.MySqlDbType = MySqlDbType.VarChar;
                parametroApellidos.Size = 50;
                parametroApellidos.Value = Cliente.Apellidos;
                ComandoMySql.Parameters.Add(parametroApellidos);

                MySqlParameter parametroSexo = new MySqlParameter();
                parametroSexo.ParameterName = "parSexo";
                parametroSexo.MySqlDbType = MySqlDbType.VarChar;
                parametroSexo.Size = 1;
                parametroSexo.Value = Cliente.Sexo;
                ComandoMySql.Parameters.Add(parametroSexo);

                MySqlParameter parametroFechaNacimiento = new MySqlParameter();
                parametroFechaNacimiento.ParameterName = "parFechaNacimiento";
                parametroFechaNacimiento.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaNacimiento.Value = Cliente.FechaNacimiento;
                ComandoMySql.Parameters.Add(parametroFechaNacimiento);

                MySqlParameter parametroTipoDocumento = new MySqlParameter();
                parametroTipoDocumento.ParameterName = "parTipoDocumento";
                parametroTipoDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoDocumento.Size = 20;
                parametroTipoDocumento.Value = Cliente.TipoDocumento;
                ComandoMySql.Parameters.Add(parametroTipoDocumento);

                MySqlParameter parametroNumeroDocumento = new MySqlParameter();
                parametroNumeroDocumento.ParameterName = "parNumeroDocumento";
                parametroNumeroDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroNumeroDocumento.Size = 11;
                parametroNumeroDocumento.Value = Cliente.NumeroDocumento;
                ComandoMySql.Parameters.Add(parametroNumeroDocumento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "parDomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Cliente.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTelefonoFijo = new MySqlParameter();
                parametroTelefonoFijo.ParameterName = "parTelefonoFijo";
                parametroTelefonoFijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoFijo.Size = 10;
                parametroTelefonoFijo.Value = Cliente.TelefonoFijo;
                ComandoMySql.Parameters.Add(parametroTelefonoFijo);

                MySqlParameter parametroTelefonoCelular = new MySqlParameter();
                parametroTelefonoCelular.ParameterName = "parTelefonoCelular";
                parametroTelefonoCelular.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoCelular.Size = 12;
                parametroTelefonoCelular.Value = Cliente.TelefonoCelular;
                ComandoMySql.Parameters.Add(parametroTelefonoCelular);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "parEmail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Cliente.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

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
        public string Editar(DatosCliente Cliente)
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
                ComandoMySql.CommandText = "spEditarCliente";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Cliente.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroNombres = new MySqlParameter();
                parametroNombres.ParameterName = "parNombres";
                parametroNombres.MySqlDbType = MySqlDbType.VarChar;
                parametroNombres.Size = 50;
                parametroNombres.Value = Cliente.Nombres;
                ComandoMySql.Parameters.Add(parametroNombres);

                MySqlParameter parametroApellidos = new MySqlParameter();
                parametroApellidos.ParameterName = "parApellidos";
                parametroApellidos.MySqlDbType = MySqlDbType.VarChar;
                parametroApellidos.Size = 50;
                parametroApellidos.Value = Cliente.Apellidos;
                ComandoMySql.Parameters.Add(parametroApellidos);

                MySqlParameter parametroSexo = new MySqlParameter();
                parametroSexo.ParameterName = "parSexo";
                parametroSexo.MySqlDbType = MySqlDbType.VarChar;
                parametroSexo.Size = 1;
                parametroSexo.Value = Cliente.Sexo;
                ComandoMySql.Parameters.Add(parametroSexo);

                MySqlParameter parametroFechaNacimiento = new MySqlParameter();
                parametroFechaNacimiento.ParameterName = "parFechaNacimiento";
                parametroFechaNacimiento.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaNacimiento.Value = Cliente.FechaNacimiento;
                ComandoMySql.Parameters.Add(parametroFechaNacimiento);

                MySqlParameter parametroTipoDocumento = new MySqlParameter();
                parametroTipoDocumento.ParameterName = "parTipoDocumento";
                parametroTipoDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroTipoDocumento.Size = 20;
                parametroTipoDocumento.Value = Cliente.TipoDocumento;
                ComandoMySql.Parameters.Add(parametroTipoDocumento);

                MySqlParameter parametroNumeroDocumento = new MySqlParameter();
                parametroNumeroDocumento.ParameterName = "parNumeroDocumento";
                parametroNumeroDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroNumeroDocumento.Size = 11;
                parametroNumeroDocumento.Value = Cliente.NumeroDocumento;
                ComandoMySql.Parameters.Add(parametroNumeroDocumento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "parDomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Cliente.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTelefonoFijo = new MySqlParameter();
                parametroTelefonoFijo.ParameterName = "parTelefonoFijo";
                parametroTelefonoFijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoFijo.Size = 10;
                parametroTelefonoFijo.Value = Cliente.TelefonoFijo;
                ComandoMySql.Parameters.Add(parametroTelefonoFijo);

                MySqlParameter parametroTelefonoCelular = new MySqlParameter();
                parametroTelefonoCelular.ParameterName = "parTelefonoCelular";
                parametroTelefonoCelular.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoCelular.Size = 12;
                parametroTelefonoCelular.Value = Cliente.TelefonoCelular;
                ComandoMySql.Parameters.Add(parametroTelefonoCelular);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "parEmail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Cliente.Email;
                ComandoMySql.Parameters.Add(parametroEmail);


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

        public string EditarEstado(DatosCliente Cliente, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarEstadoCliente";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Cliente.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 50;
                parametroEstado.Value = Cliente.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string EditarEstado(DatosCliente Cliente)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarEstadoCliente";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Cliente.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

                MySqlParameter parametroEstado = new MySqlParameter();
                parametroEstado.ParameterName = "parEstado";
                parametroEstado.MySqlDbType = MySqlDbType.VarChar;
                parametroEstado.Size = 50;
                parametroEstado.Value = Cliente.Estado;
                ComandoMySql.Parameters.Add(parametroEstado);

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
        public string Eliminar(DatosCliente Cliente)
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
                ComandoMySql.CommandText = "spEliminarCliente";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCliente = new MySqlParameter();
                parametroIdCliente.ParameterName = "parIdCliente";
                parametroIdCliente.MySqlDbType = MySqlDbType.Int32;
                parametroIdCliente.Value = Cliente.IdCliente;
                ComandoMySql.Parameters.Add(parametroIdCliente);

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
