using System.Collections.Generic;

namespace Store.Shared.Providers.Interfaces
{
    public interface IValidationProvider
    {
        public bool TryValidate<T>(T model, out List<string> errors, bool validateAll = true);
    }
}
