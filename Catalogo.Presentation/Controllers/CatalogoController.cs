using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ItemService _service;

        // El servicio llega por inyección de dependencias
        public CatalogoController(ItemService service)
        {
            _service = service;
        }

        // Lista con filtro opcional por género
        public IActionResult Index(string? genero)
        {
            var items = string.IsNullOrEmpty(genero)
                ? _service.ObtenerTodos()
                : _service.ObtenerPorGenero(genero);

            ViewBag.Generos = _service.ObtenerGeneros();
            ViewBag.GeneroActual = genero;

            return View(items);
        }

        // Detalle de un item
        public IActionResult Detalle(int id)
        {
            var item = _service.ObtenerPorId(id);
            return item == null ? NotFound() : View(item);
        }
        // Editar — GET
        public IActionResult Editar(int id)
        {
            var item = _service.ObtenerPorId(id);
            return item == null ? NotFound() : View(item);
        }

        // Editar — POST
        [HttpPost]
        public IActionResult Editar(Item item)
        {
            _service.Editar(item);
            return RedirectToAction("Index");
        }

        // Formulario — GET
        public IActionResult Agregar()
        {
            return View();
        }

        // Formulario — POST
        [HttpPost]
        public IActionResult Index(string? genero, string? orden)
        {
            var items = string.IsNullOrEmpty(genero)
                ? _service.ObtenerTodos()
                : _service.ObtenerPorGenero(genero);

            items = orden switch
            {
                "calificacion" => items.OrderByDescending(i => i.Calificacion).ToList(),
                "ano" => items.OrderByDescending(i => i.Ano).ToList(),
                "titulo" => items.OrderBy(i => i.Titulo).ToList(),
                _ => items
            };

            ViewBag.Generos = _service.ObtenerGeneros();
            ViewBag.GeneroActual = genero;
            ViewBag.Orden = orden;

            return View(items);
        }

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}