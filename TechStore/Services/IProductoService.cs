using TechStore.Models;

namespace TechStore.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Producto producto);

        /// <summary>Actualiza el producto. Devuelve false si no existe.</summary>
        Task<bool> EditarAsync(Producto producto);

        /// <summary>Elimina el producto. Devuelve false si no existe.</summary>
        Task<bool> EliminarAsync(int id);
    }
}
