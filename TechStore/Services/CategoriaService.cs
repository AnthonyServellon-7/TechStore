using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;

namespace TechStore.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly TechStoreDbContext _context;

        public CategoriaService(TechStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ObtenerTodasAsync()
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .ToListAsync();
        }
    }
}
