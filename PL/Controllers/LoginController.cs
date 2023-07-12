using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Login(ML.Usuario usuario, string password)
        {
            var bcrypt = new Rfc2898DeriveBytes(password, new byte[0], 1000, HashAlgorithmName.SHA256);

            var passwordHash = bcrypt.GetBytes(20);

            if (usuario.Nombre != null)
            {
                usuario.Contraseña = passwordHash;
                ML.Result result = BL.Usuario.Add(usuario);
                return View();
            }
            else
            {
                ML.Result result = BL.Usuario.GetByUsername(usuario);
                usuario = (ML.Usuario)result.Object;

                if (result.Correct == true)
                {
                    if (usuario.Contraseña.SequenceEqual(passwordHash))
                    {
                        return RedirectToAction("GetAll", "Restaurante");
                    }
                }
                else
                {
                    ViewBag.Message = "Username o contraseña incorrectos";
                }
            }
            return View("Modal");
        }
    }
}
