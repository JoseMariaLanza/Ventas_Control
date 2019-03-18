using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosPresentacion
    {
        #region DECLARACION DE VARIABLES
        private int _IdPresentacion;
        private string _Presentacion;
        private string _Descripcion;
        private string _Buscar;
        #endregion

        #region PROPIEDADES
        public int IdPresentacion
        {
            get { return _IdPresentacion; }
            set { _IdPresentacion = value; }
        }

        public string Presentacion
        {
            get { return _Presentacion; }
            set { _Presentacion = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string Buscar
        {
            get { return _Buscar; }
            set { _Buscar = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public DatosPresentacion() { }
        #endregion

        public DatosPresentacion(int idPresentacion, string presentacion, string descripcion, string buscar)
        {
            IdPresentacion = idPresentacion;
            Presentacion = presentacion;
            Descripcion = descripcion;
            Buscar = buscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Presentaciones");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarPresentaciones";

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

        #region BUSCAR
        public DataTable BuscarPresentacion(DatosPresentacion Presentacion)
        {
            DataTable listado = new DataTable("Presentacion");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarPresentacion";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroBuscar = new MySqlParameter();
                parametroBuscar.ParameterName = "parBuscar";
                parametroBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroBuscar.Size = 50;
                parametroBuscar.Value = Presentacion.Buscar;
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

        #region INSERTAR
        public string Insertar(DatosPresentacion Presentacion)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spInsertarPresentacion";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                //Creando variable que recibirá el valor de un parametro de la base de datos
                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                //Especificando el nombre del parámetro del cual el parámetro "parametroIdCategoría recibirá el valor
                parametroIdPresentacion.ParameterName = "parIdPresentacion";
                //Estableciendo el tipo de dato del parametro "parametroIdCategoria"
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                //Indicando que este no es un parametro de entrada, sino de salida
                parametroIdPresentacion.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parPresentacion";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                //Estableciendo el tamaño del campo a la misma longitud que en la base de datos
                parametroNombre.Size = 50;
                //Enviando valor de la variable _Nombre desde el método get del objeto Categoria
                parametroNombre.Value = Presentacion.Presentacion;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Presentacion.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

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
        public string Editar(DatosPresentacion Presentacion)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEditarPresentacion";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "parIdPresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Presentacion.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parPresentacion";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Presentacion.Presentacion;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Presentacion.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

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
        public string Eliminar(DatosPresentacion Presentacion)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarPresentacion";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "parIdPresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Presentacion.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

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
