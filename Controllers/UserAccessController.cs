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

        public UserAccessController(IBaseResponse<object> baseResponse, IUserAccessService userAccessService) : base(baseResponse)
        {
            _baseResponse = baseResponse;
            _userAccessService = userAccessService;
        }

        [HttpPost]
        [Route("RegisterCustomer")]

        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return StatusCode(400, await _baseResponse.CustomErroMessage("400", "Paramaeters Cannot be Empty"));
            }

            var createUser = await _userAccessService.RegisterCustomer(model);

            return StatusCode(int.Parse(createUser.code), createUser);
        }

        [HttpPost]
        [Route("ForgotPassword/{token}")]

        public async Task<IActionResult> ForgotPassword([FromRoute] string token, [FromBody] PasswordResetDto model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, await _baseResponse.CustomErroMessage("400", "Paramaeters Cannot be Empty"));
            }

            var reset = await _userAccessService.ResetPassword(model, token);

            return StatusCode(201, reset);
        }

    }
}
