using Store.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IJWTService
    {
        public Task<string> GetTokenAsync(UserModel user);
    }
}
