using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PLM.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {     
            return View();
        }

        [Authorize] 
        public IActionResult Ingresar()
        {            
            if (User.HasClaim(c => c.Type == "UsuarioValido"))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("AccesoDenegado", "Home");
        }
    }
}
