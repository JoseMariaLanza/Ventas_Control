using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Informes
{
    public class DatosGastos
    {
        public decimal TotalGastos { get; set; }
        
        public DatosGastos()
        {

        }

        public DatosGastos(decimal totalGastos)
        {
            TotalGastos = totalGastos;
        }
    }
}
