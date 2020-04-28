using Store.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Interfaces
{
    public interface IAdminRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IEnumerable<UserProfileEntity>> GetFilteredUserProfilesAsync(UserFilterEntity filterEntity = null);
    }
}
