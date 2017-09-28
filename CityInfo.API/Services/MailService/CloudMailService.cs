using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API.Services
{
    public class CloudMailService : BaseMailService
    {
        public CloudMailService(IConfiguration configuration)
            :base(configuration)
        {
        }

        public override Task SendAsync(string subject, string message, string fromEmail, string fromName, string toEmail, string toName)
        {
            // send all mail - output to debug window
            Debug.WriteLine($@"Mail from {fromName} ({fromEmail}) to {toName} ({toEmail}), with CloudMailService.
Subject: {subject}
Message: {message}");

            return Task.CompletedTask;
        }
    }
}