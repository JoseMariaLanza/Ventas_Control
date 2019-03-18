using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioDeuda
    {
        public static DataTable Mostrar()
        {
            return new DatosDeuda().Mostrar();
        }

        public static DataTable MostrarDeudores()
        {
            return new DatosDeuda().MostrarDeudores();
        }

        public static string AgregarPago(DataRow pago)
        {
            DatosDetalleDeuda detalleDeuda = new DatosDetalleDeuda();
            detalleDeuda.IdDetalleDeuda = Convert.ToInt32(pago["IdDetalleDeuda"]);
            detalleDeuda.NumeroPago = Convert.ToInt32(pago["NumeroPago"]);
            detalleDeuda.Monto = Convert.ToDecimal(pago["Monto"]);
            detalleDeuda.FechaPago = Convert.ToDateTime(pago["FechaPago"]);
            detalleDeuda.Pagado = true;
            return detalleDeuda.AgregarPago(detalleDeuda);
        }

        public static string Editar(int idDeuda, decimal totalPagado, string estadoDeuda, int idCliente, string estadoCliente)
        {
            DatosDeuda Deuda = new DatosDeuda();
            Deuda.IdDeuda = idDeuda;
            Deuda.TotalPagado = totalPagado;
            Deuda.Estado = estadoDeuda;
            DatosCliente Cliente = new DatosCliente();
            Cliente.IdCliente = idCliente;
            Cliente.Estado = estadoCliente;
            return Deuda.Editar(Deuda, Cliente);
        }

        public static string Editar(int idDeuda, decimal totalPagado, string estadoDeuda)
        {
            DatosDeuda Deuda = new DatosDeuda();
            Deuda.IdDeuda = idDeuda;
            Deuda.TotalPagado = totalPagado;
            Deuda.Estado = estadoDeuda;
            return Deuda.Editar(Deuda);
        }
    }
}
