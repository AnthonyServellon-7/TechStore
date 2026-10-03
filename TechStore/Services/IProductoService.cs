using TechStore.Models;

namespace TechStore.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Producto producto);
        Task EditarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}