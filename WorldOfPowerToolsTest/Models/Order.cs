using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorldOfPowerToolsTest.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите первую строку адреса")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Введите название города")]
        public string City { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Введите название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}