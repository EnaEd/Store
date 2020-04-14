using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        public AccountService(IUserRepository<User> userRepository, IMapper mapper,
            IEmailService emailService, IConfiguration configuration, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public Task ForgotPasswordAsync(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAllAsync()); ;
        }

        public async Task<bool> SignInAsync(UserModel userModel)
        {
            User user = await _userRepository.GetOneAsync(_mapper.Map<User>(userModel));
            if (user is null)
            {
                return false;
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);
            if (!result.Succeeded)
            {
                return false;
            }
            await _signInManager.SignInAsync(user, false);
            return true;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> SigUpAsync(UserModel userModel)
        {
            //TODO EE:add link for confirm,add rollback if not send email
            bool isSuccess = await _userRepository.CreateAsync(_mapper.Map<User>(userModel), userModel.Password);
            if (isSuccess)
            {
                await _emailService.SendEmailAsync(userModel.Email,
                    _configuration["RequestEmail:ThemeMail"],
                    "click this link for confirm registration <br> <a> https://localhost:5001/<a/>");
            }
            return isSuccess;
        }
    }
}
