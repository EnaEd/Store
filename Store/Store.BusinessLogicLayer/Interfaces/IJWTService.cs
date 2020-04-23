using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IJWTService
    {
        public Task<(string accessToken, string refreshToken)> GetTokensAsync(string userEmail);
        public Task<(string accessToken, string refreshToken)> RefreshTokensAsync(string accessToken, string refreshToken);
    }
}
