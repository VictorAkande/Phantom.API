using Microsoft.EntityFrameworkCore;
using Phantom.API.Model;

namespace Phantom.API.Context
{
    public class PhantomDbContext : DbContext
    {
        public PhantomDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }  
    }
}
