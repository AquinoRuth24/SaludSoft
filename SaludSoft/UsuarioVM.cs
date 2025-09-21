using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludSoft.Resources.Models

{
    public enum TipoUsuario { Paciente, Medico, Recepcionista }

    public class UsuarioVM
    {
        public int id_usuario_unico { get; set; }
        public TipoUsuario tipo_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string sexo { get; set; }
        public string estado { get; set; }
        public string nro_historia_clinica { get; set; }
        public string matricula { get; set; }
        public string especialidad { get; set; }
        public string rol_sistema { get; set; }
       
    }
}

