using Phantom.API.Context;
using Phantom.API.IRepository;
using Phantom.API.Model;
using System.Text.RegularExpressions;

namespace Phantom.API.Repository
{
    public class UserAccessRepository : IUserAccessRepository
    {
        private readonly PhantomDbContext _context;

        public UserAccessRepository(PhantomDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomerAccountAsync(Customer account)
        {
            try
            {
                if (account is null)
                {
                    return null;
                }
                await _context.Customers.AddAsync(account);
                _context.SaveChanges();

                return account;

            }
            catch (Exception)
            {

                return null;
            }

        }

        public object CreateNewPassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool EmailExist(string email)
        {
            try
            {
                var emailExist = _context.Customers.Where(x => x.Email == email).FirstOrDefault();
                if (emailExist == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool NumberExist(string whatsappNumber)
        {
            try
            {
                var numberExist = _context.Customers.Where(x => x.WhatsappNumber == whatsappNumber).FirstOrDefault();
                if (numberExist == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Match ValidateEmail(string email)
        {
            try
            {
                string _email = email;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(_email);
                return match;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var tokenExist = _context.Customers.Where(x => x.ResetToken == token).FirstOrDefault();
                if (tokenExist == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
