using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioProveedor
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSPROVEEDOR" DE LA CAPADATOS*/
        public static string Insertar(string nombres, string apellidos, string rubro, string tipoDocumento, string numeroDocumento,
            string domicilio, string telefonoFijo, string telefonoCelular, string email, string url)
        {
            DatosProveedor Proveedor = new DatosProveedor();
            Proveedor.Nombres = nombres;
            Proveedor.Apellidos = apellidos;
            Proveedor.Rubro = rubro;
            Proveedor.TipoDocumento = tipoDocumento;
            Proveedor.NumeroDocumento = numeroDocumento;
            Proveedor.Domicilio = domicilio;
            Proveedor.TelefonoFijo = telefonoFijo;
            Proveedor.TelefonoCelular = telefonoCelular;
            Proveedor.Email = email;
            Proveedor.URL = url;
            return Proveedor.Insertar(Proveedor);
        }
        
        public static string Editar(int idProveedor, string nombres, string apellidos, string rubro, string tipoDocumento, string numeroDocumento,
            string domicilio, string telefonoFijo, string telefonoCelular, string email, string url)
        {
            DatosProveedor Proveedor = new DatosProveedor();
            Proveedor.IdProveedor = idProveedor;
            Proveedor.Nombres = nombres;
            Proveedor.Apellidos = apellidos;
            Proveedor.Rubro = rubro;
            Proveedor.TipoDocumento = tipoDocumento;
            Proveedor.NumeroDocumento = numeroDocumento;
            Proveedor.Domicilio = domicilio;
            Proveedor.TelefonoFijo = telefonoFijo;
            Proveedor.TelefonoCelular = telefonoCelular;
            Proveedor.Email = email;
            Proveedor.URL = url;
            return Proveedor.Editar(Proveedor);
        }
        
        public static string Eliminar(int idProveedor)
        {
            DatosProveedor Proveedor = new DatosProveedor();
            Proveedor.IdProveedor = idProveedor;
            return Proveedor.Eliminar(Proveedor);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosProveedor().Mostrar();
        }
        
        public static DataTable Buscar(string buscar)
        {
            DatosProveedor Proveedor = new DatosProveedor();
            Proveedor.Buscar = buscar;
            return Proveedor.BuscarProveedor(Proveedor);
        }
        
        //public static DataTable BuscarNum_Documento(string textobuscar)
        //{
        //    DatosProveedor Proveedor = new DatosProveedor();
        //    Proveedor.Buscar = textobuscar;
        //    return Proveedor.BuscarNum_Documento(Proveedor);
        //}
    }
}
