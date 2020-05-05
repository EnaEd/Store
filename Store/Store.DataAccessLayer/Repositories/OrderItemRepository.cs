using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;

namespace Store.DataAccessLayer.Repositories
{
    public class OrderItemRepository : BaseEFRepository<OrderItem>, IOrderItemRepository<OrderItem>
    {
        public OrderItemRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
