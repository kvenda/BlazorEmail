using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlazorApp11.Data
{
    public class EmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        public async Task<string> ServiceSendEmail(string sendtoEmail, string sendtoSubject, string sendtoMessage)
        {
            try
            {
                // Email settings.
                var apiKey = configuration["SENDGRID_API_KEY"];
                var senderEmail = configuration["SenderEmail"];
                var senderName = configuration["SenderName"];   //added senderName
                var client = new SendGridClient(apiKey);
                var FromEmail = new EmailAddress(senderEmail, senderName);  // added senderName
                string subject = sendtoSubject;
                var to = new EmailAddress(sendtoEmail);
                var plainTextContent = sendtoMessage;  
                var htmlContent = "<strong>" + plainTextContent + " in html </strong>";
                var msg = MailHelper.CreateSingleEmail(FromEmail, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                return "EMail Sent!";
            }
            catch
            {
                return "Failed to send email";
            };
        }
    }
}
