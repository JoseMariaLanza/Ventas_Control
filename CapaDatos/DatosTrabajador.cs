using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosTrabajador
    {
        private int _IdTrabajador;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Domicilio;
        private string _Tel_Fijo;
        private string _Tel_Cel;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

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

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
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

        public DateTime Fecha_Nacimiento
        {
            get
            {
                return _Fecha_Nacimiento;
            }

            set
            {
                _Fecha_Nacimiento = value;
            }
        }

        public string Num_Documento
        {
            get
            {
                return _Num_Documento;
            }

            set
            {
                _Num_Documento = value;
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

        public string Tel_Fijo
        {
            get
            {
                return _Tel_Fijo;
            }

            set
            {
                _Tel_Fijo = value;
            }
        }

        public string Tel_Cel
        {
            get
            {
                return _Tel_Cel;
            }

            set
            {
                _Tel_Cel = value;
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

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        public DatosTrabajador() { }

        public DatosTrabajador(int idtrabajador, string nombre, string apellido, string sexo, DateTime fecha_nacimiento, string num_documento, string domicilio, string tel_fijo, string tel_cel, string email,
            string acceso, string usuario, string password, string textobuscar)
        {
            IdTrabajador = idtrabajador;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Fecha_Nacimiento = fecha_nacimiento;
            Num_Documento = num_documento;
            Domicilio = domicilio;
            Tel_Fijo = tel_fijo;
            Tel_Cel = tel_cel;
            Email = email;
            Acceso = acceso;
            Usuario = usuario;
            Password = password;
            TextoBuscar = textobuscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("trabajador");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "mostrar_trabajador";

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

        #region BUSCAR NOMBRE
        public DataTable BuscarNombre(DatosTrabajador Trabajador)
        {
            DataTable listado = new DataTable("trabajador");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_trabajador";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "partextobuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Trabajador.TextoBuscar;
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

        #region BUSCAR NUMERO DE DOCUMENTO
        public DataTable BuscarNum_Documento(DatosTrabajador Trabajador)
        {
            DataTable listado = new DataTable("trabajador");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_trabajador_num_documento";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "partextobuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 11;
                parametroTextoBuscar.Value = Trabajador.TextoBuscar;
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
        #endregion

        #region INSERTAR
        public string Insertar(DatosTrabajador Trabajador)
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
                ComandoMySql.CommandText = "insertar_trabajador";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdTrabajador = new MySqlParameter();
                parametroIdTrabajador.ParameterName = "paridtrabajador";
                parametroIdTrabajador.MySqlDbType = MySqlDbType.Int32;
                parametroIdTrabajador.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdTrabajador);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parnombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Trabajador.Nombre;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroApellido = new MySqlParameter();
                parametroApellido.ParameterName = "parapellido";
                parametroApellido.MySqlDbType = MySqlDbType.VarChar;
                parametroApellido.Size = 50;
                parametroApellido.Value = Trabajador.Apellido;
                ComandoMySql.Parameters.Add(parametroApellido);

                MySqlParameter parametroSexo = new MySqlParameter();
                parametroSexo.ParameterName = "parsexo";
                parametroSexo.MySqlDbType = MySqlDbType.VarChar;
                parametroSexo.Size = 1;
                parametroSexo.Value = Trabajador.Sexo;
                ComandoMySql.Parameters.Add(parametroSexo);

                MySqlParameter parametroFecha_Nacimiento = new MySqlParameter();
                parametroFecha_Nacimiento.ParameterName = "parfecha_nacimiento";
                parametroFecha_Nacimiento.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                ComandoMySql.Parameters.Add(parametroFecha_Nacimiento);

                MySqlParameter parametroNum_Documento = new MySqlParameter();
                parametroNum_Documento.ParameterName = "parnum_documento";
                parametroNum_Documento.MySqlDbType = MySqlDbType.VarChar;
                parametroNum_Documento.Size = 11;
                parametroNum_Documento.Value = Trabajador.Num_Documento;
                ComandoMySql.Parameters.Add(parametroNum_Documento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "pardomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Trabajador.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTel_Fijo = new MySqlParameter();
                parametroTel_Fijo.ParameterName = "partel_fijo";
                parametroTel_Fijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTel_Fijo.Size = 10;
                parametroTel_Fijo.Value = Trabajador.Tel_Fijo;
                ComandoMySql.Parameters.Add(parametroTel_Fijo);

                MySqlParameter parametroTel_Cel = new MySqlParameter();
                parametroTel_Cel.ParameterName = "partel_cel";
                parametroTel_Cel.MySqlDbType = MySqlDbType.VarChar;
                parametroTel_Cel.Size = 12;
                parametroTel_Cel.Value = Trabajador.Tel_Cel;
                ComandoMySql.Parameters.Add(parametroTel_Cel);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "paremail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Trabajador.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

                MySqlParameter parametroAcceso = new MySqlParameter();
                parametroAcceso.ParameterName = "paracceso";
                parametroAcceso.MySqlDbType = MySqlDbType.VarChar;
                parametroAcceso.Size = 20;
                parametroAcceso.Value = Trabajador.Acceso;
                ComandoMySql.Parameters.Add(parametroAcceso);

                MySqlParameter parametroUsuario = new MySqlParameter();
                parametroUsuario.ParameterName = "parusuario";
                parametroUsuario.MySqlDbType = MySqlDbType.VarChar;
                parametroUsuario.Size = 20;
                parametroUsuario.Value = Trabajador.Usuario;
                ComandoMySql.Parameters.Add(parametroUsuario);

                MySqlParameter parametroPassword = new MySqlParameter();
                parametroPassword.ParameterName = "parpassword";
                parametroPassword.MySqlDbType = MySqlDbType.VarChar;
                parametroPassword.Size = 20;
                parametroPassword.Value = Trabajador.Password;
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
        public string Editar(DatosTrabajador Trabajador)
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
                ComandoMySql.CommandText = "editar_trabajador";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdTrabajador = new MySqlParameter();
                parametroIdTrabajador.ParameterName = "paridtrabajador";
                parametroIdTrabajador.MySqlDbType = MySqlDbType.Int32;
                parametroIdTrabajador.Value = Trabajador.IdTrabajador;
                ComandoMySql.Parameters.Add(parametroIdTrabajador);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parnombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Trabajador.Nombre;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroApellido = new MySqlParameter();
                parametroApellido.ParameterName = "parapellido";
                parametroApellido.MySqlDbType = MySqlDbType.VarChar;
                parametroApellido.Size = 50;
                parametroApellido.Value = Trabajador.Apellido;
                ComandoMySql.Parameters.Add(parametroApellido);

                MySqlParameter parametroSexo = new MySqlParameter();
                parametroSexo.ParameterName = "parsexo";
                parametroSexo.MySqlDbType = MySqlDbType.VarChar;
                parametroSexo.Size = 1;
                parametroSexo.Value = Trabajador.Sexo;
                ComandoMySql.Parameters.Add(parametroSexo);

                MySqlParameter parametroFecha_Nacimiento = new MySqlParameter();
                parametroFecha_Nacimiento.ParameterName = "parfecha_nacimiento";
                parametroFecha_Nacimiento.MySqlDbType = MySqlDbType.DateTime;
                parametroFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                ComandoMySql.Parameters.Add(parametroFecha_Nacimiento);

                MySqlParameter parametroNum_Documento = new MySqlParameter();
                parametroNum_Documento.ParameterName = "parnum_documento";
                parametroNum_Documento.MySqlDbType = MySqlDbType.VarChar;
                parametroNum_Documento.Size = 11;
                parametroNum_Documento.Value = Trabajador.Num_Documento;
                ComandoMySql.Parameters.Add(parametroNum_Documento);

                MySqlParameter parametroDomicilio = new MySqlParameter();
                parametroDomicilio.ParameterName = "pardomicilio";
                parametroDomicilio.MySqlDbType = MySqlDbType.VarChar;
                parametroDomicilio.Size = 100;
                parametroDomicilio.Value = Trabajador.Domicilio;
                ComandoMySql.Parameters.Add(parametroDomicilio);

                MySqlParameter parametroTel_Fijo = new MySqlParameter();
                parametroTel_Fijo.ParameterName = "partel_fijo";
                parametroTel_Fijo.MySqlDbType = MySqlDbType.VarChar;
                parametroTel_Fijo.Size = 10;
                parametroTel_Fijo.Value = Trabajador.Tel_Fijo;
                ComandoMySql.Parameters.Add(parametroTel_Fijo);

                MySqlParameter parametroTel_Cel = new MySqlParameter();
                parametroTel_Cel.ParameterName = "partel_cel";
                parametroTel_Cel.MySqlDbType = MySqlDbType.VarChar;
                parametroTel_Cel.Size = 12;
                parametroTel_Cel.Value = Trabajador.Tel_Cel;
                ComandoMySql.Parameters.Add(parametroTel_Cel);

                MySqlParameter parametroEmail = new MySqlParameter();
                parametroEmail.ParameterName = "paremail";
                parametroEmail.MySqlDbType = MySqlDbType.VarChar;
                parametroEmail.Size = 50;
                parametroEmail.Value = Trabajador.Email;
                ComandoMySql.Parameters.Add(parametroEmail);

                MySqlParameter parametroAcceso = new MySqlParameter();
                parametroAcceso.ParameterName = "paracceso";
                parametroAcceso.MySqlDbType = MySqlDbType.VarChar;
                parametroAcceso.Size = 20;
                parametroAcceso.Value = Trabajador.Acceso;
                ComandoMySql.Parameters.Add(parametroAcceso);

                MySqlParameter parametroUsuario = new MySqlParameter();
                parametroUsuario.ParameterName = "parusuario";
                parametroUsuario.MySqlDbType = MySqlDbType.VarChar;
                parametroUsuario.Size = 20;
                parametroUsuario.Value = Trabajador.Usuario;
                ComandoMySql.Parameters.Add(parametroUsuario);

                MySqlParameter parametroPassword = new MySqlParameter();
                parametroPassword.ParameterName = "parpassword";
                parametroPassword.MySqlDbType = MySqlDbType.VarChar;
                parametroPassword.Size = 20;
                parametroPassword.Value = Trabajador.Password;
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
        public string Eliminar(DatosTrabajador Trabajador)
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
                ComandoMySql.CommandText = "eliminar_trabajador";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdTrabajador = new MySqlParameter();
                parametroIdTrabajador.ParameterName = "paridtrabajador";
                parametroIdTrabajador.MySqlDbType = MySqlDbType.Int32;
                parametroIdTrabajador.Value = Trabajador.IdTrabajador;
                ComandoMySql.Parameters.Add(parametroIdTrabajador);

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
        public DataTable Login(DatosTrabajador Trabajador)
        {
            DataTable listado = new DataTable("trabajador");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "login";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroUsuario = new MySqlParameter();
                parametroUsuario.ParameterName = "parusuario";
                parametroUsuario.MySqlDbType = MySqlDbType.VarChar;
                parametroUsuario.Size = 20;
                parametroUsuario.Value = Trabajador.Usuario;
                ComandoMySql.Parameters.Add(parametroUsuario);

                MySqlParameter parametroPassword = new MySqlParameter();
                parametroPassword.ParameterName = "parpassword";
                parametroPassword.MySqlDbType = MySqlDbType.VarChar;
                parametroPassword.Size = 20;
                parametroPassword.Value = Trabajador.Password;
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
