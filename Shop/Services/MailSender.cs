using Microsoft.AspNetCore.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shop.Interfaces;
using Shop.ViewModels;
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
        public async Task SendEmailConfirmationAsync(string userEmail, string confirmationLink)
        {
            string subject = "Potwierdzenie adresu email";

            string emailTemplate = ReadTemplate("email-confirmation.html");
            emailTemplate = string.Format(emailTemplate, confirmationLink);

            await Send(subject, userEmail, emailTemplate);
        }

        public async Task SendPasswordResetAsync(string userEmail, string resetLink)
        {
            string subject = "Przywracanie hasła";

            string emailTemplate = ReadTemplate("reset-password.html");
            emailTemplate = string.Format(emailTemplate, resetLink);

            await Send(subject, userEmail, emailTemplate);
        }

        public async Task SendOrderSummaryAsync(string userEmail, CreateOrderViewModel model)
        {
            string subject = "Podsumowanie zamówienia";

            string singleProductTemplate = ReadTemplate("single-product.html");
            string allProducts = string.Empty;

            foreach(var item in model.Items)
                allProducts += string.Format(singleProductTemplate, item.Name, item.Quantity, item.FormatedAmount, item.Size);

            string emailTemplate = ReadTemplate("order-summary.html");
            emailTemplate = string.Format(emailTemplate, model.CreationDate.ToShortDateString(), model.CreationDate.ToShortTimeString(), allProducts, model.FormatedTotalAmount);

            await Send(subject, userEmail, emailTemplate);
        }


        private string ReadTemplate(string fileName)
        {
            string templatePath = Path.Combine(_environment.WebRootPath, "email-templates", fileName);
            string template = File.ReadAllText(templatePath);
            return template;
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
