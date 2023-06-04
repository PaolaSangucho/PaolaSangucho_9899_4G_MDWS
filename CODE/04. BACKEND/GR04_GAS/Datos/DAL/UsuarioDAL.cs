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
        public static UsuarioVMR Get(string user, string password)
        {
            UsuarioVMR item = null;

            using (var db = DbConexion.Create())
            {
                item = db.USUARIO.Where(u => user.Contains(u.USU_USUARIO) && password.Contains(u.USU_PASSWORD)).Select(u => new UsuarioVMR
                {
                    nombre = u.USU_NOMBRE,
                    apellido = u.USU_APELLIDO,
                    email = u.USU_EMAIL,
                    usuario = u.USU_USUARIO,
                    contrasenia = u.USU_PASSWORD
                }).FirstOrDefault();
            }

            return item;
        }
    }
}
