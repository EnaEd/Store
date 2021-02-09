using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAdminService
    {
        Task<UserProfileModel> GetProfileModelByUserAsync(UserModel user);
        Task<IEnumerable<UserProfileModel>> GetFilteredUserProfileModelsAsync(UserFilterModel userFilterModel = null);
        Task SetBlockUserAsync(UserModel user);
        Task Authenticate(TokenResponseModel tokenResponseModel);


    }
}
