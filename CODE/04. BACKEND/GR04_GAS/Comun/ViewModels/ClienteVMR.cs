using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class ClienteVMR
    {
        public long codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public decimal fact_total { get; set; }
    }
}
