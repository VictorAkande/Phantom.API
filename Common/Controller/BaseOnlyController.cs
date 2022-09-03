using Microsoft.AspNetCore.Mvc;
using Phantom.API.Common.Helpers;

namespace Phantom.API.Common.Controller
{
    [Controller]
    public abstract class BaseOnlyController : ControllerBase
    {
        private readonly IBaseResponse<object> _baseResponse;
        public BaseOnlyController(IBaseResponse<object> baseResponse)
        {
            _baseResponse = baseResponse;
        }
    }
}
