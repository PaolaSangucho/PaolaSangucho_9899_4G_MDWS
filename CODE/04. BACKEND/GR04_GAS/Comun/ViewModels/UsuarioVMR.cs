using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class UsuarioVMR
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public bool isAdmin { get; set; }
    }
}
