using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public async Task<bool> ConfirmEmailAsync(string email, string code)
        {
            if (email is null || code is null)
            {
                return false;
            }
            User user = await _userRepository.GetOneAsync(email);
            if (user is null)
            {
                return false;
            }
            var isConfirmEmail = await _userRepository.ConfirmEmailAsync(user, code);
            if (isConfirmEmail)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return isConfirmEmail;
        }

        public async Task<string> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
        {
            User user = await _userRepository.GetOneAsync(forgotPasswordModel.Email);
            if (user is null || !(await _userRepository.IsEmailConfirmedAsync(user)))
            {
                return null;
            }
            return await _userRepository.GenerateResetPasswordTokenAsync(user);
        }

        public async Task<string> GenerateEmailConfirmTokenAsync(UserModel userModel)
        {
            //for generate token need user with Id
            User user = await _userRepository.GetOneAsync(_mapper.Map<User>(userModel));
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        }

        public string GenerateTempPassword()
        {
            string pattern = @"(?=.*[0 - 9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{16,}";
            string password = GeneratePassword();
            while (Regex.IsMatch(password, pattern))
            {
                password = GeneratePassword();
            }

            return password;
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
            return await _userRepository.CreateAsync(_mapper.Map<User>(userModel), userModel.Password);
        }

        public string GeneratePassword()
        {
            //TODO EE: make better generation password
            string password = string.Empty;
            int[] array = new int[Constanst.PASSWORD_LENGTH];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(Constanst.COMMON_SIMBOLS_RANGE_START, Constanst.COMMON_SIMBOLS_RANGE_END);
                password += (char)array[i];
            }
            return password;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string password)
        {
            User user = await _userRepository.GetOneAsync(email);
            if (user is null)
            {
                return false;
            }
            return await _userRepository.ResetPasswordAsync(user, token, password);
        }
    }
}
