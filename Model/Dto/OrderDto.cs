using System.ComponentModel.DataAnnotations;

namespace Phantom.API.Model.Dto
{
    public class OrderDto
    {
        [Required]
        public IFormFile? OrderImage { get; set; }
    }
}
