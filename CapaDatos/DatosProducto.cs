using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosProducto
    {
        private int _IdProducto;
        private string _Codigo;
        private string _Nombre;
        private int _IdCategoria;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private decimal _Stock;
        private int _IdPresentacion;
        private string _Descripcion;
        private string _Ruta_Imagen;
        private string _TextoBuscar;
        private string _CategoriaBuscar;

        #region SETTERS & GETTERS
        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }

            set
            {
                _IdProducto = value;
            }
        }

        public string Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
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

        public decimal Precio_Compra
        {
            get
            {
                return _Precio_Compra;
            }

            set
            {
                _Precio_Compra = value;
            }
        }

        public decimal Precio_Venta
        {
            get
            {
                return _Precio_Venta;
            }

            set
            {
                _Precio_Venta = value;
            }
        }

        public decimal Stock
        {
            get
            {
                return _Stock;
            }

            set
            {
                _Stock = value;
            }
        }

        public int IdPresentacion
        {
            get
            {
                return _IdPresentacion;
            }

            set
            {
                _IdPresentacion = value;
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

        public string Ruta_Imagen
        {
            get
            {
                return _Ruta_Imagen;
            }

            set
            {
                _Ruta_Imagen = value;
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

        public string CategoriaBuscar
        {
            get
            {
                return _CategoriaBuscar;
            }

            set
            {
                _CategoriaBuscar = value;
            }
        }

        #endregion

        public DatosProducto() { }

        public DatosProducto(int idproducto, string codigo, string nombre,int idcategoria, decimal precio_compra, 
            decimal precio_venta, decimal stock, int idpresentacion, string descripcion, string ruta_imagen, string textobuscar)
        {
            IdProducto = idproducto;
            Codigo = codigo;
            Nombre = nombre;
            IdCategoria = idcategoria;
            Precio_Compra = precio_compra;
            Precio_Venta = precio_venta;
            Stock = stock;
            IdPresentacion = idpresentacion;
            Descripcion = descripcion;
            Ruta_Imagen = ruta_imagen;
            TextoBuscar = textobuscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("producto");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "mostrar_producto";

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

        #region MOSTRAR PRODUCTOS A REPONER
        public DataTable Mostrar(decimal stockminimo)
        {
            DataTable listado = new DataTable("producto_a_reponer");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "stock_a_reponer";

                MySqlParameter parametroStockMinimo = new MySqlParameter();
                parametroStockMinimo.ParameterName = "parstockminimo";
                parametroStockMinimo.MySqlDbType = MySqlDbType.Decimal;
                parametroStockMinimo.Value = stockminimo;
                ComandoMySql.Parameters.Add(parametroStockMinimo);

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

        #region BUSCAR ID PRODUCTO
        public DataTable BuscarProductoId(DatosProducto Producto)
        {
            DataTable listado = new DataTable("producto");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_producto_id";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProductoBuscar= new MySqlParameter();
                parametroIdProductoBuscar.ParameterName = "paridproducto";
                parametroIdProductoBuscar.MySqlDbType = MySqlDbType.Int32;
                parametroIdProductoBuscar.Value = Producto.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdProductoBuscar);

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

        #region BUSCAR NOMBRE
        public DataTable BuscarNombre(DatosProducto Producto)
        {
            DataTable listado = new DataTable("producto");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_producto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "partextobuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Producto.TextoBuscar;
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

        #region BUSCAR POR NOMBRE DE PRODUCTO Y NOMBRE DE CATEGORIA
        public DataTable BuscarProductoCategoria(DatosProducto Producto)
        {
            DataTable listado = new DataTable("producto");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_productocategoria";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "partextobuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Producto.TextoBuscar;
                ComandoMySql.Parameters.Add(parametroTextoBuscar);

                MySqlParameter parametroCategoriaBuscar = new MySqlParameter();
                parametroCategoriaBuscar.ParameterName = "parcategoriabuscar";
                parametroCategoriaBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroCategoriaBuscar.Size = 50;
                parametroCategoriaBuscar.Value = Producto.CategoriaBuscar;
                ComandoMySql.Parameters.Add(parametroCategoriaBuscar);

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

        #region BUSCAR CATEGORIA
        public DataTable BuscarCategoria(DatosProducto Producto)
        {
            DataTable listado = new DataTable("producto");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                /*
                //SQL SERVER
                SqlConexion.ConnectionString = Conexion.cadenaConexion;
                SqlCommand ComandoSql = new SqlCommand();
                ComandoSql.Connection = SqlConexion;
                ComandoSql.CommandText = "buscar_categoria";
                ComandoSql.CommandType = CommandType.StoredProcedure;

                SqlParameter parametroTextoBuscar = new SqlParameter();
                parametroTextoBuscar.ParameterName = "@textoBuscar";
                parametroTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Categoria.TextoBuscar;
                ComandoSql.Parameters.Add(parametroTextoBuscar);

                SqlDataAdapter DatosSql = new SqlDataAdapter(ComandoSql);
                DatosSql.Fill(listadoCategoria);
                */

                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_producto_categoria";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "partextobuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Producto.TextoBuscar;
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

        #region BUSCAR CODIGO DE BARRAS
        public DataTable BuscarCodigo(DatosProducto Producto)
        {
            DataTable listado = new DataTable("producto");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_productocodigobarras";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroTextoBuscar = new MySqlParameter();
                parametroTextoBuscar.ParameterName = "partextobuscar";
                parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroTextoBuscar.Size = 50;
                parametroTextoBuscar.Value = Producto.TextoBuscar;
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

        #region POR ID DE PRODUCTO
        public DataTable BuscarArticuloId(int idarticulo)
        {
            DataTable listado = new DataTable("articulo");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "buscar_producto_id";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProducto = new MySqlParameter();
                parametroIdProducto.ParameterName = "paridproducto";
                parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdProducto.Value = idarticulo;
                ComandoMySql.Parameters.Add(parametroIdProducto);

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
        #region FORMA ORIGINAL DEL MÉTODO INSERTAR
        /*
         public string Insertar(DatosProducto Producto)
        {
            string respuesta = "";
            //SqlConnection SqlConexion = new SqlConnection(); //SQL SERVER
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                /*
                //SQL SERVER
                SqlConexion.ConnectionString = Conexion.cadenaConexion;
                SqlConexion.Open();
                SqlCommand ComandoSql = new SqlCommand();
                ComandoSql.Connection = SqlConexion;
                ComandoSql.CommandText = "insertar_categoria";
                ComandoSql.CommandType = CommandType.StoredProcedure;

                //Creando variable que recibirá el valor de un parametro de la base de datos
                SqlParameter parametroIdCategoria = new SqlParameter();
                //Especificando el nombre del parámetro del cual el parámetro "parametroIdCategoría recibirá el valor
                parametroIdCategoria.ParameterName = "@idcategoria";
                //Estableciendo el tipo de dato del parametro "parametroIdCategoria"
                parametroIdCategoria.SqlDbType = SqlDbType.Int;
                //Indicando que este no es un parametro de entrada, sino de salida
                parametroIdCategoria.Direction = ParameterDirection.Output;
                ComandoSql.Parameters.Add(parametroIdCategoria);

                SqlParameter parametroNombre = new SqlParameter();
                parametroNombre.ParameterName = "@nombre";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                //Estableciendo el tamaño del campo a la misma longitud que en la base de datos
                parametroNombre.Size = 50;
                //Enviando valor de la variable _Nombre desde el método get del objeto Categoria
                parametroNombre.Value = Categoria.Nombre;
                ComandoSql.Parameters.Add(parametroNombre);

                SqlParameter parametroDescripcion = new SqlParameter();
                parametroDescripcion.ParameterName = "@descripcion";
                parametroDescripcion.SqlDbType = SqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = Categoria.Descripcion;
                ComandoSql.Parameters.Add(parametroDescripcion);

                respuesta = ComandoSql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar ingresar el registro. Intente nuevamente.";
                *//*

        //MySql
        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
        ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "insertar_producto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter parametroIdPoducto = new MySqlParameter();
        parametroIdPoducto.ParameterName = "paridproducto";
                parametroIdPoducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdPoducto.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdPoducto);

                MySqlParameter parametroCodigo = new MySqlParameter();
        parametroCodigo.ParameterName = "parcodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Producto.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroNombre = new MySqlParameter();
        parametroNombre.ParameterName = "parnombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Producto.Nombre;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroDescripcion = new MySqlParameter();
        parametroDescripcion.ParameterName = "pardescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Producto.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRuta_Imagen = new MySqlParameter();
        parametroRuta_Imagen.ParameterName = "parruta_imagen";
                parametroRuta_Imagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRuta_Imagen.Size = 1024;
                parametroRuta_Imagen.Value = Producto.Ruta_Imagen;
                ComandoMySql.Parameters.Add(parametroRuta_Imagen);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
        parametroIdCategoria.ParameterName = "paridcategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Producto.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
        parametroIdPresentacion.ParameterName = "paridpresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Producto.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

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
        */
        #endregion
        public string Insertar(DatosProducto Producto)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "insertar_producto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter parametroIdPoducto = new MySqlParameter();
                parametroIdPoducto.ParameterName = "paridproducto";
                parametroIdPoducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdPoducto.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdPoducto);

                MySqlParameter parametroCodigo = new MySqlParameter();
                parametroCodigo.ParameterName = "parcodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Producto.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parnombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Producto.Nombre;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "paridcategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Producto.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);
                
                MySqlParameter parametroPrecio_Compra = new MySqlParameter();
                parametroPrecio_Compra.ParameterName = "parprecio_compra";
                parametroPrecio_Compra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Compra.Value = Producto.Precio_Compra;
                ComandoMySql.Parameters.Add(parametroPrecio_Compra);
                
                MySqlParameter parametroPrecio_Venta = new MySqlParameter();
                parametroPrecio_Venta.ParameterName = "parprecio_venta";
                parametroPrecio_Venta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Venta.Value = Producto.Precio_Venta;
                ComandoMySql.Parameters.Add(parametroPrecio_Venta);
                
                MySqlParameter parametroStock = new MySqlParameter();
                parametroStock.ParameterName = "parstock";
                parametroStock.MySqlDbType = MySqlDbType.Decimal;
                parametroStock.Value = Producto.Stock;
                ComandoMySql.Parameters.Add(parametroStock);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "paridpresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Producto.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "pardescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Producto.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRuta_Imagen = new MySqlParameter();
                parametroRuta_Imagen.ParameterName = "parruta_imagen";
                parametroRuta_Imagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRuta_Imagen.Size = 1024;
                parametroRuta_Imagen.Value = Producto.Ruta_Imagen;
                ComandoMySql.Parameters.Add(parametroRuta_Imagen);

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
        public string Editar(DatosProducto Producto, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "editar_producto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProducto = new MySqlParameter();
                parametroIdProducto.ParameterName = "paridproducto";
                parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdProducto.Value = Producto.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdProducto);

                MySqlParameter parametroCodigo = new MySqlParameter();
                parametroCodigo.ParameterName = "parcodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Producto.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parnombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Producto.Nombre;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroPrecio_Compra = new MySqlParameter();
                parametroPrecio_Compra.ParameterName = "parprecio_compra";
                parametroPrecio_Compra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Compra.Value = Producto.Precio_Compra;
                ComandoMySql.Parameters.Add(parametroPrecio_Compra);

                MySqlParameter parametroPrecio_Venta = new MySqlParameter();
                parametroPrecio_Venta.ParameterName = "parprecio_venta";
                parametroPrecio_Venta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Venta.Value = Producto.Precio_Venta;
                ComandoMySql.Parameters.Add(parametroPrecio_Venta);

                MySqlParameter parametroStock = new MySqlParameter();
                parametroStock.ParameterName = "parstock";
                parametroStock.MySqlDbType = MySqlDbType.Decimal;
                parametroStock.Value = Producto.Stock;
                ComandoMySql.Parameters.Add(parametroStock);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "pardescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Producto.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRuta_Imagen = new MySqlParameter();
                parametroRuta_Imagen.ParameterName = "parruta_imagen";
                parametroRuta_Imagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRuta_Imagen.Size = 1024;
                parametroRuta_Imagen.Value = Producto.Ruta_Imagen;
                ComandoMySql.Parameters.Add(parametroRuta_Imagen);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "paridcategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Producto.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "paridpresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Producto.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Editar(DatosProducto Producto)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "editar_producto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdProducto = new MySqlParameter();
                parametroIdProducto.ParameterName = "paridproducto";
                parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdProducto.Value = Producto.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdProducto);

                MySqlParameter parametroCodigo = new MySqlParameter();
                parametroCodigo.ParameterName = "parcodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Producto.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroNombre = new MySqlParameter();
                parametroNombre.ParameterName = "parnombre";
                parametroNombre.MySqlDbType = MySqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = Producto.Nombre;
                ComandoMySql.Parameters.Add(parametroNombre);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "paridcategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Producto.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroPrecio_Compra = new MySqlParameter();
                parametroPrecio_Compra.ParameterName = "parprecio_compra";
                parametroPrecio_Compra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Compra.Value = Producto.Precio_Compra;
                ComandoMySql.Parameters.Add(parametroPrecio_Compra);

                MySqlParameter parametroPrecio_Venta = new MySqlParameter();
                parametroPrecio_Venta.ParameterName = "parprecio_venta";
                parametroPrecio_Venta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecio_Venta.Value = Producto.Precio_Venta;
                ComandoMySql.Parameters.Add(parametroPrecio_Venta);

                MySqlParameter parametroStock = new MySqlParameter();
                parametroStock.ParameterName = "parstock";
                parametroStock.MySqlDbType = MySqlDbType.Decimal;
                parametroStock.Value = Producto.Stock;
                ComandoMySql.Parameters.Add(parametroStock);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "paridpresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Producto.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "pardescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Producto.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRuta_Imagen = new MySqlParameter();
                parametroRuta_Imagen.ParameterName = "parruta_imagen";
                parametroRuta_Imagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRuta_Imagen.Size = 1024;
                parametroRuta_Imagen.Value = Producto.Ruta_Imagen;
                ComandoMySql.Parameters.Add(parametroRuta_Imagen);

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
        public string Eliminar(DatosProducto Producto)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "eliminar_producto";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdPProducto = new MySqlParameter();
                parametroIdPProducto.ParameterName = "paridproducto";
                parametroIdPProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdPProducto.Value = Producto.IdProducto;
                ComandoMySql.Parameters.Add(parametroIdPProducto);

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

        #region DISMINUIR STOCK
        public string DisminuirStock(int idproducto, decimal cantidad)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "disminuir_stock";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdPProducto = new MySqlParameter();
                parametroIdPProducto.ParameterName = "paridproducto";
                parametroIdPProducto.MySqlDbType = MySqlDbType.Int32;
                parametroIdPProducto.Value = idproducto;
                ComandoMySql.Parameters.Add(parametroIdPProducto);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parcantidad";
                parametroCantidad.MySqlDbType = MySqlDbType.Decimal;
                parametroCantidad.Value = cantidad;
                ComandoMySql.Parameters.Add(parametroCantidad);

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
