using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioGastos
    {
        /*MÉTODOS QUE LLAMAN A LOS MÉTODOS CORRESPONDIENTES DE LA CLASE "DATOSGASTOS" DE LA CAPADATOS*/
        public static string Insertar(string concepto, string descripcion, decimal monto, string periodo, DateTime fecha)
        {
            DatosGastos Gastos = new DatosGastos();
            Gastos.Concepto = concepto;
            Gastos.Descripcíon = descripcion;
            Gastos.Monto = monto;
            Gastos.Periodo = periodo;
            Gastos.Fecha = fecha;
            return Gastos.Insertar(Gastos);
        }
        
        public static string Editar(int idGasto, string concepto, string descripcion, decimal monto, string periodo, DateTime fecha)
        {
            DatosGastos Gastos = new DatosGastos();
            Gastos.IdGasto = idGasto;
            Gastos.Concepto = concepto;
            Gastos.Descripcíon = descripcion;
            Gastos.Monto = monto;
            Gastos.Periodo = periodo;
            Gastos.Fecha = fecha;
            return Gastos.Editar(Gastos);
        }
        
        public static string Eliminar(int idgasto)
        {
            DatosGastos Gastos = new DatosGastos();
            Gastos.IdGasto = idgasto;
            return Gastos.Eliminar(Gastos);
        }
        
        public static DataTable Mostrar()
        {
            return new DatosGastos().Mostrar();
        }

        public static DataTable Mostrar(DateTime fecha1, DateTime fecha2)
        {
            return new DatosGastos().Mostrar(fecha1, fecha2);
        }
    }
}
