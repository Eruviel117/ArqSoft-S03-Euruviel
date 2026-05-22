using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ItemService _service;
        private readonly ComentarioService _comentarioService;

        public CatalogoController(ItemService service, ComentarioService comentarioService)
        {
            _service = service;
            _comentarioService = comentarioService;
        }

        // Lista con filtro opcional por género y orden
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

        // Detalle
        public IActionResult Detalle(int id)
        {
            var item = _service.ObtenerPorId(id);
            if (item == null) return NotFound();

            ViewBag.Comentarios = _comentarioService.ObtenerPorItem(id);
            ViewBag.Usuario = HttpContext.Session.GetString("Usuario");
            return View(item);
        }

        // Agregar comentario
        [HttpPost]
        public IActionResult AgregarComentario(int itemId, string texto, int calificacion)
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            if (usuario == null) return RedirectToAction("Login", "Auth");

            _comentarioService.Agregar(new Comentario
            {
                ItemId = itemId,
                Usuario = usuario,
                Texto = texto,
                Calificacion = calificacion
            });

            return RedirectToAction("Detalle", new { id = itemId });
        }

        // Agregar — GET
        public IActionResult Agregar() => View();

        // Agregar — POST
        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            _service.Agregar(item);
            return RedirectToAction("Index");
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

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}