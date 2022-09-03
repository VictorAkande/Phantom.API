using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phantom.API.Common.Controller;
using Phantom.API.Common.Helpers;
using Phantom.API.IServices;
using Phantom.API.Model.Dto;

namespace Phantom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : BaseOnlyController
    {
        private readonly IBaseResponse<object> _baseResponse;
        private readonly IUserAccessService _userAccessService;

        public UserAccessController(IBaseResponse<object> baseResponse, IUserAccessService userAccessService ) : base(baseResponse)
        {
            _baseResponse = baseResponse;
            _userAccessService = userAccessService;
        }

        [HttpPost]
        [Route("RegisterCustomer")]

        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto model)
        {
            if (!ModelState.IsValid)
            {

            }

            var createUser = _userAccessService.RegisterCustomer(model);

            return StatusCode(201,createUser);
        }
        
    }
}
