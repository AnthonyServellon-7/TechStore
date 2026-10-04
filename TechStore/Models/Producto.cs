using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Models
{
    public class Producto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; } = null!;

        [StringLength(300)]
        public string Imagen { get; set; } = string.Empty;

        [Range(0, 999999999, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        public bool Estado { get; set; }
    }
}