using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosCategoria
    {
        #region DECLARACIÓN DE VARIABLES
        private int _IdCategoria;
        private string _Categoria;
        private string _Descripcion;
        private string _Buscar;
        #endregion

        #region SETTER & GETTERS
        #region ID CATEGORÍA
        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }
            set
            {
                _IdCategoria = value;
            }
        }
        #endregion

        #region CATEGORIA
        public string Categoria
        {
            get
            {
                return _Categoria;
            }
            set
            {
                _Categoria = value;
            }
        }
        #endregion

        #region DESCRIPCIÓN
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
        #endregion

        #region BUSQUEDA DE REGISTRO POR TEXTO INGRESADO
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
        #endregion

        #region CONSTRUCTOR
        public DatosCategoria() { }
        #endregion

        public DatosCategoria(int idCategoria, string categoria, string descripcion, string buscar)
        {
            IdCategoria = idCategoria;
            Categoria = categoria;
            Descripcion = descripcion;
            Buscar = buscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listadoCategoria = new DataTable("Categorias");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {                
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarCategorias";

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoCategoria);

            }
            catch
            {
                listadoCategoria = null;
            }
            return listadoCategoria;

        }
        #endregion

        #region BUSCAR
        public DataTable BuscarCategoria(DatosCategoria Categoria)
        {
            DataTable listadoCategoria = new DataTable("Categorias");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarCategoria";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "parBuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Categoria.Buscar;
                ComandoMySql.Parameters.Add(parametroTextoBuscar);

                MySqlDataAdapter DatosMySql = new MySqlDataAdapter(ComandoMySql);
                DatosMySql.Fill(listadoCategoria);

            }
            catch
            {
                listadoCategoria = null;
            }
            return listadoCategoria;
        }
        #endregion

        #region INSERTAR
        public string Insertar(DatosCategoria Categoria)
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
                ComandoMySql.CommandText = "spInsertarCategoria";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                //Creando variable que recibirá el valor de un parametro de la base de datos
                MySqlParameter parametroIdCategoria = new MySqlParameter();
                //Especificando el nombre del parámetro del cual el parámetro "parametroIdCategoría recibirá el valor
                parametroIdCategoria.ParameterName = "parIdCategoria";
                //Estableciendo el tipo de dato del parametro "parametroIdCategoria"
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                //Indicando que este no es un parametro de entrada, sino de salida
                parametroIdCategoria.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroCategoria = new MySqlParameter();
                parametroCategoria.ParameterName = "parCategoria";
                parametroCategoria.MySqlDbType = MySqlDbType.VarChar;
                //Estableciendo el tamaño del campo a la misma longitud que en la base de datos
                parametroCategoria.Size = 50;
                //Enviando valor de la variable _Nombre desde el método get del objeto Categoria
                parametroCategoria.Value = Categoria.Categoria;
                ComandoMySql.Parameters.Add(parametroCategoria);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Categoria.Descripcion;
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
        public string Editar(DatosCategoria Categoria)
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
                ComandoMySql.CommandText = "spEditarCategoria";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Categoria.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroCategoria = new MySqlParameter();
                parametroCategoria.ParameterName = "parCategoria";
                parametroCategoria.MySqlDbType = MySqlDbType.VarChar;
                parametroCategoria.Size = 50;
                parametroCategoria.Value = Categoria.Categoria;
                ComandoMySql.Parameters.Add(parametroCategoria);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Categoria.Descripcion;
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
        public string Eliminar(DatosCategoria Categoria)
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
                ComandoMySql.CommandText = "spEliminarCategoria";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Categoria.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

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