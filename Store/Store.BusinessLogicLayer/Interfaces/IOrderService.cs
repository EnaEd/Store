using Store.BusinessLogicLayer.Models.Order;
using System;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(OrderRequestModel model, Guid userId);
        public Task<string> CreateAndBuyOrderAsync(OrderRequestModel model, Guid userId);
    }
}
