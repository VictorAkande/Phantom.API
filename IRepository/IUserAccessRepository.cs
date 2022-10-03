using Phantom.API.Model;
using System.Text.RegularExpressions;

namespace Phantom.API.IRepository
{
    public interface IUserAccessRepository
    {
        bool EmailExist(string email);
        bool NumberExist(string whatsappNumber);
        Task<Customer> CreateCustomerAccountAsync(Customer account);
        bool ValidateToken(string token);
        object CreateNewPassword(string newPassword);
        Match ValidateEmail(string email);
    }

}
