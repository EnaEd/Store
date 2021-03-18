using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Order;
using Store.Shared.Constants;
using System;
using System.Security.Claims;
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
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderRequestModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _orderService.CreateOrderAsync(model, Guid.Parse(userId));
            return Ok(Constant.Info.ORDER_CREATE_SUCCESS);
        }

        [HttpPost(Constant.Routes.ORDER_BUY_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> BuyOrderAsync([FromBody] OrderRequestModel model)
        {
            //TODO EE: pay notification by webhook
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string result = await _orderService.CreateAndBuyOrderAsync(model, Guid.Parse(userId));
            return Ok(result);
        }

        [HttpPost(Constant.Routes.ORDER_DELETE_ROUTE)]
        public async Task<IActionResult> DeleteOrderAsync([FromBody] OrderModel model)
        {
            throw new NotImplementedException();
            //await _orderService.CreateOrderAsync(model);
            //return Ok(Constant.Info.ORDER_CREATE_SUCCESS);
        }
    }
}
