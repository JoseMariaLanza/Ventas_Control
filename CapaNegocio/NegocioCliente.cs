using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioCliente
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSCLIENTE" DE LA CAPADATOS*/
        public static string Insertar(string nombres, string apellidos, string sexo, DateTime fechaNacimiento, 
            string tipoDocumento, string numeroDocumento, string domicilio, string telefonoFijo, string telefonoCelular, 
            string email)
        {
            DatosCliente Cliente = new DatosCliente();
            Cliente.Nombres = nombres;
            Cliente.Apellidos = apellidos;
            Cliente.Sexo = sexo;
            Cliente.FechaNacimiento = fechaNacimiento;
            Cliente.TipoDocumento = tipoDocumento;
            Cliente.NumeroDocumento = numeroDocumento;
            Cliente.Domicilio = domicilio;
            Cliente.TelefonoFijo = telefonoFijo;
            Cliente.TelefonoCelular = telefonoCelular;
            Cliente.Email = email;
            return Cliente.Insertar(Cliente);
        }
        
        public static string Editar(int idCliente, string nombres, string apellidos, string sexo, DateTime fechaNacimiento,
            string tipoDocumento, string numeroDocumento, string domicilio, string telefonoFijo, string telefonoCelular,
            string email)
        {
            DatosCliente Cliente = new DatosCliente();
            Cliente.IdCliente = idCliente;
            Cliente.Nombres = nombres;
            Cliente.Apellidos = apellidos;
            Cliente.Sexo = sexo;
            Cliente.FechaNacimiento = fechaNacimiento;
            Cliente.TipoDocumento = tipoDocumento;
            Cliente.NumeroDocumento = numeroDocumento;
            Cliente.Domicilio = domicilio;
            Cliente.TelefonoFijo = telefonoFijo;
            Cliente.TelefonoCelular = telefonoCelular;
            Cliente.Email = email;
            return Cliente.Editar(Cliente);
        }

        public static string Editar(int idCliente, string estado)
        {
            DatosCliente Cliente = new DatosCliente();
            Cliente.IdCliente = idCliente;
            Cliente.Estado = estado;
            return Cliente.EditarEstado(Cliente);
        }

        public static string Eliminar(int idCliente)
        {
            DatosCliente Cliente = new DatosCliente();
            Cliente.IdCliente = idCliente;
            return Cliente.Eliminar(Cliente);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosCliente().Mostrar();
        }

        public static DataTable ClienteDefault()
        {
            return new DatosCliente().ClienteDefault();
        }
        
        public static DataTable Buscar(string buscar)
        {
            DatosCliente Cliente = new DatosCliente();
            Cliente.Buscar = buscar;
            return Cliente.BuscarCliente(Cliente);
        }
        
        //public static DataTable BuscarNum_Documento(string textobuscar)
        //{
        //    DatosCliente Cliente = new DatosCliente();
        //    Cliente.Buscar = textobuscar;
        //    return Cliente.BuscarNum_Documento(Cliente);
        //}
    }
}
