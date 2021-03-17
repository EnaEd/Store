using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Order;
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

        [HttpPost(Constant.Routes.ORDER_CREATE_ROUTE)]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderModel model)
        {
            await _orderService.CreateOrderAsync(model);
            return Ok(Constant.Info.ORDER_CREATE_SUCCESS);
        }
    }
}
