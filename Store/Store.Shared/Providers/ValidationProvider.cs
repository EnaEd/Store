using Store.Shared.Constants;
using Store.Shared.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Store.Shared.Providers
{
    public class ValidationProvider : IValidationProvider
    {
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

        public bool TryValidate<T>(T model, out List<string> errors, bool validateAll = true)
        {
            errors = new List<string>();
            var validationResult = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            if (!Validator.TryValidateObject(model, validationContext, validationResult, validateAll))
            {
                errors = validationResult.Select(error => error.ErrorMessage).ToList();
                return false;
            }
            return true;
        }

        private string GeneratePassword()
        {
            //TODO EE: make better generation password
            string password = string.Empty;
            int[] array = new int[Constant.PasswordConfig.PASSWORD_LENGTH];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(Constant.PasswordConfig.COMMON_SIMBOLS_RANGE_START, Constant.PasswordConfig.COMMON_SIMBOLS_RANGE_END);
                password += (char)array[i];
            }
            return password;
        }
    }
}
