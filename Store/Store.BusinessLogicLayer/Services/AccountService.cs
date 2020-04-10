using AutoMapper;
using Microsoft.Extensions.Configuration;
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
        private IEmailService _emailService;
        private IConfiguration _configuration;
        public AccountService(IUserRepository<User> userRepository, IMapper mapper,
            IEmailService emailService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _configuration = configuration;
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAllAsync()); ;
        }

        public async Task<bool> Registration(UserModel userModel)
        {
            //TODO EE:add link for confirm,add rollback if not send email
            bool isSuccess = await _userRepository.CreateAsync(_mapper.Map<User>(userModel), userModel.Password);
            if (isSuccess)
            {
                await _emailService.SendEmailAsync(userModel.Email,
                    _configuration["RequestEmail:ThemeMail"],
                    "Test boby message");
            }
            return isSuccess;
        }
    }
}
