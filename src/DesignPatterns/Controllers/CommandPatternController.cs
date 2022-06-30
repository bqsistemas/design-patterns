using API.Services.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandPatternController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ILogger<CommandPatternController> _logger;

        public CommandPatternController(
            IShoppingCartService shoppingCartService,
            ILogger<CommandPatternController> logger
            )
        {
            _shoppingCartService = shoppingCartService;
            _logger = logger;
        }

        [HttpPost]
        [Route("PostAddToCart")]
        public IActionResult PostAddToCart()
        {
            var item = new Item("ItemName", 20m, Business.Enums.ItemType.Literature);
            _shoppingCartService.AddToCart(item);
            return Ok();
        }
        [HttpPost]
        [Route("PostChangeQuantity")]
        public IActionResult PostChangeQuantity()
        {
            var item = new Item("ItemName", 20m, Business.Enums.ItemType.Literature);
            _shoppingCartService.ChangeQuantity(item, Business.Enums.ChangeQuantityType.Increase);
            return Ok();
        }
    }
}
