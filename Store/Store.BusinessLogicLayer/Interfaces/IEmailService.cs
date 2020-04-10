using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string mail, string subject, string message);
    }
}
