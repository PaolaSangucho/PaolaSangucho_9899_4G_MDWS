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
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LeerUno(string user, string password)
        {
            var respuesta = new RespuestaVMR<UsuarioVMR>();

            try
            {
                respuesta.datos = UsuarioBLL.LeerUno(user, password);
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(ex.Message);
                respuesta.mensajes.Add(ex.ToString());
            }

            if (respuesta.datos == null && respuesta.mensajes.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Usuario no encontrado!");
            }

            return Content(respuesta.codigo, respuesta);
        }

        
        [HttpPost]
        [Route("api/usuario/{user}/{password}")]
        public IHttpActionResult Login(string user, string password)
        {
            var respuesta = new RespuestaVMR<UsuarioVMR>();
            var userAux = user;
            var passwordAux = password;
            try
            {
                respuesta.datos = UsuarioBLL.LeerUno(user, password);
            }
            catch (Exception ex)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(ex.Message);
                respuesta.mensajes.Add(ex.ToString());
            }

            if (respuesta.datos == null && respuesta.mensajes.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Usuario no encontrado!");
            }

            return Content(respuesta.codigo, respuesta);
        }
    }
}
