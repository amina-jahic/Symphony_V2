using Symphony_V2.Services.Models;
using System.Threading.Tasks;

namespace Symphony_V2.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
