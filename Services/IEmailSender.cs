using System.Threading.Tasks;

namespace OtherPerspectivesWebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}