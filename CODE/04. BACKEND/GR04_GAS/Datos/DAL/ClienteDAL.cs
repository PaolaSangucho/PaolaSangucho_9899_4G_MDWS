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


            using (var db = DbConexion.Create())
            {
                var query = db.CLIENTE.Where(c => !c.CLI_BORRADO).Select(c => new ClienteVMR
                {
                    codigo = c.CLI_CODIGO,
                    id = c.CLI_ID,
                    nombre = c.CLI_NOMBRE + " " + (c.CLI_APELLIDO != null ? (" " + c.CLI_APELLIDO) : ""),
                    email = c.CLI_EMAIL,
                    fact_total = db.FACTURA.Where(f => !f.FACT_BORRADO && f.CLI_CODIGO == c.CLI_CODIGO).Select(f => f.FACT_MONTOTOTAL).ToList().Sum()
                });

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    query = query.Where(c => 
                                        c.id.Contains(textoBusqueda)
                                        || c.nombre.Contains(textoBusqueda)
                                        );
                }

                resultado.cantidadTotal = query.Count();

                resultado.elementos = query
                    .OrderBy(c => c.codigo)
                    .Skip(pagina * cantidad)
                    .Take(cantidad)
                    .ToList();
                                   
            }

            return resultado;
        }
        public static ClienteVMR Get(long codigo)
        {
            ClienteVMR item = null;

            using (var db = DbConexion.Create())
            {
                item = db.CLIENTE.Where(c => !c.CLI_BORRADO && c.CLI_CODIGO == codigo).Select(c => new ClienteVMR
                {
                    codigo = c.CLI_CODIGO,
                    id = c.CLI_ID,
                    nombre = c.CLI_NOMBRE,
                    apellido = c.CLI_APELLIDO,
                    email = c.CLI_EMAIL,
                    fact_total = db.FACTURA.Where(f => !f.FACT_BORRADO && f.CLI_CODIGO == c.CLI_CODIGO).Select(f => f.FACT_MONTOTOTAL).ToList().Sum()


                }).FirstOrDefault();
            }

            return item;
        }
        //Devuelve el PK el elemento creado
        public static long Post(CLIENTE item)
        {
            long codigo = 0;

            using (var db = DbConexion.Create())
            {
                item.CLI_BORRADO = false;
                db.CLIENTE.Add(item);
                db.SaveChanges();
            }

            return codigo;
        }
        public static void Put(ClienteVMR item)
        {
            using (var db = DbConexion.Create())
            {
                var itemUpdate = db.CLIENTE.Find(item.codigo);

                itemUpdate.CLI_NOMBRE = item.nombre;
                itemUpdate.CLI_APELLIDO = item.apellido;
                itemUpdate.CLI_ID = item.id;
                itemUpdate.CLI_EMAIL = item.email;
                itemUpdate.CLI_TEL = item.telefono;
                itemUpdate.CLI_DIRECCION = item.direccion; 
                
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void Delete(List<long> codigos)
        {
            using (var db = DbConexion.Create())
            {
                var items = db.CLIENTE.Where(c => codigos.Contains(c.CLI_CODIGO));

                foreach (var item in items)
                {
                    item.CLI_BORRADO = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
    }
}
