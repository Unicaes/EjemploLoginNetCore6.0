using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Iniciar(Usuario item)
        {
            if (item==null)
            {
                //no llego la info del formulario
                return Content("No hay data del form");
            }
            testSilkenContext db = new testSilkenContext();
            var user = db.Usuarios.Where(x=>x.Username.Equals(item.Username) && x.Clave.Equals(item.Clave)).ToList();
            if (user.Count == 0)
            {
                //no se encontro el usuario
                return Content("no se encontro el usuario y contrase");
            }

            //entonces aqui ya solo delimitas por permisos adone queres que vaya
            HttpContext.Session.SetString("username", user.FirstOrDefault().Username);
            var username = HttpContext.Session.GetString("username");
            return Content($"Se encontro el usuario {user.FirstOrDefault().Username} con la clave {user.FirstOrDefault().Clave}");
        }
    }
}
