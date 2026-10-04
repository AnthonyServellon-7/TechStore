using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data
{
    /// <summary>
    /// Carga datos iniciales (solo si las tablas están vacías) para que la aplicación
    /// muestre información desde la base de datos al ejecutarse por primera vez.
    /// </summary>
    public static class DbSeeder
    {
        public static async Task SeedAsync(TechStoreDbContext context)
        {
            if (!await context.Categorias.AnyAsync())
            {
                context.Categorias.AddRange(
                    new Categoria
                    {
                        Nombre = "Laptops",
                        Descripcion = "Equipos portátiles para trabajo, estudio y gaming.",
                        ImagenUrl = "/images/categorias/laptops.jpg"
                    },
                    new Categoria
                    {
                        Nombre = "Smartphones",
                        Descripcion = "Teléfonos inteligentes de las mejores marcas.",
                        ImagenUrl = "/images/categorias/smartphones.jpg"
                    },
                    new Categoria
                    {
                        Nombre = "Accesorios",
                        Descripcion = "Audífonos, mouse, teclados y más.",
                        ImagenUrl = "/images/categorias/accesorios.jpg"
                    },
                    new Categoria
                    {
                        Nombre = "Componentes",
                        Descripcion = "Piezas y hardware para armar o mejorar tu PC.",
                        ImagenUrl = "/images/categorias/componentes.jpg"
                    });

                await context.SaveChangesAsync();
            }

            if (!await context.Productos.AnyAsync())
            {
                var categorias = await context.Categorias
                    .ToDictionaryAsync(c => c.Nombre, c => c.Id);

                context.Productos.AddRange(
                    new Producto
                    {
                        Nombre = "Laptop Pro 15",
                        Descripcion = "Laptop de alto rendimiento con 16 GB de RAM y SSD de 512 GB.",
                        Precio = 1299.99m,
                        CategoriaId = categorias["Laptops"],
                        Imagen = "/images/laptop.jpg",
                        Stock = 8,
                        Estado = true
                    },
                    new Producto
                    {
                        Nombre = "Smartphone X",
                        Descripcion = "Teléfono con pantalla AMOLED y cámara de 50 MP.",
                        Precio = 799.00m,
                        CategoriaId = categorias["Smartphones"],
                        Imagen = "/images/celular.jpg",
                        Stock = 15,
                        Estado = true
                    },
                    new Producto
                    {
                        Nombre = "Tablet 10\"",
                        Descripcion = "Tablet ligera ideal para estudiar y ver contenido.",
                        Precio = 349.50m,
                        CategoriaId = categorias["Smartphones"],
                        Imagen = "/images/tablet.jpg",
                        Stock = 10,
                        Estado = true
                    },
                    new Producto
                    {
                        Nombre = "Audífonos Inalámbricos",
                        Descripcion = "Audífonos Bluetooth con cancelación de ruido.",
                        Precio = 89.99m,
                        CategoriaId = categorias["Accesorios"],
                        Imagen = "/images/audifonos.jpg",
                        Stock = 25,
                        Estado = true
                    },
                    new Producto
                    {
                        Nombre = "Mouse Gamer",
                        Descripcion = "Mouse ergonómico con sensor óptico de alta precisión.",
                        Precio = 39.99m,
                        CategoriaId = categorias["Accesorios"],
                        Imagen = "/images/mouse.jpg",
                        Stock = 30,
                        Estado = true
                    },
                    new Producto
                    {
                        Nombre = "Teclado Mecánico",
                        Descripcion = "Teclado mecánico retroiluminado con switches rojos.",
                        Precio = 69.90m,
                        CategoriaId = categorias["Accesorios"],
                        Imagen = "/images/teclado.jpg",
                        Stock = 0,
                        Estado = false
                    },
                    new Producto
                    {
                        Nombre = "Monitor 27\" 144Hz",
                        Descripcion = "Monitor QHD con tasa de refresco de 144 Hz.",
                        Precio = 289.00m,
                        CategoriaId = categorias["Componentes"],
                        Imagen = "/images/monitor.jpg",
                        Stock = 6,
                        Estado = true
                    },
                    new Producto
                    {
                        Nombre = "SSD NVMe 1TB",
                        Descripcion = "Unidad de estado sólido de alta velocidad de lectura y escritura.",
                        Precio = 94.99m,
                        CategoriaId = categorias["Componentes"],
                        Imagen = "/images/ssd.jpg",
                        Stock = 20,
                        Estado = true
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
