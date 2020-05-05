using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;

namespace Store.DataAccessLayer.Repositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository<Order>
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
