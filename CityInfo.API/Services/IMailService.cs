using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IMailService
    {
        Task SendAsync(string subject, string message);
        Task SendAsync(string subject, string message, string toEmail, string toName);
        Task SendAsync(string subject, string message, string fromEmail, string fromName, string toEmail, string toName);
    }
}