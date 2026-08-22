using System.ComponentModel.DataAnnotations;
namespace TechStore.Models
{
    public class Producto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoria { get; set; }

        [StringLength(300)]
        public string Imagen { get; set; }

        public int Stock { get; set; }

        public bool Estado { get; set; }
    }
}
