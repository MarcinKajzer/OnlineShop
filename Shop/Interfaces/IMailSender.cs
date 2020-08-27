using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IMailSender
    {
        Task SendPasswordConfirmationAsync(string userEmail, string confirmationLink);
        Task SendOrderSummaryAsync(string userEmail, CreateOrderViewModel products);
    }
}
