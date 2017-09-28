using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API.Services
{
    public class LocalMailService : BaseMailService
    {
        public LocalMailService(IConfiguration configuration)
            :base(configuration)
        {
        }

        public override Task SendAsync(string subject, string message, string fromEmail, string fromName, string toEmail, string toName)
        {
            // send all mail - output to debug window
            Debug.WriteLine($@"Mail from {fromName} ({fromEmail}) to {toName} ({toEmail}), with LocalMailService.
Subject: {subject}
Message: {message}");

            return Task.CompletedTask;
        }
    }
}