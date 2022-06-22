using Knjižara.Mailer.Models;

namespace Knjižara.Mailer
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest, string? template);
        Task SendMagicLink(MailRequest mailRequest, string magicLink);
    }
}
