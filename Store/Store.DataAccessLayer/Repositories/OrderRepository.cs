using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository<Order>
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public override async Task<Order> GetOneAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
