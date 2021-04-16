using System.ComponentModel.DataAnnotations;

namespace testwebapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0.01, 9999)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}