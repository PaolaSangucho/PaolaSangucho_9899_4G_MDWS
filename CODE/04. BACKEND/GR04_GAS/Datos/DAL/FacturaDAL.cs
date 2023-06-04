using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class FacturaDAL
    {
        public static ListadoPaginadoVMR<FacturaVMR> Gets(int cantidad, int pagina, string textoBusqueda)
        {
            ListadoPaginadoVMR<FacturaVMR> resultado = new ListadoPaginadoVMR<FacturaVMR>();


            using (var db = DbConexion.Create())
            {
                var query = db.FACTURA.Where(f => !f.FACT_BORRADO).Select(f => new FacturaVMR
                {
                    codigo = f.FACT_CODIGO,
                    cli_codigo = f.CLI_CODIGO,
                    numero = f.FACT_NUMERO,
                    fecha = f.FACT_FECHA,
                    montoTotal = f.FACT_MONTOTOTAL
                });

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    query = query.Where(f => f.numero.Contains(textoBusqueda));
                }

                resultado.cantidadTotal = query.Count();

                resultado.elementos = query
                    .OrderBy(f => f.codigo)
                    .Skip(pagina * cantidad)
                    .Take(cantidad)
                    .ToList();

            }

            return resultado;
        }

        public static FacturaVMR Get(long codigo)
        {
            FacturaVMR item = null;

            using (var db = DbConexion.Create())
            {
                item = db.FACTURA.Where(f => !f.FACT_BORRADO && f.FACT_CODIGO == codigo).Select(f => new FacturaVMR
                {
                   codigo = f.CLI_CODIGO,
                   cli_codigo = f.CLI_CODIGO,
                   numero = f.FACT_NUMERO,
                   fecha = f.FACT_FECHA,
                   montoTotal = f.FACT_MONTOTOTAL
                   
                }).FirstOrDefault();
            }

            return item;
        }

        //Devuelve el PK el elemento creado
        public static long Post(FACTURA item)
        {
            long codigo = 0;

            using (var db = DbConexion.Create())
            {
                item.FACT_BORRADO = false;
                db.FACTURA.Add(item);
                db.SaveChanges();
            }

            return codigo;
        }

        public static void Put(FacturaVMR item)
        {
            using (var db = DbConexion.Create())
            {
                var itemUpdate = db.FACTURA.Find(item.codigo);

                itemUpdate.FACT_NUMERO = item.numero;
                itemUpdate.FACT_FECHA = item.fecha;
                itemUpdate.FACT_MONTOTOTAL = item.montoTotal;

                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(List<long> codigos)
        {
            using (var db = DbConexion.Create())
            {
                var items = db.FACTURA.Where(f => codigos.Contains(f.FACT_CODIGO));

                foreach (var item in items)
                {
                    item.FACT_BORRADO = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
    }
}
