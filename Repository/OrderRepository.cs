using Microsoft.EntityFrameworkCore;
using Phantom.API.Common.Enums;
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

        public async Task<bool> CancelOrder(string? orderCode)
        {
            try
            {
                var order = _context.Orders.Single(o => o.OrderCode == orderCode);
                order.OrderStatus = nameof(OrderStatus.Canceled);
                var update = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> CheckOrderByID(string? orderCode)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderCode == orderCode);

                if (order != null)
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CheckOrderStausByID(string? orderCode)
        {
            try
            {
                var checkStatus = await _context.Orders.Where(o => o.OrderCode == orderCode && o.OrderStatus == nameof(OrderStatus.Canceled)).FirstOrDefaultAsync();

                if (checkStatus != null)
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);

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

                return await Task.FromResult(order).ConfigureAwait(false);

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

                var order = await _context.Orders.Where(o => o.OrderCode == orderCode).Include(c => c.Customer).FirstOrDefaultAsync();

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
