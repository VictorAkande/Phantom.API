using Phantom.API.Model.Dto;

namespace Phantom.API.Model.ResponseOBJ
{
    public class TrackRes
    {
        public string? OrderImage { get; set; }
        public string OrderCode { get; set; }
        public string? OrderStatus { get; set; }
        public DateTimeOffset DayOfDelivery { get; set; }
        public string DeliveryDay { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Price { get; set; }
        public string size { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
