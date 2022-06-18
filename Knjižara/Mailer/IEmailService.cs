using Knjižara.Mailer.Models;

namespace Knjižara.Mailer
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
