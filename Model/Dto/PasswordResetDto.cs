namespace Phantom.API.Model.Dto
{
  
     public class PasswordResetDto
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
