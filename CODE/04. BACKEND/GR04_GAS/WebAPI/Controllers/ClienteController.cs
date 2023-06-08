using Comun.ViewModels;
using Logica.BLL;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        public IHttpActionResult Gets(int cantidad = 10, int pagina = 0, string textoBusqueda = null)
        {
            var respuesta = new RespuestaVMR<ListadoPaginadoVMR<ClienteVMR>>();

            try
            {
                respuesta.datos = ClienteBLL.Gets(cantidad, pagina, textoBusqueda);
            } catch(Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(ex.Message);
                respuesta.mensajes.Add(ex.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpGet]
        public IHttpActionResult Get(long codigo)
        {
            var respuesta = new RespuestaVMR<ClienteVMR>();

            try
            {
                respuesta.datos = ClienteBLL.Get(codigo);
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(ex.Message);
                respuesta.mensajes.Add(ex.ToString());
            }

            if(respuesta.datos == null && respuesta.mensajes.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Elemento no encontrado!");
            }

            return Content(respuesta.codigo, respuesta);
        }

        public IHttpActionResult Post(CLIENTE item)
        {

        }

        public IHttpActionResult Put(long codigo, ClienteVMR item)
        {

        }

        public IHttpActionResult Delete(List<long> codigo)
        {

        }
    }
}
