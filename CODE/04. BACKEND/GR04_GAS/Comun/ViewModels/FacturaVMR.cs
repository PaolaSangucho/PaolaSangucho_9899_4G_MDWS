using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class FacturaVMR
    {
        public long codigo { get; set; }
        public long cli_codigo { get; set; }
        public string numero { get; set; }
        public System.DateTime fecha { get; set; }
        public decimal montoTotal { get; set; }
    }
}
