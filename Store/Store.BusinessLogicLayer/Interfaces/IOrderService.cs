using Store.BusinessLogicLayer.Models.Order;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(OrderModel model);
    }
}
