using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechStore.Models;
using TechStore.Services;

namespace TechStore.Controllers
{
    public class ProductosController : Controller
    {
        // El controlador depende de abstracciones (interfaces), no de implementaciones
        // ni del DbContext: el contenedor de dependencias entrega las instancias.
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        public ProductosController(
            IProductoService productoService,
            ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.ObtenerTodosAsync();
            return View(productos);
        }

        public async Task<IActionResult> Create()
        {
            await CargarCategoriasAsync();
            return View(new Producto { Estado = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                await CargarCategoriasAsync(producto.CategoriaId);
                return View(producto);
            }

            await _productoService.AgregarAsync(producto);

            TempData["SuccessMessage"] = "Producto agregado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            await CargarCategoriasAsync(producto.CategoriaId);
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

            if (!ModelState.IsValid)
            {
                await CargarCategoriasAsync(producto.CategoriaId);
                return View(producto);
            }

            var actualizado = await _productoService.EditarAsync(producto);

            if (!actualizado)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = "Producto actualizado correctamente.";
            return RedirectToAction(nameof(Index));
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
            var eliminado = await _productoService.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = "Producto eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarCategoriasAsync(int? categoriaSeleccionada = null)
        {
            var categorias = await _categoriaService.ObtenerTodasAsync();

            ViewBag.Categorias = new SelectList(
                categorias,
                nameof(Categoria.Id),
                nameof(Categoria.Nombre),
                categoriaSeleccionada);
        }
    }
}
