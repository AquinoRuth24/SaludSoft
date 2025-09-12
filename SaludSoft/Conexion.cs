using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludSoft
{
        public static class Conexion
        {
            // Cambiá "localhost\\SQLEXPRESS" si tu instancia es distinta
            private static string connectionString =
               "Server=localhost\\SQLEXPRESS;Database=Tp3punto9;Trusted_Connection=True;";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
    
}
