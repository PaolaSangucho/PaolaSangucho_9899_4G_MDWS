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
    public class ClienteBLL
    {
        public static ListadoPaginadoVMR<ClienteVMR> Gets(int cantidad, int pagina, string textoBusqueda)
        {
            return ClienteDAL.Gets(cantidad, pagina, textoBusqueda);   
        }

        public static ClienteVMR Get(long codigo)
        {
            return ClienteDAL.Get(codigo);
        }

        public static long Post(CLIENTE item)
        {
            return ClienteDAL.Post(item);
        }

        public static void Put(ClienteVMR item)
        {
            ClienteDAL.Put(item);
        }

        public static void Delete(List<long> codigos)
        {
            ClienteDAL.Delete(codigos);
        }
    }
}
