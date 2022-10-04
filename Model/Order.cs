using Phantom.API.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Phantom.API.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string? OrderImage { get; set; }
        [Required]
        public string OrderCode { get; set; }

        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public string OrderStatus { get; set; }
        [Required]
        public DateTimeOffset DayOfDelivery { get; set; }
        [Required]
        public DateTimeOffset OrderDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string size { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        //  public int CustomerId { get; set; }



    }
}
