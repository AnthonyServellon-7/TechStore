using Microsoft.AspNetCore.Mvc;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            List<Producto> productos = new List<Producto>()
            {


                new Producto
                {
                    ID = 1,
                    Nombre = "Laptop Gamer ",
                    Descripcion = " Procesador de alto rendimiento. Ideal para disfrutar videojuegos con gráficos fluidos.",
                    Precio = 1199.00M,
                    Categoria = "Laptops",
                    Imagen = "/images/laptop.jpg",
                    Stock = 10,
                    Estado = true
                },

                new Producto
                {
                    ID = 2,
                    Nombre = "iPhone 14 Pro",
                    Descripcion = "Pantalla Super Retina XDR con Dynamic Island y cámara de 48 MP.",
                    Precio = 899.00M,
                    Categoria = "Celulares",
                    Imagen = "/images/celular.jpg",
                    Stock = 15,
                    Estado = true
                },

                new Producto
                {
                    ID = 3,
                    Nombre = "Audífonos Gamer ",
                    Descripcion = "Sonido envolvente con micrófono e iluminación RGB.",
                    Precio = 59.99M,
                    Categoria = "Accesorios",
                    Imagen = "/images/audifonos.jpg",
                    Stock = 0,
                    Estado = false
                },

                new Producto
                {
                    ID = 4,
                    Nombre = "Teclado Mecánico Gamer",
                    Descripcion = "Switches mecánicos e iluminación RGB personalizable.",
                    Precio = 49.99M,
                    Categoria = "Accesorios",
                    Imagen = "/images/teclado.jpg",
                    Stock = 25,
                    Estado = true
                },

                new Producto
                {
                    ID = 5,
                    Nombre = "Monitor Gamer ",
                    Descripcion = "Pantalla Full HD de 27 pulgadas con 1ms de respuesta",
                    Precio = 179.99M,
                    Categoria = "Monitores",
                    Imagen = "/images/monitor.jpg",
                    Stock = 8,
                    Estado = true
                },

                new Producto
                {
                    ID = 6,
                    Nombre = "Mouse Óptico Gamer",
                    Descripcion = "Sensor de alta precisión con botones programables.",
                    Precio = 29.99M,
                    Categoria = "Accesorios",
                    Imagen = "/images/mouse.jpg",
                    Stock = 5,
                    Estado = true
                },

                new Producto
                {
                    ID = 7,
                    Nombre = "Smartwatch Pro",
                    Descripcion = "Reloj inteligente con pantalla AMOLED, monitoreo de actividad y conexión Bluetooth.",
                    Precio = 129.99M,
                    Categoria = "Smartwatches",
                    Imagen = "/images/smartwatch.jpg",
                    Stock = 12,
                    Estado = true
                },

                new Producto
                {
                    ID = 8,
                    Nombre = "Tablet Galaxy Tab",
                    Descripcion = "Tablet con pantalla de alta resolución, gran rendimiento y batería de larga duración.",
                    Precio = 349.99M,
                    Categoria = "Tablets",
                    Imagen = "/images/tablet.jpg",
                    Stock = 10,
                    Estado = true
                },

                new Producto
                {
                    ID = 9,
                    Nombre = "PlayStation 5",
                    Descripcion = "Consola de nueva generación con gráficos en alta resolución y almacenamiento SSD.",
                    Precio = 499.99M,
                    Categoria = "Consolas",
                    Imagen = "/images/ps5.jpg",
                    Stock = 6,
                    Estado = false
                },

                new Producto
                {
                    ID = 10,
                    Nombre = "Cámara Digital 4K",
                    Descripcion = "Cámara digital con grabación 4K, enfoque automático y excelente calidad de imagen.",
                    Precio = 599.99M,
                    Categoria = "Cámaras",
                    Imagen = "/images/camara.jpg",
                    Stock = 5,
                    Estado = true
                },


                new Producto
                {
                    ID = 11,
                    Nombre = "SSD Externo 1TB",
                    Descripcion = "Unidad SSD portátil de 1TB con transferencia de datos rápida y diseño compacto.",
                    Precio = 89.99M,
                    Categoria = "Almacenamiento",
                    Imagen = "/images/ssd.jpg",
                    Stock = 20,
                    Estado = true
                },

                new Producto
                {
                    ID = 12,
                    Nombre = "Parlante Bluetooth",
                    Descripcion = "Parlante portátil con sonido potente, conexión Bluetooth y batería de larga duración.",
                    Precio = 69.99M,
                    Categoria = "Audio",
                    Imagen = "/images/parlante.jpg",
                    Stock = 14,
                    Estado = true
                },

                new Producto
                {
                    ID = 13,
                    Nombre = "Nokia 3310 Clásico",
                    Descripcion = "El clásico que no necesita 5G, cámara de 200 MP ni cargador rápido.",
                    Precio = 49.99M,
                    Categoria = "Celulares",
                    Imagen = "/images/nokia3310.jpg",
                    Stock = 3,
                    Estado = false
                }


            };




            return View(productos);
        }
    }
}