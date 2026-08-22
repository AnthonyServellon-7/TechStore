using Microsoft.AspNetCore.Mvc;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            List<Categoria> categorias = new List<Categoria>
            {
                new Categoria
                {
                    Id = 1,
                    Nombre = "Laptops",
                    Descripcion = "Equipos portátiles para trabajo, estudio y gaming.",
                    ImagenUrl = "/images/categorias/laptops.jpg"
                },
                new Categoria
                {
                    Id = 2,
                    Nombre = "Smartphones",
                    Descripcion = "Teléfonos inteligentes de las mejores marcas.",
                    ImagenUrl = "/images/categorias/smartphones.jpg"
                },
                new Categoria
                {
                    Id = 3,
                    Nombre = "Accesorios",
                    Descripcion = "Audífonos, mouse, teclados y más.",
                    ImagenUrl = "/images/categorias/accesorios.jpg"
                },
                new Categoria
                {
                    Id = 4,
                    Nombre = "Componentes",
                    Descripcion = "Piezas y hardware para armar o mejorar tu PC.",
                    ImagenUrl = "/images/categorias/componentes.jpg"
                }
            };

            return View(categorias);
        }
    }
}
