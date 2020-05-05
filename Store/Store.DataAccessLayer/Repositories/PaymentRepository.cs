using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;

namespace Store.DataAccessLayer.Repositories
{
    public class PaymentRepository : BaseEFRepository<Payment>, IPaymentRepository<Payment>
    {
        public PaymentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
