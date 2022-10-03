using AutoMapper;
using Humanizer;
using NLog;
using Phantom.API.Common.Helpers;
using Phantom.API.IRepository;
using Phantom.API.IServices;
using Phantom.API.Model;
using Phantom.API.Model.ResponseOBJ;
using System.Globalization;

namespace Phantom.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseResponse<object> _baseResponse;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        private static Logger nLogger = LogManager.GetCurrentClassLogger();
        public OrderService(IBaseResponse<object> baseResponse,
                            IMapper mapper,
                            IOrderRepository orderRepository,
                            IWebHostEnvironment environment,
                            IConfiguration configuration

                           )
        {

            _baseResponse = baseResponse ?? throw new ArgumentNullException(nameof(baseResponse));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }

        public async Task<BaseResponseVm<object>> MakeOrder(IFormFile? orderImage, string size)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            var processId = $"{Guid.NewGuid()}";

            try
            {
                var order = new Order()
                {
                    OrderCode = await _orderRepository.GeneraterRandomValue(6),
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    Price = 7000,
                    DayOfDelivery = DateTime.Now.AddDays(8),
                    OrderStatus = "processing",
                    size = size,
                };

                order.OrderImage = $"Phantom-{DateTime.Now.Year}-{order.OrderCode}-" + orderImage?.FileName;

                var saveuser = await _orderRepository.CreateOrderAsync(order);

                if (saveuser == null)
                {
                    //delete image file incase of failure
                    var msg = "Snap!!, Couldn't Place Order at the Moment, Try again Later.";
                    nLogger.Error(msg + $" Process ID: {processId}");
                    return await _baseResponse.CustomErroMessage(msg, "400");
                }

                if (orderImage?.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Orders"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Orders\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Orders\\" + $"Phantom-{DateTime.Now.Year}-{order.OrderCode}-" + orderImage.FileName))
                    {
                        orderImage.CopyTo(filestream);
                        filestream.Flush();
                    }
                }
                nLogger.Info($"Order Created Successfully. OrderID: {order.OrderCode} ProcessID: {processId}");
                return await _baseResponse.SuccessMessage("200", order.OrderCode);
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<BaseResponseVm<object>> TrackOrder(string? orderCode)
        {
            //check if tracking code exist
            var CodeExist = _orderRepository.CheckOrderByID(orderCode);

            if (CodeExist == false || orderCode.Length < 6)
                return await _baseResponse.CustomErroMessage("Invalid Tracking Code", "400");

            //fetch order details
            var orderDetails = await _orderRepository.GetOrderDetailsByOrderCode(orderCode);
            var details = _mapper.Map<TrackRes>(orderDetails);

            details.DeliveryDay = orderDetails.DayOfDelivery.Humanize();



            return await _baseResponse.SuccessMessage("200", details);

        }


    }
}
