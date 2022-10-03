using Phantom.API.Common.Helpers;

namespace Phantom.API.IServices
{
    public interface IOrderService
    {
        Task<BaseResponseVm<object>> MakeOrder(IFormFile? orderImage, string size);
        Task<BaseResponseVm<object>> TrackOrder(string? orderCode);
        Task CancelOrder(string? orderCode);
    }
}
