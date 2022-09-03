using Phantom.API.Context;
using Phantom.API.IRepository;
using Phantom.API.Model;

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
                await _context.SaveChangesAsync();

                return account;



            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool EmailExist(string email)
        {
            try
            {
                var emailExist = _context.Customers.Where(x => x.Email == email).FirstOrDefault();
                if (emailExist == null)
                {
                    return true;
                }
                return false;
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
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
