using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IStripeService
    {
        public Task<string> CreateTokenAsync(string customerId, string cardNumber, string cardExpMonth, string cardExpYear, string cardCVC);
    }
}
