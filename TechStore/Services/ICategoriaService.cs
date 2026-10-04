using TechStore.Models;

namespace TechStore.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> ObtenerTodasAsync();
    }
}
