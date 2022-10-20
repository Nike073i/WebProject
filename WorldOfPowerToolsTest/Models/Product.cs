using System.ComponentModel.DataAnnotations;

namespace WorldOfPowerToolsTest.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное значение цены")]
        [Required]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Введите категорию")]
        public string Category { get; set; }
    }
}