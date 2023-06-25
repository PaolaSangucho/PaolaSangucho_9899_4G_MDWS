using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class UsuarioDAL
    {
        public static UsuarioVMR Login(string user, string password)
        {
            UsuarioVMR item = null;

            using (var db = DbConexion.Create())
            {
                item = db.USUARIO.Where(u => user == u.USU_USUARIO && password == u.USU_PASSWORD).Select(u => new UsuarioVMR
                {
                    USU_NOMBRE = u.USU_NOMBRE,
                    USU_APELLIDO = u.USU_APELLIDO,
                    USU_EMAIL = u.USU_EMAIL,
                    USU_USUARIO = u.USU_USUARIO,
                    USU_PASSWORD = u.USU_PASSWORD,
                    USU_ISADMIN = u.USU_ISADMIN
                }).FirstOrDefault();
            }

            return item;
        }
    }
}
