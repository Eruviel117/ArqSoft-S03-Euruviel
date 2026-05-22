using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using CatalogoApp.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatalogoApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemService _service;

        public HomeController(ItemService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var todos = _service.ObtenerTodos();

            ViewBag.Total = todos.Count;
            ViewBag.Terminados = todos.Count(i => i.Estado == "Terminado");
            ViewBag.Viendo = todos.Count(i => i.Estado == "Viendo");
            ViewBag.Pausados = todos.Count(i => i.Estado == "Pausado");
            ViewBag.Top3 = todos.OrderByDescending(i => i.Calificacion).Take(3).ToList();

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}  