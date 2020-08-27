using Microsoft.AspNetCore.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shop.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class MailSender : IMailSender
    {
        private readonly IWebHostEnvironment _environment;

        public MailSender(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task SendPasswordConfirmationAsync(string userEmail, string confirmationLink)
        {
            string subject = "Potwierdzenie adresu email";

            string emailTemplatePath = Path.Combine(_environment.WebRootPath, "email-templates/email-confirmation.txt");
            string emailTemplate = File.ReadAllText(emailTemplatePath);
            emailTemplate = string.Format(emailTemplate, confirmationLink);

            await Send(subject, userEmail, emailTemplate);
        }

        private async Task Send(string subject, string userEmail, string content)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("shop-online-post@wp.pl", "OnlineShop");
            var to = new EmailAddress(userEmail);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            await client.SendEmailAsync(msg);
        }
    }
}
