using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class PaymentRepository : BaseEFRepository<Payment>, IPaymentRepository<Payment>
    {
        public PaymentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        public override async Task<Payment> GetOneAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstAsync(x => x.Id == id);
            return result;
        }
    }
}
