using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludSoft.Security
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Rol { get; set; }

        public static bool EstaLogueado => IdUsuario > 0;

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Nombre = null;
            Rol = null;
        }
    }
}
