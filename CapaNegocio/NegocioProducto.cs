using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioProducto
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSPRODUCTO" DE LA CAPADATOS*/
        public static string Insertar(string codigo, string nombre, int idcategoria, decimal precio_compra, decimal precio_venta, 
            decimal stock, int idpresentacion, string descripcion, string ruta_imagen)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.Codigo = codigo;
            Producto.Nombre = nombre;
            Producto.IdCategoria = idcategoria;
            Producto.Precio_Compra = precio_compra;
            Producto.Precio_Venta = precio_venta;
            Producto.Stock = stock;
            Producto.IdPresentacion = idpresentacion;
            Producto.Descripcion = descripcion;
            Producto.Ruta_Imagen = ruta_imagen;
            return Producto.Insertar(Producto);
        }

        // mostrar productos con stock minimo
        public static DataTable Mostrar(decimal stockminimo)
        {
            return new DatosProducto().Mostrar(stockminimo);
        }
        
        public static string Editar(int idproducto, string codigo, string nombre, int idcategoria, decimal precio_compra, decimal precio_venta, 
            decimal stock, int idpresentacion, string descripcion, string ruta_imagen)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.IdProducto = idproducto;
            Producto.Codigo = codigo;
            Producto.Nombre = nombre;
            Producto.IdCategoria = idcategoria;
            Producto.Precio_Compra = precio_compra;
            Producto.Precio_Venta = precio_venta;
            Producto.Stock = stock;
            Producto.IdPresentacion = idpresentacion;
            Producto.Descripcion = descripcion;
            Producto.Ruta_Imagen = ruta_imagen;
            return Producto.Editar(Producto);
        }
        
        public static string Eliminar(int idproducto)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.IdProducto = idproducto;
            return Producto.Eliminar(Producto);
        }

        public static string DisminuirStock(int idproducto, decimal cantidad)
        {
            DatosProducto Producto = new DatosProducto();
            return Producto.DisminuirStock(idproducto, cantidad);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosProducto().Mostrar();
        }

        public static DataTable BuscarProductoId(int idproducto)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.IdProducto = idproducto;
            return Producto.BuscarProductoId(Producto);
        }
        
        public static DataTable BuscarNombre(string textobuscar)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.TextoBuscar = textobuscar;
            return Producto.BuscarNombre(Producto);
        }
        
        public static DataTable BuscarCategoria(string textobuscar)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.TextoBuscar = textobuscar;
            return Producto.BuscarCategoria(Producto);
        }

        public static DataTable BuscarProductoCategoria(string textobuscar, string categoria)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.TextoBuscar = textobuscar;
            Producto.CategoriaBuscar = categoria;
            return Producto.BuscarProductoCategoria(Producto);
        }
        
        public static DataTable BuscarCodigo(string textobuscar)
        {
            DatosProducto Producto = new DatosProducto();
            Producto.TextoBuscar = textobuscar;
            return Producto.BuscarCodigo(Producto);
        }

        public static DataTable BuscarArticuloId(int idarticulo)
        {
            DatosProducto Producto = new DatosProducto();
            return Producto.BuscarArticuloId(idarticulo);
        }
    }
}
