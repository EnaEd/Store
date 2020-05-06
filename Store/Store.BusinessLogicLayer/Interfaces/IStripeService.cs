using Store.BusinessLogicLayer.Models.PrintingEdition;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IStripeService
    {
        public Task<dynamic> PayAsync(PayRequestModel model);
    }
}
