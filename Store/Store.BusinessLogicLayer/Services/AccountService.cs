using Store.BusinessLogicLayer.Interfaces;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository<User> _userRepository;
        public AccountService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var test = await _userRepository.GetAllAsync();
            return null;
        }
    }
}
