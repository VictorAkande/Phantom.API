using Phantom.API.Common.Helpers;
using Phantom.API.Model.Dto;

namespace Phantom.API.IServices
{
    public interface IUserAccessService
    {
        Task<BaseResponseVm<object>> RegisterCustomer(RegisterCustomerDto model);
    }
}
