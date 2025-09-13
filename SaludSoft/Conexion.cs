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
            
            private static string connectionString =
                 "Server=localhost\\SQLEXPRESS;Database=SaludSoft;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
    
}
