using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Order;
using System;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderModel> CreateOrderAsync()
        {
            throw new NotImplementedException();
        }
    }
}
