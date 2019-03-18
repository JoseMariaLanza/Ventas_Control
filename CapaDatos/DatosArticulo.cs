using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class DatosArticulo
    {
        private int _IdArticulo;
        private string _Codigo;
        private string _Articulo;
        private int _IdCategoria;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private decimal _Stock;
        private int _IdPresentacion;
        private string _Descripcion;
        private string _RutaImagen;
        private string _Buscar;
        //private string _CategoriaBuscar;

        #region PROPIEDADES
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

        public decimal PrecioCompra
        {
            get
            {
                return _PrecioCompra;
            }

            set
            {
                _PrecioCompra = value;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
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

        public string RutaImagen
        {
            get
            {
                return _RutaImagen;
            }

            set
            {
                _RutaImagen = value;
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

        //public string CategoriaBuscar
        //{
        //    get
        //    {
        //        return _CategoriaBuscar;
        //    }

        //    set
        //    {
        //        _CategoriaBuscar = value;
        //    }
        //}

        #endregion

        public DatosArticulo() { }

        public DatosArticulo(int idArticulo, string codigo, string nombre,int idCategoria, decimal precioCompra, 
            decimal precioVenta, decimal stock, int idPresentacion, string descripcion, string rutaImagen, string buscar)
        {
            IdArticulo = idArticulo;
            Codigo = codigo;
            Articulo = nombre;
            IdCategoria = idCategoria;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdPresentacion = idPresentacion;
            Descripcion = descripcion;
            RutaImagen = rutaImagen;
            Buscar = buscar;
        }

        #region MOSTRAR
        public DataTable Mostrar()
        {
            DataTable listado = new DataTable("Articulos");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarArticulos";

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
        public DataTable Mostrar(decimal stockMinimo)
        {
            DataTable listado = new DataTable("ReponerArticulos");
            MySqlConnection MySqlConexion = new MySqlConnection(); //MySQL
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                ComandoMySql.CommandText = "spMostrarReponerArticulos";

                MySqlParameter parametroStockMinimo = new MySqlParameter();
                parametroStockMinimo.ParameterName = "parStockMinimo";
                parametroStockMinimo.MySqlDbType = MySqlDbType.Decimal;
                parametroStockMinimo.Value = stockMinimo;
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

        //#region BUSCAR ID PRODUCTO
        //public DataTable BuscarProductoId(DatosProducto Producto)
        //{
        //    DataTable listado = new DataTable("producto");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_producto_id";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroIdProductoBuscar= new MySqlParameter();
        //        parametroIdProductoBuscar.ParameterName = "paridproducto";
        //        parametroIdProductoBuscar.MySqlDbType = MySqlDbType.Int32;
        //        parametroIdProductoBuscar.Value = Producto.IdArticulo;
        //        ComandoMySql.Parameters.Add(parametroIdProductoBuscar);

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

        #region BUSCAR
        public DataTable BuscarArticulo(DatosArticulo Articulo)
        {
            DataTable listado = new DataTable("Articulos");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarArticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroBuscar = new MySqlParameter();
                parametroBuscar.ParameterName = "parBuscar";
                parametroBuscar.MySqlDbType = MySqlDbType.VarChar;
                parametroBuscar.Size = 50;
                parametroBuscar.Value = Articulo.Buscar;
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

        public DataTable BuscarArticulo(int idArticulo)
        {
            DataTable listado = new DataTable("Articulos");
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                //MySQL
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spBuscarIdArticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = idArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

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

        //#region BUSCAR POR NOMBRE DE PRODUCTO Y NOMBRE DE CATEGORIA
        //public DataTable BuscarProductoCategoria(DatosProducto Producto)
        //{
        //    DataTable listado = new DataTable("producto");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_productocategoria";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = Producto.Buscar;
        //        ComandoMySql.Parameters.Add(parametroTextoBuscar);

        //        MySqlParameter parametroCategoriaBuscar = new MySqlParameter();
        //        parametroCategoriaBuscar.ParameterName = "parcategoriabuscar";
        //        parametroCategoriaBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroCategoriaBuscar.Size = 50;
        //        parametroCategoriaBuscar.Value = Producto.CategoriaBuscar;
        //        ComandoMySql.Parameters.Add(parametroCategoriaBuscar);

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

        //#region BUSCAR CATEGORIA
        //public DataTable BuscarCategoria(DatosProducto Producto)
        //{
        //    DataTable listado = new DataTable("producto");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        /*
        //        //SQL SERVER
        //        SqlConexion.ConnectionString = Conexion.cadenaConexion;
        //        SqlCommand ComandoSql = new SqlCommand();
        //        ComandoSql.Connection = SqlConexion;
        //        ComandoSql.CommandText = "buscar_categoria";
        //        ComandoSql.CommandType = CommandType.StoredProcedure;

        //        SqlParameter parametroTextoBuscar = new SqlParameter();
        //        parametroTextoBuscar.ParameterName = "@textoBuscar";
        //        parametroTextoBuscar.SqlDbType = SqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = Categoria.TextoBuscar;
        //        ComandoSql.Parameters.Add(parametroTextoBuscar);

        //        SqlDataAdapter DatosSql = new SqlDataAdapter(ComandoSql);
        //        DatosSql.Fill(listadoCategoria);
        //        */

        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_producto_categoria";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = Producto.Buscar;
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

        //#region BUSCAR CODIGO DE BARRAS
        //public DataTable BuscarCodigo(DatosProducto Producto)
        //{
        //    DataTable listado = new DataTable("producto");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_productocodigobarras";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroTextoBuscar = new MySqlParameter();
        //        parametroTextoBuscar.ParameterName = "partextobuscar";
        //        parametroTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
        //        parametroTextoBuscar.Size = 50;
        //        parametroTextoBuscar.Value = Producto.Buscar;
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

        //#region POR ID DE PRODUCTO
        //public DataTable BuscarArticuloId(int idarticulo)
        //{
        //    DataTable listado = new DataTable("articulo");
        //    MySqlConnection MySqlConexion = new MySqlConnection();
        //    try
        //    {
        //        //MySQL
        //        MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
        //        MySqlCommand ComandoMySql = new MySqlCommand();
        //        ComandoMySql.Connection = MySqlConexion;
        //        ComandoMySql.CommandText = "buscar_producto_id";
        //        ComandoMySql.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter parametroIdProducto = new MySqlParameter();
        //        parametroIdProducto.ParameterName = "paridproducto";
        //        parametroIdProducto.MySqlDbType = MySqlDbType.Int32;
        //        parametroIdProducto.Value = idarticulo;
        //        ComandoMySql.Parameters.Add(parametroIdProducto);

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
        public string Insertar(DatosArticulo Articulo)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection();
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spInsertarArticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Direction = ParameterDirection.Output;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCodigo = new MySqlParameter();
                parametroCodigo.ParameterName = "parCodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Articulo.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroArticulo = new MySqlParameter();
                parametroArticulo.ParameterName = "parArticulo";
                parametroArticulo.MySqlDbType = MySqlDbType.VarChar;
                parametroArticulo.Size = 50;
                parametroArticulo.Value = Articulo.Articulo;
                ComandoMySql.Parameters.Add(parametroArticulo);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Articulo.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);
                
                MySqlParameter parametroPrecioCompra = new MySqlParameter();
                parametroPrecioCompra.ParameterName = "parPrecioCompra";
                parametroPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioCompra.Value = Articulo.PrecioCompra;
                ComandoMySql.Parameters.Add(parametroPrecioCompra);
                
                MySqlParameter parametroPrecioVenta = new MySqlParameter();
                parametroPrecioVenta.ParameterName = "parPrecioVenta";
                parametroPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVenta.Value = Articulo.PrecioVenta;
                ComandoMySql.Parameters.Add(parametroPrecioVenta);
                
                MySqlParameter parametroStock = new MySqlParameter();
                parametroStock.ParameterName = "parStock";
                parametroStock.MySqlDbType = MySqlDbType.Decimal;
                parametroStock.Value = Articulo.Stock;
                ComandoMySql.Parameters.Add(parametroStock);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "parIdPresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Articulo.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Articulo.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRutaImagen = new MySqlParameter();
                parametroRutaImagen.ParameterName = "parRutaImagen";
                parametroRutaImagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRutaImagen.Size = 1024;
                parametroRutaImagen.Value = Articulo.RutaImagen;
                ComandoMySql.Parameters.Add(parametroRutaImagen);

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
        public string Editar(DatosArticulo Articulo, ref MySqlConnection MySqlConexion, ref MySqlTransaction MySqlTransaccion)
        {
            string respuesta = "";
            try
            {
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.Transaction = MySqlTransaccion;
                ComandoMySql.CommandText = "spEditarArticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = Articulo.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCodigo = new MySqlParameter();
                parametroCodigo.ParameterName = "parCodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Articulo.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroArticulo = new MySqlParameter();
                parametroArticulo.ParameterName = "parArticulo";
                parametroArticulo.MySqlDbType = MySqlDbType.VarChar;
                parametroArticulo.Size = 50;
                parametroArticulo.Value = Articulo.Articulo;
                ComandoMySql.Parameters.Add(parametroArticulo);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Articulo.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroPrecioCompra = new MySqlParameter();
                parametroPrecioCompra.ParameterName = "parPrecioCompra";
                parametroPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioCompra.Value = Articulo.PrecioCompra;
                ComandoMySql.Parameters.Add(parametroPrecioCompra);

                MySqlParameter parametroPrecioVenta = new MySqlParameter();
                parametroPrecioVenta.ParameterName = "parPrecioVenta";
                parametroPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVenta.Value = Articulo.PrecioVenta;
                ComandoMySql.Parameters.Add(parametroPrecioVenta);

                MySqlParameter parametroStock = new MySqlParameter();
                parametroStock.ParameterName = "parStock";
                parametroStock.MySqlDbType = MySqlDbType.Decimal;
                parametroStock.Value = Articulo.Stock;
                ComandoMySql.Parameters.Add(parametroStock);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "parIdPresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Articulo.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Articulo.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRuta_Imagen = new MySqlParameter();
                parametroRuta_Imagen.ParameterName = "parRutaImagen";
                parametroRuta_Imagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRuta_Imagen.Size = 1024;
                parametroRuta_Imagen.Value = Articulo.RutaImagen;
                ComandoMySql.Parameters.Add(parametroRuta_Imagen);

                respuesta = ComandoMySql.ExecuteNonQuery() == 1 ? "OK" : "Ocurrió un error al intentar editar el registro. Intente nuevamente.";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string Editar(DatosArticulo Articulo)
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
                ComandoMySql.CommandText = "spEditarArticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = Articulo.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCodigo = new MySqlParameter();
                parametroCodigo.ParameterName = "parCodigo";
                parametroCodigo.MySqlDbType = MySqlDbType.VarChar;
                parametroCodigo.Size = 50;
                parametroCodigo.Value = Articulo.Codigo;
                ComandoMySql.Parameters.Add(parametroCodigo);

                MySqlParameter parametroArticulo = new MySqlParameter();
                parametroArticulo.ParameterName = "parArticulo";
                parametroArticulo.MySqlDbType = MySqlDbType.VarChar;
                parametroArticulo.Size = 50;
                parametroArticulo.Value = Articulo.Articulo;
                ComandoMySql.Parameters.Add(parametroArticulo);

                MySqlParameter parametroIdCategoria = new MySqlParameter();
                parametroIdCategoria.ParameterName = "parIdCategoria";
                parametroIdCategoria.MySqlDbType = MySqlDbType.Int32;
                parametroIdCategoria.Value = Articulo.IdCategoria;
                ComandoMySql.Parameters.Add(parametroIdCategoria);

                MySqlParameter parametroPrecioCompra = new MySqlParameter();
                parametroPrecioCompra.ParameterName = "parPrecioCompra";
                parametroPrecioCompra.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioCompra.Value = Articulo.PrecioCompra;
                ComandoMySql.Parameters.Add(parametroPrecioCompra);

                MySqlParameter parametroPrecioVenta = new MySqlParameter();
                parametroPrecioVenta.ParameterName = "parPrecioVenta";
                parametroPrecioVenta.MySqlDbType = MySqlDbType.Decimal;
                parametroPrecioVenta.Value = Articulo.PrecioVenta;
                ComandoMySql.Parameters.Add(parametroPrecioVenta);

                MySqlParameter parametroStock = new MySqlParameter();
                parametroStock.ParameterName = "parStock";
                parametroStock.MySqlDbType = MySqlDbType.Decimal;
                parametroStock.Value = Articulo.Stock;
                ComandoMySql.Parameters.Add(parametroStock);

                MySqlParameter parametroIdPresentacion = new MySqlParameter();
                parametroIdPresentacion.ParameterName = "parIdPresentacion";
                parametroIdPresentacion.MySqlDbType = MySqlDbType.Int32;
                parametroIdPresentacion.Value = Articulo.IdPresentacion;
                ComandoMySql.Parameters.Add(parametroIdPresentacion);

                MySqlParameter parametroDescripcion = new MySqlParameter();
                parametroDescripcion.ParameterName = "parDescripcion";
                parametroDescripcion.MySqlDbType = MySqlDbType.VarChar;
                parametroDescripcion.Size = 1024;
                parametroDescripcion.Value = Articulo.Descripcion;
                ComandoMySql.Parameters.Add(parametroDescripcion);

                MySqlParameter parametroRuta_Imagen = new MySqlParameter();
                parametroRuta_Imagen.ParameterName = "parRutaImagen";
                parametroRuta_Imagen.MySqlDbType = MySqlDbType.VarChar;
                parametroRuta_Imagen.Size = 1024;
                parametroRuta_Imagen.Value = Articulo.RutaImagen;
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
        public string Eliminar(DatosArticulo Articulo)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spEliminarArticulo";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = Articulo.IdArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

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
        public string DisminuirStock(int idArticulo, decimal cantidad)
        {
            string respuesta = "";
            MySqlConnection MySqlConexion = new MySqlConnection(); // MySQL
            try
            {
                MySqlConexion.ConnectionString = ConexionMySQL.cadenaConexion;
                MySqlConexion.Open();
                MySqlCommand ComandoMySql = new MySqlCommand();
                ComandoMySql.Connection = MySqlConexion;
                ComandoMySql.CommandText = "spDisminuirStock";
                ComandoMySql.CommandType = CommandType.StoredProcedure;

                MySqlParameter parametroIdArticulo = new MySqlParameter();
                parametroIdArticulo.ParameterName = "parIdArticulo";
                parametroIdArticulo.MySqlDbType = MySqlDbType.Int32;
                parametroIdArticulo.Value = idArticulo;
                ComandoMySql.Parameters.Add(parametroIdArticulo);

                MySqlParameter parametroCantidad = new MySqlParameter();
                parametroCantidad.ParameterName = "parCantidad";
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
