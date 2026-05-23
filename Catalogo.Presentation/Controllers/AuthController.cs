using CatalogoApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public AuthController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string password)
        {
            var usuario = _usuarioService.Login(nombreUsuario, password);
            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }
            HttpContext.Session.SetString("Usuario", usuario.NombreUsuario);
            return RedirectToAction("Index", "Catalogo");
        }

        public IActionResult Registro() => View();

        [HttpPost]
        public IActionResult Registro(string nombreUsuario, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Todos los campos son obligatorios";
                return View();
            }
            var ok = _usuarioService.Registrar(nombreUsuario, email, password);
            if (!ok)
            {
                ViewBag.Error = "El usuario o email ya existe";
                return View();
            }
            HttpContext.Session.SetString("Usuario", nombreUsuario);
            return RedirectToAction("Index", "Catalogo");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Catalogo");
        }
    }
}