using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
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

        public async Task ConfirmEmailAsync(string email, string code)
        {
            if (email is null || code is null)
            {
                throw new UserException { Code = ErrorCode.BadRequest, Description = ErrorsConstants.EMPTY_FIELD };
            }

            if (!(await _userRepository.GetOneAsync(email) is User user))
            {
                throw new UserException { Code = ErrorCode.NotFound, Description = ErrorsConstants.USER_NOT_EXISTS };
            }

            if (!await _userRepository.ConfirmEmailAsync(user, code))
            {
                throw new UserException { Code = ErrorCode.BadRequest, Description = ErrorsConstants.CONFIRM_EMAIL_FAIL };
            }

            await _signInManager.SignInAsync(user, false);
        }

        public async Task<string> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
        {
            if (!(await _userRepository.GetOneAsync(forgotPasswordModel.Email) is User user))
            {
                throw new UserException { Code = ErrorCode.NotFound, Description = ErrorsConstants.USER_NOT_EXISTS };
            }
            if (!(await _userRepository.IsEmailConfirmedAsync(user)))
            {
                throw new UserException { Code = ErrorCode.BadRequest, Description = ErrorsConstants.EMAIL_NOT_CONFIRM };
            }
            string token = await _userRepository.GenerateResetPasswordTokenAsync(user);
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new UserException { Code = ErrorCode.BadRequest, Description = ErrorsConstants.GENERATE_TOKEN_FAIL };
            }
            return token;
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

        public async Task SignInAsync(UserModel userModel)
        {
            User user = await _userRepository.GetOneAsync(_mapper.Map<User>(userModel));
            if (user is null)
            {
                throw new UserException { Code = ErrorCode.Unauthorized, Description = ErrorsConstants.USER_NOT_EXISTS };
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);
            if (!result.Succeeded)
            {
                throw new UserException { Code = ErrorCode.Unauthorized, Description = ErrorsConstants.PASSWORD_NOT_MATCH };

            }
            await _signInManager.SignInAsync(user, false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SigUpAsync(UserModel userModel)
        {
            if (!await _userRepository.CreateAsync(_mapper.Map<User>(userModel), userModel.Password))
            {
                throw new UserException { Code = ErrorCode.BadRequest, Description = ErrorsConstants.CREATE_USER_FAIL };
            }
        }

        public string GeneratePassword()
        {
            //TODO EE: make better generation password
            string password = string.Empty;
            int[] array = new int[Constant.PASSWORD_LENGTH];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(Constant.COMMON_SIMBOLS_RANGE_START, Constant.COMMON_SIMBOLS_RANGE_END);
                password += (char)array[i];
            }
            return password;
        }

        public async Task ResetPasswordAsync(string email, string token, string password)
        {
            if (!(await _userRepository.GetOneAsync(email) is User user))
            {
                throw new UserException { Code = ErrorCode.NotFound, Description = ErrorsConstants.USER_NOT_EXISTS };
            }
            if (!await _userRepository.ResetPasswordAsync(user, token, password))
            {
                throw new UserException { Code = ErrorCode.BadRequest, Description = ErrorsConstants.RESET_PASSWORD_FAIL };
            }
        }
    }
}
