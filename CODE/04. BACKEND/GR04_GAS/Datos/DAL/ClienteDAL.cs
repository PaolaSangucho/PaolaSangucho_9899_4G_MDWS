using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class ClienteDAL
    {
        public static ListadoPaginadoVMR<ClienteVMR> Gets(int cantidad, int pagina, string textoBusqueda)
        {
            ListadoPaginadoVMR<ClienteVMR> resultado = new ListadoPaginadoVMR<ClienteVMR>();
            //

            return resultado;
        }
        public static ClienteVMR Get(long id)
        {
            ClienteVMR item = null;
            //

            return item;
        }
        //Devuelve el PK el elemento creado
        public static long Post(Cliente item)
        {
            long id = 0;
            //
            return id;
        }
        public static void Put(ClienteVMR item)
        {
            //
        }
        public static void Delete(List<long> ids)
        {
            //
        }
    }
}
