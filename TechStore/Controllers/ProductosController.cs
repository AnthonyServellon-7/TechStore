using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Services;

namespace TechStore.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly TechStoreDbContext _context;

        public ProductosController(
            IProductoService productoService,
            TechStoreDbContext context)
        {
            _productoService = productoService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.ObtenerTodosAsync();
            return View(productos);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = new SelectList(
                await _context.Categorias.ToListAsync(),
                "Id",
                "Nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.AgregarAsync(producto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = new SelectList(
                await _context.Categorias.ToListAsync(),
                "Id",
                "Nombre",
                producto.CategoriaId);

            return View(producto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = new SelectList(
                await _context.Categorias.ToListAsync(),
                "Id",
                "Nombre",
                producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoService.EditarAsync(producto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = new SelectList(
                await _context.Categorias.ToListAsync(),
                "Id",
                "Nombre",
                producto.CategoriaId);

            return View(producto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoService.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}