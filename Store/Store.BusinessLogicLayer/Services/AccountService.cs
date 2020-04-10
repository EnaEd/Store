using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository<User> _userRepository;
        private IMapper _mapper;
        public AccountService(IUserRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAllAsync()); ;
        }
    }
}
