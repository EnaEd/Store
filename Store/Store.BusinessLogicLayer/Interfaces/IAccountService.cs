using Store.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        //TODO EE: clarify this method
        public Task<IEnumerable<UserModel>> GetUsers();
        public Task<bool> SigUpAsync(UserModel userModel);
        public Task<bool> SignInAsync(UserModel userModel);
        public Task SignOutAsync();
        public Task<string> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel);
        public Task<string> GenerateEmailConfirmTokenAsync(UserModel userModel);
        public Task<bool> ConfirmEmailAsync(string id, string code);
        public string GenerateTempPassword();
        public Task<bool> ResetPasswordAsync(string email, string token, string password);
    }
}
