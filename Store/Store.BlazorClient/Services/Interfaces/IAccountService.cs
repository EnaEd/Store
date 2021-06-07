using Store.BlazorClient.Models;
using Store.BlazorClient.Models.RequestModel;
using System.Threading.Tasks;

namespace Store.BlazorClient.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<TokenModel> SignInAsync(SignInRequestModel model);
    }
}
