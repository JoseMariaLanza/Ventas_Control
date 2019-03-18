using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioTrabajador
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSTRABAJADOR" DE LA CAPADATOS*/
        public static string Insertar(string nombre, string apellido, string sexo, DateTime fecha_nacimiento, string num_documento,
            string domicilio, string tel_fijo, string tel_cel, string email, string acceso, string usuario, string password)
        {
            DatosTrabajador Trabajador = new DatosTrabajador();
            Trabajador.Nombre = nombre;
            Trabajador.Apellido = apellido;
            Trabajador.Sexo = sexo;
            Trabajador.Fecha_Nacimiento = fecha_nacimiento;
            Trabajador.Num_Documento = num_documento;
            Trabajador.Domicilio = domicilio;
            Trabajador.Tel_Fijo = tel_fijo;
            Trabajador.Tel_Cel = tel_cel;
            Trabajador.Email = email;
            Trabajador.Acceso = acceso;
            Trabajador.Usuario = usuario;
            Trabajador.Password = password;
            return Trabajador.Insertar(Trabajador);
        }
        
        public static string Editar(int idtrabajador, string nombre, string apellido, string sexo, DateTime fecha_nacimiento, string num_documento,
            string domicilio, string tel_fijo, string tel_cel, string email, string acceso, string usuario, string password)
        {
            DatosTrabajador Trabajador = new DatosTrabajador();
            Trabajador.IdTrabajador = idtrabajador;
            Trabajador.Nombre = nombre;
            Trabajador.Apellido = apellido;
            Trabajador.Sexo = sexo;
            Trabajador.Fecha_Nacimiento = fecha_nacimiento;
            Trabajador.Num_Documento = num_documento;
            Trabajador.Domicilio = domicilio;
            Trabajador.Tel_Fijo = tel_fijo;
            Trabajador.Tel_Cel = tel_cel;
            Trabajador.Email = email;
            Trabajador.Acceso = acceso;
            Trabajador.Usuario = usuario;
            Trabajador.Password = password;
            return Trabajador.Editar(Trabajador);
        }
        
        public static string Eliminar(int idtrabajador)
        {
            DatosTrabajador Trabajador = new DatosTrabajador();
            Trabajador.IdTrabajador = idtrabajador;
            return Trabajador.Eliminar(Trabajador);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosTrabajador().Mostrar();
        }
        
        public static DataTable BuscarNombre(string textobuscar)
        {
            DatosTrabajador Trabajador = new DatosTrabajador();
            Trabajador.TextoBuscar = textobuscar;
            return Trabajador.BuscarNombre(Trabajador);
        }
        
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DatosTrabajador Trabajador = new DatosTrabajador();
            Trabajador.TextoBuscar = textobuscar;
            return Trabajador.BuscarNum_Documento(Trabajador);
        }

        public static DataTable Login(string usuario, string password)
        {
            DatosTrabajador Trabajador = new DatosTrabajador();
            Trabajador.Usuario = usuario;
            Trabajador.Password = password;
            return Trabajador.Login(Trabajador);
        }
    }
}
