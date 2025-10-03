using SaludSoft.Resources;
using SaludSoft.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludSoft
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            //Application.Run(new SaludSoft());
            //Application.Run(new Admin());
            //Application.Run(new Medico());
            //Application.Run(new FormGestionUsuario());

        }
    }
}
