using Microsoft.EntityFrameworkCore;
using Phantom.API.Context;
using Phantom.API.IRepository;
using Phantom.API.Model;

namespace Phantom.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PhantomDbContext _context;

        public OrderRepository(PhantomDbContext context)
        {
            _context = context;
        }



        public bool CheckOrderByID(string? orderCode)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderCode == orderCode);

                if (order != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
                if (order is null)
                {
                    return null;
                }
                await _context.Orders.AddAsync(order);
                _context.SaveChanges();

                return order;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<string> GeneraterRandomValue(int length)
        {
            var str = "";

            do
            {
                str += Guid.NewGuid().ToString().Replace("-", "");
            }
            while (length > str.Length);

            var val = str.Substring(0, length);

            return Task.FromResult(val);
        }

        public async Task<Order> GetOrderDetailsByOrderCode(string? orderCode)
        {
            try
            {

                var order = await _context.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefaultAsync();

                if (order != null)
                {
                    return order;
                }
                return null;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
