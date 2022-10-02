using System.ComponentModel.DataAnnotations;

namespace Phantom.API.Model.Dto
{
  
     public class PasswordResetDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
