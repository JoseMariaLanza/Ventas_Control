using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConexionMySQL
    {
        public static string cadenaConexion = Properties.Settings.Default.cn;
        //"datasource=127.0.0.1; port=3306; Initial Catalog=sale_manager; username=root;password=";
    }
}
//server=127.0.0.1;user id=root;database=sale_manager