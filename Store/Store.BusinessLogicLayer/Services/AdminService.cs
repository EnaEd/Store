using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AdminService(IUserRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserProfileModel>> GetFilteredUserProfileModelsAsync(UserFilterModel userFilterModel = null)
        {

            return _mapper.Map<IEnumerable<UserProfileModel>>(
                await _userRepository.GetFilteredUserProfilesAsync(_mapper.Map<UserFilterEntity>(userFilterModel)));
        }

        public async Task<UserProfileModel> GetProfileModelByUserAsync(UserModel user)
        {

            var filter = new UserFilterEntity();
            filter.Email = user.Email;

            UserProfileModel userProfile = _mapper.Map<IEnumerable<UserProfileModel>>(
                    await _userRepository.GetFilteredUserProfilesAsync(filter)).FirstOrDefault();

            if (userProfile is null)
            {
                throw new UserException { Code = Shared.Enums.ErrorCode.BadRequest, Description = ErrorsConstants.USER_NOT_EXISTS };
            }
            return userProfile;
        }

        public async Task SetBlockUser(UserModel user)
        {
            user.IsBlocked = !user.IsBlocked;
            await _userRepository.UpdateAsync(_mapper.Map<User>(user));
        }
    }
}
