using Microsoft.AspNetCore.Mvc;
using Phantom.API.Common.Helpers;
using Phantom.API.IServices;
using Phantom.API.Model.Dto;

namespace Phantom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBaseResponse<object> _baseResponse;
        private readonly IOrderService _orderService;

        public OrderController(IWebHostEnvironment environment, IBaseResponse<object> baseResponse, IOrderService orderService)
        {
            _baseResponse = baseResponse;
            _orderService = orderService;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IActionResult> MakeOrder([FromForm] OrderDto model)
        {

            if (model == null || !ModelState.IsValid)
            {
                return StatusCode(400, await _baseResponse.CustomErroMessage("400", "Paramaeters Cannot be Empty"));
            }

            //

            var createOrder = await _orderService.MakeOrder(model.OrderImage, model.size);

            return StatusCode(201, createOrder);
        }

        [HttpPost]
        [Route("TrackOrder")]
        public async Task<IActionResult> TrackOrder([FromBody] TrackOrderDto model)
        {

            if (model == null || !ModelState.IsValid)
            {
                return StatusCode(400, await _baseResponse.CustomErroMessage("400", "Paramaeters Cannot be Empty"));
            }
            var createOrder = await _orderService.TrackOrder(model.OrderCode);
            return StatusCode(int.Parse(createOrder.code), createOrder);
        }

        [HttpPost]
        [Route("CancelOrder")]
        public async Task<IActionResult> CancelOrder([FromBody] TrackOrderDto model)
        {

            if (model == null || !ModelState.IsValid)
            {
                return StatusCode(400, await _baseResponse.CustomErroMessage("400", "Paramaeters Cannot be Empty"));
            }
            var createOrder = await _orderService.CancelOrder(model.OrderCode);

            return StatusCode(200, createOrder);
        }
    }
}
