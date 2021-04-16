using System.ComponentModel.DataAnnotations;

namespace testblazorwasm.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(0.01, 9999)]
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}