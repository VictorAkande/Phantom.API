namespace Phantom.API.Model.Dto
{
    public class RegisterCustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string WhatsappNumber { get; set; } = string.Empty;
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}
