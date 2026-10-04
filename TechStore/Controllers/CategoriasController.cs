using Microsoft.AspNetCore.Mvc;
using TechStore.Services;

namespace TechStore.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObtenerTodasAsync();
            return View(categorias);
        }
    }
}
