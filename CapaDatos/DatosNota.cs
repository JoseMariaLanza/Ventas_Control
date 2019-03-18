using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosNota
    {
        private int _IdNota;
        private string _Nota;
        private int _X;
        private int _Y;
        private int _Ancho;
        private int _Alto;
        private int _CantidadNotas;

        #region PROPIEDADES
        public int IdNota
        {
            get
            {
                return _IdNota;
            }

            set
            {
                _IdNota = value;
            }
        }

        public string Nota
        {
            get
            {
                return _Nota;
            }

            set
            {
                _Nota = value;
            }
        }

        public int X
        {
            get
            {
                return _X;
            }

            set
            {
                _X = value;
            }
        }

        public int Y
        {
            get
            {
                return _Y;
            }

            set
            {
                _Y = value;
            }
        }

        public int CantidadNotas
        {
            get
            {
                return _CantidadNotas;
            }

            set
            {
                _CantidadNotas = value;
            }
        }

        public int Ancho
        {
            get
            {
                return _Ancho;
            }

            set
            {
                _Ancho = value;
            }
        }

        public int Alto
        {
            get
            {
                return _Alto;
            }

            set
            {
                _Alto = value;
            }
        }
        #endregion

        public DatosNota() { }

        public DatosNota(int idnota, string nota, int x, int y, int cantidadNotas)
        {
            IdNota = idnota;
            Nota = nota;
            X = x;
            Y = y;
            CantidadNotas = cantidadNotas;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Notas");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarNotas";

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
        public string Insertar(DatosNota Nota)
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
                ComandoMySql.CommandText = "spInsertarNota";
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter parametroIdNota = new MySqlParameter();
                parametroIdNota.ParameterName = "parIdNota";
                parametroIdNota.MySqlDbType = MySqlDbType.Int32;
                parametroIdNota.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdNota);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parNota";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 1024;
                parametroNombre.Value = Nota.Nota;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroX = new MySqlParameter();
                parametroX.ParameterName = "parX";
                parametroX.MySqlDbType = MySqlDbType.Int32;
                parametroX.Value = Nota.X;
                ComandoMySql.Parameters.Add(parametroX);

                MySqlParameter parametroY = new MySqlParameter();
                parametroY.ParameterName = "parY";
                parametroY.MySqlDbType = MySqlDbType.Int32;
                parametroY.Value = Nota.Y;
                ComandoMySql.Parameters.Add(parametroY);

                MySqlParameter parametroAncho = new MySqlParameter();
                parametroAncho.ParameterName = "parAncho";
                parametroAncho.MySqlDbType = MySqlDbType.Int32;
                parametroAncho.Value = Nota.Ancho;
                ComandoMySql.Parameters.Add(parametroAncho);

                MySqlParameter parametroAlto = new MySqlParameter();
                parametroAlto.ParameterName = "parAlto";
                parametroAlto.MySqlDbType = MySqlDbType.Int32;
                parametroAlto.Value = Nota.Alto;
                ComandoMySql.Parameters.Add(parametroAlto);

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
        public string Editar(DatosNota Nota)
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
                ComandoMySql.CommandText = "spEditarNota";
                ComandoMySql.CommandType = CommandType.StoredProcedure;


                MySqlParameter parametroIdNota = new MySqlParameter();
                parametroIdNota.ParameterName = "parIdNota";
                parametroIdNota.MySqlDbType = MySqlDbType.Int32;
                parametroIdNota.Value = Nota.IdNota;
                ComandoMySql.Parameters.Add(parametroIdNota);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parNota";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 1024;
                parametroNombre.Value = Nota.Nota;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroX = new MySqlParameter();
                parametroX.ParameterName = "parX";
                parametroX.MySqlDbType = MySqlDbType.Int32;
                parametroX.Value = Nota.X;
                ComandoMySql.Parameters.Add(parametroX);

                MySqlParameter parametroY = new MySqlParameter();
                parametroY.ParameterName = "parY";
                parametroY.MySqlDbType = MySqlDbType.Int32;
                parametroY.Value = Nota.Y;
                ComandoMySql.Parameters.Add(parametroY);

                MySqlParameter parametroAncho = new MySqlParameter();
                parametroAncho.ParameterName = "parAncho";
                parametroAncho.MySqlDbType = MySqlDbType.Int32;
                parametroAncho.Value = Nota.Ancho;
                ComandoMySql.Parameters.Add(parametroAncho);

                MySqlParameter parametroAlto = new MySqlParameter();
                parametroAlto.ParameterName = "parAlto";
                parametroAlto.MySqlDbType = MySqlDbType.Int32;
                parametroAlto.Value = Nota.Alto;
                ComandoMySql.Parameters.Add(parametroAlto);

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

        #region ELIMINAR
        public string Eliminar(DatosNota Nota)
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
                ComandoMySql.CommandText = "spEliminarNota";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdNota = new MySqlParameter();
                parametroIdNota.ParameterName = "parIdNota";
                parametroIdNota.MySqlDbType = MySqlDbType.Int32;
                parametroIdNota.Value = Nota.IdNota;
                ComandoMySql.Parameters.Add(parametroIdNota);

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

        #region CONTAR NOTAS
        public int Contar()
        {
            int cantReg = 0;
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spContarNotas";

                cantReg = (int)ComandoMySql.ExecuteScalar();

            }
            catch
            {
                cantReg = 0;
            }
            return cantReg;
        }
        #endregion
    }
}
