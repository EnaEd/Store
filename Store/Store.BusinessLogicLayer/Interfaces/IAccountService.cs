using Store.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        public Task<IEnumerable<UserModel>> GetUsers();
        public Task SigUpAsync(UserModel userModel);
        public Task SignInAsync(UserModel userModel);
        public Task SignOutAsync();
        public Task<string> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel);
        public Task<string> GenerateEmailConfirmTokenAsync(UserModel userModel);
        public Task ConfirmEmailAsync(string id, string code);
        public string GenerateTempPassword();
        public Task ResetPasswordAsync(string email, string token, string password);
    }
}
