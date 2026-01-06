
public interface IEmailService
{
    string CreateWinnerTemplate(string userName, string giftName);
    Task SendEmailAsync(string toEmail, string subject, string body);
}