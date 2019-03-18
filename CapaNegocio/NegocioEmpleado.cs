using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioEmpleado
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSTRABAJADOR" DE LA CAPADATOS*/
        public static string Insertar(string nombres, string apellidos, string sexo, DateTime fechaNacimiento, string numeroDocumento,
            string domicilio, string telefonoFijo, string telefonoCelular, string email, string acceso, string usuario, string password)
        {
            DatosEmpleado Empleado = new DatosEmpleado();
            Empleado.Nombres = nombres;
            Empleado.Apellidos = apellidos;
            Empleado.Sexo = sexo;
            Empleado.FechaNacimiento = fechaNacimiento;
            Empleado.NumeroDocumento = numeroDocumento;
            Empleado.Domicilio = domicilio;
            Empleado.TelefonoFijo = telefonoFijo;
            Empleado.TelefonoCelular = telefonoCelular;
            Empleado.Email = email;
            Empleado.Acceso = acceso;
            Empleado.Usuario = usuario;
            Empleado.Password = password;
            return Empleado.Insertar(Empleado);
        }
        
        public static string Editar(int idEmpleado, string nombres, string apellidos, string sexo, DateTime fechaNacimiento, string numeroDocumento,
            string domicilio, string telefonoFijo, string telefonoCelular, string email, string acceso, string usuario, string password)
        {
            DatosEmpleado Empleado = new DatosEmpleado();
            Empleado.IdEmpleado = idEmpleado;
            Empleado.Nombres = nombres;
            Empleado.Apellidos = apellidos;
            Empleado.Sexo = sexo;
            Empleado.FechaNacimiento = fechaNacimiento;
            Empleado.NumeroDocumento = numeroDocumento;
            Empleado.Domicilio = domicilio;
            Empleado.TelefonoFijo = telefonoFijo;
            Empleado.TelefonoCelular = telefonoCelular;
            Empleado.Email = email;
            Empleado.Acceso = acceso;
            Empleado.Usuario = usuario;
            Empleado.Password = password;
            return Empleado.Editar(Empleado);
        }
        
        public static string Eliminar(int idEmpleado)
        {
            DatosEmpleado Empleado = new DatosEmpleado();
            Empleado.IdEmpleado = idEmpleado;
            return Empleado.Eliminar(Empleado);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosEmpleado().Mostrar();
        }
        
        public static DataTable Buscar(string buscar)
        {
            DatosEmpleado Empleado = new DatosEmpleado();
            Empleado.Buscar = buscar;
            return Empleado.BuscarEmpleado(Empleado);
        }
        
        //public static DataTable BuscarNum_Documento(string textobuscar)
        //{
        //    DatosEmpleado Trabajador = new DatosEmpleado();
        //    Trabajador.Buscar = textobuscar;
        //    return Trabajador.BuscarNum_Documento(Trabajador);
        //}

        public static DataTable Login(string usuario, string password)
        {
            DatosEmpleado Empleado = new DatosEmpleado();
            Empleado.Usuario = usuario;
            Empleado.Password = password;
            return Empleado.Login(Empleado);
        }
    }
}
