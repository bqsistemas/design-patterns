using API.Services.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StrategyPatternController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<StrategyPatternController> _logger;

        public StrategyPatternController(
            IOrderService orderService,
            ILogger<StrategyPatternController> logger
            )
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        [Route("PostRegisterOrder")]
        public IActionResult PostRegisterOrder()
        {
            #region declare order
            var order = new Order()
            {
                ShippingDetails = new ShippingDetails()
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                },
                TotalPrice = 500m,
                ShipProvider = Business.Enums.ShipProvider.SERPOST
            };
            #endregion

            var result = _orderService.RegisterOrder(order);
            return Ok(result);
        }
        [HttpPost]
        [Route("PostOrderList")]
        public IActionResult PostOrderList()
        {
            #region declare order
            var list = new List<Order>()
            {
                new Order()
                {
                    ShippingDetails = new ShippingDetails()
                    {
                        OriginCountry = "Sweden",
                        DestinationCountry = "Sweden"
                    },
                    TotalPrice = 500m,
                    ShipProvider = Business.Enums.ShipProvider.SERPOST
                },
                new Order()
                {
                    ShippingDetails = new ShippingDetails()
                    {
                        OriginCountry = "Perú",
                        DestinationCountry = "us"
                    },
                    TotalPrice = 500m,
                    ShipProvider = Business.Enums.ShipProvider.SERPOST
                },
                new Order()
                {
                    ShippingDetails = new ShippingDetails()
                    {
                        OriginCountry = "México",
                        DestinationCountry = "us"
                    },
                    TotalPrice = 500m,
                    ShipProvider = Business.Enums.ShipProvider.SERPOST
                }
            };
            #endregion

            var result = _orderService.OrderList(list);
            return Ok(result);
        }
    }
}