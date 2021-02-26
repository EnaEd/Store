using Store.Shared.Providers.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.Shared.Providers
{
    public class ValidationProvider : IValidationProvider
    {
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
    }
}
