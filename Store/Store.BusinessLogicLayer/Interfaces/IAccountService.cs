using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        public Task<IEnumerable<UserModel>> GetUsers();
        public Task SigUpAsync(UserModel userModel);
        public Task<TokenResponseModel> SignInAsync(UserModel userModel);
        public Task SignOutAsync();
        public Task ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel);
        public Task ConfirmEmailAsync(ConfirmEmailRequestModel model);
    }
}
