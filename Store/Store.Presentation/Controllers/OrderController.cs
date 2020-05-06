using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.Shared.Constants;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route(Constant.Routes.DEFAULT_API_ROUTE)]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet(Constant.Routes.TEST_ORDER_ROUTE)]
        public async Task<IActionResult> Index()
        {
            await _orderService.CreateOrderAsync();
            return Ok("test order ok");
        }
    }
}
