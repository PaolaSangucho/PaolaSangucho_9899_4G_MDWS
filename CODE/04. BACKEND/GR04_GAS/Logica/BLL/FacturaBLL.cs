using Comun.ViewModels;
using Datos.DAL;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.BLL
{
    public class FacturaBLL
    {
        public static ListadoPaginadoVMR<FacturaVMR> Gets(int cantidad, int pagina, string textoBusqueda)
        {
            return FacturaDAL.Gets(cantidad, pagina, textoBusqueda);    
        }

        public static FacturaVMR Get(long codigo)
        {
            return FacturaDAL.Get(codigo);
        }

        public static long Post(FACTURA item)
        {
            return FacturaDAL.Post(item);   
        }

        public static void Put(FacturaVMR item)
        {
            FacturaDAL.Put(item);
        }

        public static void Delete(List<long> codigos)
        {
            FacturaDAL.Delete(codigos);
        }
    }
}
