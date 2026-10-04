using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;

namespace TechStore.Services
{
    public class ProductoService : IProductoService
    {
        private readonly TechStoreDbContext _context;

        public ProductoService(TechStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .OrderBy(p => p.ID)
                .ToListAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task AgregarAsync(Producto producto)
        {
            NormalizarTextos(producto);

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditarAsync(Producto producto)
        {
            var existe = await _context.Productos.AnyAsync(p => p.ID == producto.ID);

            if (!existe)
            {
                return false;
            }

            NormalizarTextos(producto);

            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return false;
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        // Los campos de texto opcionales llegan como null desde el formulario;
        // las columnas de la base de datos no aceptan nulos.
        private static void NormalizarTextos(Producto producto)
        {
            producto.Descripcion ??= string.Empty;
            producto.Imagen ??= string.Empty;
        }
    }
}
