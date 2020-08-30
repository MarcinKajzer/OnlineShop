using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IMailSender
    {
        Task SendEmailConfirmationAsync(string userEmail, string confirmationLink);
        Task SendPasswordResetAsync(string userEmail, string resetLink);
        Task SendOrderSummaryAsync(string userEmail, CreateOrderViewModel products);
    }
}
