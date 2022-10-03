using Phantom.API.Model;

namespace Phantom.API.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<string> GeneraterRandomValue(int length);
    }
}
