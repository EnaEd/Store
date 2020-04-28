using Store.BusinessLogicLayer.Interfaces;
using Stripe;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class StripeService : IStripeService
    {
        public async Task<string> CreateTokenAsync(string customerId, string cardNumber, string cardExpMonth, string cardExpYear, string cardCVC)
        {
            //TODO EE:refactoring
            StripeConfiguration.ApiKey = "pk_test_7wKcaarwLIzmeNzN8yytSDye007sNaNMKA";
            var options = new CardCreateOptions
            {
                Source = "tok_amex"
            };
            var cardService = new CardService();
            Card card = await cardService.CreateAsync(customerId, options);
            //var tokenOptions = new Stripe
            return string.Empty;
        }
    }
}
