using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IMailSender
    {
        Task SendPasswordConfirmationAsync(string userEmail, string confirmationLink);
    }
}
