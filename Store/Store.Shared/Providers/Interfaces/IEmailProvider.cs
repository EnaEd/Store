using System.Threading.Tasks;

namespace Store.Shared.Providers.Interfaces
{
    public interface IEmailProvider
    {
        public Task SendEmailAsync(string mail, string subject, string message);
    }
}
