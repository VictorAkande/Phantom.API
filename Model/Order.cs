using System.ComponentModel.DataAnnotations;

namespace Phantom.API.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public IFormFile? OrderImage { get; set; }
        [Required]
        public string OrderCode { get; set; }
        public bool? OrderStatus { get; set; }
        [Required]
        public DateTimeOffset DayOfDelivery { get; set; }
        [Required]
        public DateTimeOffset Date  { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CustomerId { get; set; }

    }
}
