using Store.BusinessLogicLayer.Models.Tokens;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IJWTService
    {
        public Task<TokenResponseModel> GetTokensAsync(string userEmail);
        public Task<TokenResponseModel> RefreshTokensAsync(string accessToken, string refreshToken);
    }
}
