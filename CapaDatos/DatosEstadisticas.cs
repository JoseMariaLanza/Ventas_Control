using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosEstadisticas
    {
        private int _IdVenta;
        private DateTime _Fecha;
        private int _IdArticulo;
        private string _Articulo;
        private string _Categoria;
        private decimal _Cantidad;

        #region PROPIEDADDES
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

        public int IdArticulo
        {
            get
            {
                return _IdArticulo;
            }

            set
            {
                _IdArticulo = value;
            }
        }

        public string Articulo
        {
            get
            {
                return _Articulo;
            }

            set
            {
                _Articulo = value;
            }
        }

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

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }
        #endregion

        public DatosEstadisticas() { }

        public DatosEstadisticas(int idVenta, DateTime fecha, int idArticulo, string articulo, string categoria, decimal cantidad)
        {
            IdVenta = idVenta;
            Fecha = fecha;
            IdArticulo = idArticulo;
            Articulo = articulo;
            Categoria = categoria;
            Cantidad = cantidad;
        }

        public DataTable Mostrar(DateTime desde, DateTime hasta, string consulta, string tipo)
        {
            DataTable listado = new DataTable("Lista");
            MySqlConnection MySQLConexion = new MySqlConnection();
            try
            {
                MySQLConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySQL = new MySqlCommand();
                ComandoMySQL.Connection = MySQLConexion;
                ComandoMySQL.CommandType = CommandType.StoredProcedure;
                ComandoMySQL.CommandText = "spEstadisticas";

                MySqlParameter parametroConsulta = new MySqlParameter();
                parametroConsulta.ParameterName = "parConsulta";
                parametroConsulta.MySqlDbType = MySqlDbType.VarChar;
                parametroConsulta.Value = consulta;
                ComandoMySQL.Parameters.Add(parametroConsulta);

                MySqlParameter parametroTipo = new MySqlParameter();
                parametroTipo.ParameterName = "parTipo";
                parametroTipo.MySqlDbType = MySqlDbType.VarChar;
                parametroTipo.Value = tipo;
                ComandoMySQL.Parameters.Add(parametroTipo);

                MySqlParameter parametroDesde = new MySqlParameter();
                parametroDesde.ParameterName = "parDesde";
                parametroDesde.MySqlDbType = MySqlDbType.DateTime;
                parametroDesde.Value = desde;
                ComandoMySQL.Parameters.Add(parametroDesde);

                MySqlParameter parametroHasta = new MySqlParameter();
                parametroHasta.ParameterName = "parHasta";
                parametroHasta.MySqlDbType = MySqlDbType.DateTime;
                parametroHasta.Value = hasta;
                ComandoMySQL.Parameters.Add(parametroHasta);

                MySqlDataAdapter DatosMySQL = new MySqlDataAdapter(ComandoMySQL);
                DatosMySQL.Fill(listado);
            }
            catch
            {
                listado = null;
            }
            return listado;
        }
    }
}
