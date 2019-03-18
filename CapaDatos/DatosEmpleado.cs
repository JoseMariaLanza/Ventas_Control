using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosEmpleado
    {
        private int _IdEmpleado;
        private string _Nombres;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _NumeroDocumento;
        private string _Domicilio;
        private string _TelefonoFijo;
        private string _TelefonoCelular;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _Buscar;

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

        public string Acceso
        {
            get
            {
                return _Acceso;
            }

            set
            {
                _Acceso = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
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

        public DatosEmpleado() { }

        public DatosEmpleado(int idTrabajador, string nombres, string apellidos, string sexo, DateTime fechaNacimiento, string numeroDocumento, string domicilio, string telefonoFijo, string telefonoCelular, string email,
            string acceso, string usuario, string password, string buscar)
        {
            IdEmpleado = idTrabajador;
            Nombres = nombres;
            Apellidos = apellidos;
            Sexo = sexo;
            FechaNacimiento = fechaNacimiento;
            NumeroDocumento = numeroDocumento;
            Domicilio = domicilio;
            TelefonoFijo = telefonoFijo;
            TelefonoCelular = telefonoCelular;
            Email = email;
            Acceso = acceso;
            Usuario = usuario;
            Password = password;
            Buscar = buscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Empleados");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarEmpleados";

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
        public DataTable BuscarEmpleado(DatosEmpleado Empleado)
        {
            DataTable listado = new DataTable("Empleado");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarEmpleado";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroBuscar = new MySqlParameter();
                parametroBuscar.ParameterName = "parBuscar";
                parametroBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroBuscar.Size = 50;
                parametroBuscar.Value = Empleado.Buscar;
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
        //public DataTable BuscarNum_Documento(DatosEmpleado Trabajador)
        //{
        //    DataTable listado = new DataTable("trabajador");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_trabajador_num_documento";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 11;
        //        parametroTextoBuscar.Value = Trabajador.Buscar;
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
        public string Insertar(DatosEmpleado Empleado)
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
                ComandoMySql.CommandText = "spInsertarEmpleado";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroNombres = new MySqlParameter();
                parametroNombres.ParameterName = "parNombres";
                parametroNombres.MySqlDbType = MySqlDbType.VarChar;
                parametroNombres.Size = 50;
                parametroNombres.Value = Empleado.Nombres;
                ComandoMySql.Parameters.Add(parametroNombres);

                MySqlParameter parametroApellidos = new MySqlParameter();
                parametroApellidos.ParameterName = "parApellidos";
                parametroApellidos.MySqlDbType = MySqlDbType.VarChar;
                parametroApellidos.Size = 50;
                parametroApellidos.Value = Empleado.Apellidos;
                ComandoMySql.Parameters.Add(parametroApellidos);

                MySqlParameter parametroSexo = new MySqlParameter();
                parametroSexo.ParameterName = "parSexo";
                parametroSexo.MySqlDbType = MySqlDbType.VarChar;
                parametroSexo.Size = 1;
                parametroSexo.Value = Empleado.Sexo;
                ComandoMySql.Parameters.Add(parametroSexo);

                MySqlParameter parametroFechaNacimiento = new MySqlParameter();
                parametroFechaNacimiento.ParameterName = "parFechaNacimiento";
                parametroFechaNacimiento.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaNacimiento.Value = Empleado.FechaNacimiento;
                ComandoMySql.Parameters.Add(parametroFechaNacimiento);

                MySqlParameter parametroNumeroDocumento = new MySqlParameter();
                parametroNumeroDocumento.ParameterName = "parNumeroDocumento";
                parametroNumeroDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroNumeroDocumento.Size = 11;
                parametroNumeroDocumento.Value = Empleado.NumeroDocumento;
                ComandoMySql.Parameters.Add(parametroNumeroDocumento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "parDomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Empleado.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTelefonoFijo = new MySqlParameter();
                parametroTelefonoFijo.ParameterName = "parTelefonoFijo";
                parametroTelefonoFijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoFijo.Size = 10;
                parametroTelefonoFijo.Value = Empleado.TelefonoFijo;
                ComandoMySql.Parameters.Add(parametroTelefonoFijo);

                MySqlParameter parametroTelefonoCelular = new MySqlParameter();
                parametroTelefonoCelular.ParameterName = "parTelefonoCelular";
                parametroTelefonoCelular.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoCelular.Size = 12;
                parametroTelefonoCelular.Value = Empleado.TelefonoCelular;
                ComandoMySql.Parameters.Add(parametroTelefonoCelular);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "parEmail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Empleado.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

                MySqlParameter parametroAcceso = new MySqlParameter();
                parametroAcceso.ParameterName = "parAcceso";
                parametroAcceso.MySqlDbType = MySqlDbType.VarChar;
                parametroAcceso.Size = 20;
                parametroAcceso.Value = Empleado.Acceso;
                ComandoMySql.Parameters.Add(parametroAcceso);

                MySqlParameter parametroUsuario = new MySqlParameter();
                parametroUsuario.ParameterName = "parUsuario";
                parametroUsuario.MySqlDbType = MySqlDbType.VarChar;
                parametroUsuario.Size = 20;
                parametroUsuario.Value = Empleado.Usuario;
                ComandoMySql.Parameters.Add(parametroUsuario);

                MySqlParameter parametroPassword = new MySqlParameter();
                parametroPassword.ParameterName = "parPassword";
                parametroPassword.MySqlDbType = MySqlDbType.VarChar;
                parametroPassword.Size = 20;
                parametroPassword.Value = Empleado.Password;
                ComandoMySql.Parameters.Add(parametroPassword);

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
        public string Editar(DatosEmpleado Empleado)
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
                ComandoMySql.CommandText = "spEditarEmpleado";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Empleado.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

                MySqlParameter parametroNombres = new MySqlParameter();
                parametroNombres.ParameterName = "parNombres";
                parametroNombres.MySqlDbType = MySqlDbType.VarChar;
                parametroNombres.Size = 50;
                parametroNombres.Value = Empleado.Nombres;
                ComandoMySql.Parameters.Add(parametroNombres);

                MySqlParameter parametroApellidos = new MySqlParameter();
                parametroApellidos.ParameterName = "parApellidos";
                parametroApellidos.MySqlDbType = MySqlDbType.VarChar;
                parametroApellidos.Size = 50;
                parametroApellidos.Value = Empleado.Apellidos;
                ComandoMySql.Parameters.Add(parametroApellidos);

                MySqlParameter parametroSexo = new MySqlParameter();
                parametroSexo.ParameterName = "parSexo";
                parametroSexo.MySqlDbType = MySqlDbType.VarChar;
                parametroSexo.Size = 1;
                parametroSexo.Value = Empleado.Sexo;
                ComandoMySql.Parameters.Add(parametroSexo);

                MySqlParameter parametroFechaNacimiento = new MySqlParameter();
                parametroFechaNacimiento.ParameterName = "parFechaNacimiento";
                parametroFechaNacimiento.MySqlDbType = MySqlDbType.DateTime;
                parametroFechaNacimiento.Value = Empleado.FechaNacimiento;
                ComandoMySql.Parameters.Add(parametroFechaNacimiento);

                MySqlParameter parametroNumeroDocumento = new MySqlParameter();
                parametroNumeroDocumento.ParameterName = "parNumeroDocumento";
                parametroNumeroDocumento.MySqlDbType = MySqlDbType.VarChar;
                parametroNumeroDocumento.Size = 11;
                parametroNumeroDocumento.Value = Empleado.NumeroDocumento;
                ComandoMySql.Parameters.Add(parametroNumeroDocumento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "parDomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Empleado.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTelefonoFijo = new MySqlParameter();
                parametroTelefonoFijo.ParameterName = "parTelefonoFijo";
                parametroTelefonoFijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoFijo.Size = 10;
                parametroTelefonoFijo.Value = Empleado.TelefonoFijo;
                ComandoMySql.Parameters.Add(parametroTelefonoFijo);

                MySqlParameter parametroTelefonoCelular = new MySqlParameter();
                parametroTelefonoCelular.ParameterName = "parTelefonoCelular";
                parametroTelefonoCelular.MySqlDbType = MySqlDbType.VarChar;
                parametroTelefonoCelular.Size = 12;
                parametroTelefonoCelular.Value = Empleado.TelefonoCelular;
                ComandoMySql.Parameters.Add(parametroTelefonoCelular);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "parEmail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Empleado.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

                MySqlParameter parametroAcceso = new MySqlParameter();
                parametroAcceso.ParameterName = "parAcceso";
                parametroAcceso.MySqlDbType = MySqlDbType.VarChar;
                parametroAcceso.Size = 20;
                parametroAcceso.Value = Empleado.Acceso;
                ComandoMySql.Parameters.Add(parametroAcceso);

                MySqlParameter parametroUsuario = new MySqlParameter();
                parametroUsuario.ParameterName = "parUsuario";
                parametroUsuario.MySqlDbType = MySqlDbType.VarChar;
                parametroUsuario.Size = 20;
                parametroUsuario.Value = Empleado.Usuario;
                ComandoMySql.Parameters.Add(parametroUsuario);

                MySqlParameter parametroPassword = new MySqlParameter();
                parametroPassword.ParameterName = "parPassword";
                parametroPassword.MySqlDbType = MySqlDbType.VarChar;
                parametroPassword.Size = 20;
                parametroPassword.Value = Empleado.Password;
                ComandoMySql.Parameters.Add(parametroPassword);


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
        public string Eliminar(DatosEmpleado Empleado)
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
                ComandoMySql.CommandText = "spEliminarEmpleado";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdEmpleado = new MySqlParameter();
                parametroIdEmpleado.ParameterName = "parIdEmpleado";
                parametroIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                parametroIdEmpleado.Value = Empleado.IdEmpleado;
                ComandoMySql.Parameters.Add(parametroIdEmpleado);

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

        #region LOGIN
        public DataTable Login(DatosEmpleado Empleado)
        {
            DataTable listado = new DataTable("Empleado");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spLogin";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroUsuario = new MySqlParameter();
                parametroUsuario.ParameterName = "parUsuario";
                parametroUsuario.MySqlDbType = MySqlDbType.VarChar;
                parametroUsuario.Size = 20;
                parametroUsuario.Value = Empleado.Usuario;
                ComandoMySql.Parameters.Add(parametroUsuario);

                MySqlParameter parametroPassword = new MySqlParameter();
                parametroPassword.ParameterName = "parPassword";
                parametroPassword.MySqlDbType = MySqlDbType.VarChar;
                parametroPassword.Size = 20;
                parametroPassword.Value = Empleado.Password;
                ComandoMySql.Parameters.Add(parametroPassword);

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

    }
}
