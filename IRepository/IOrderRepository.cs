using Phantom.API.Model;

namespace Phantom.API.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<string> GeneraterRandomValue(int length);
        bool CheckOrderByID(string? orderCode);
        //Task<Order> GetOrderDetailsByOrderCode(string? orderCode);
        Task<Order> GetOrderDetailsByOrderCode(string? orderCode);
    }
}
