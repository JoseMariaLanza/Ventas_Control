using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioArticulo
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSPRODUCTO" DE LA CAPADATOS*/
        public static string Insertar(string codigo, string articulo, int idCategoria, decimal precioCompra, decimal precioVenta, 
            decimal stock, int idPresentacion, string descripcion, string rutaImagen)
        {
            DatosArticulo Articulo = new DatosArticulo();
            Articulo.Codigo = codigo;
            Articulo.Articulo = articulo;
            Articulo.IdCategoria = idCategoria;
            Articulo.PrecioCompra = precioCompra;
            Articulo.PrecioVenta = precioVenta;
            Articulo.Stock = stock;
            Articulo.IdPresentacion = idPresentacion;
            Articulo.Descripcion = descripcion;
            Articulo.RutaImagen = rutaImagen;
            return Articulo.Insertar(Articulo);
        }

        // mostrar productos con stock minimo
        public static DataTable Mostrar(decimal stockMinimo)
        {
            return new DatosArticulo().Mostrar(stockMinimo);
        }
        
        public static string Editar(int idArticulo, string codigo, string articulo, int idCategoria, decimal precioCompra,
            decimal precioVenta, decimal stock, int idPresentacion, string descripcion, string rutaImagen)
        {
            DatosArticulo Articulo = new DatosArticulo();
            Articulo.IdArticulo = idArticulo;
            Articulo.Codigo = codigo;
            Articulo.Articulo = articulo;
            Articulo.IdCategoria = idCategoria;
            Articulo.PrecioCompra = precioCompra;
            Articulo.PrecioVenta = precioVenta;
            Articulo.Stock = stock;
            Articulo.IdPresentacion = idPresentacion;
            Articulo.Descripcion = descripcion;
            Articulo.RutaImagen = rutaImagen;
            return Articulo.Editar(Articulo);
        }
        
        public static string Eliminar(int idArticulo)
        {
            DatosArticulo Articulo = new DatosArticulo();
            Articulo.IdArticulo = idArticulo;
            return Articulo.Eliminar(Articulo);
        }

        public static string DisminuirStock(int idArticulo, decimal cantidad)
        {
            DatosArticulo Articulo = new DatosArticulo();
            return Articulo.DisminuirStock(idArticulo, cantidad);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosArticulo().Mostrar();
        }

        //public static DataTable BuscarProductoId(int idproducto)
        //{
        //    DatosArticulo Producto = new DatosArticulo();
        //    Producto.IdArticulo = idproducto;
        //    return Producto.BuscarProductoId(Producto);
        //}
        
        public static DataTable Buscar(string buscar)
        {
            DatosArticulo Articulo = new DatosArticulo();
            Articulo.Buscar = buscar;
            return Articulo.BuscarArticulo(Articulo);
        }

        public static DataTable Buscar(int idArticulo)
        {
            DatosArticulo Articulo = new DatosArticulo();
            return Articulo.BuscarArticulo(idArticulo);
        }

        //public static DataTable BuscarCategoria(string textobuscar)
        //{
        //    DatosArticulo Producto = new DatosArticulo();
        //    Producto.Buscar = textobuscar;
        //    return Producto.BuscarCategoria(Producto);
        //}

        //public static DataTable BuscarProductoCategoria(string textobuscar, string categoria)
        //{
        //    DatosArticulo Producto = new DatosArticulo();
        //    Producto.Buscar = textobuscar;
        //    Producto.CategoriaBuscar = categoria;
        //    return Producto.BuscarProductoCategoria(Producto);
        //}

        //public static DataTable BuscarCodigo(string textobuscar)
        //{
        //    DatosArticulo Producto = new DatosArticulo();
        //    Producto.Buscar = textobuscar;
        //    return Producto.BuscarCodigo(Producto);
        //}

        //public static DataTable BuscarArticuloId(int idarticulo)
        //{
        //    DatosArticulo Producto = new DatosArticulo();
        //    return Producto.BuscarArticuloId(idarticulo);
        //}
    }
}
