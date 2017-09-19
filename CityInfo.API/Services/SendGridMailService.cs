using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;

namespace CityInfo.API.Services
{
    public class SendGridMailService : IMailService
    {
        private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        private string _mailToName = Startup.Configuration["mailSettings:mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSettings:mailFromName"];
        private string _mailFromName = Startup.Configuration["mailSettings:mailFromName"];

        public SendGridMailService()
        {
        }

        public Task SendAsync(string subject, string message)
        {
            return SendAsync(subject, message, _mailFrom, _mailFromName, _mailTo, _mailToName);
        }

        public Task SendAsync(string subject, string message, string toEmail, string toName)
        {
            return SendAsync(subject, message, _mailFrom, _mailFromName, toEmail, toName);
        }

        public async Task SendAsync(string subject, string message, string fromEmail, string fromName, string toEmail, string toName)
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail, toName);

            var htmlContent = $"<div>{message}</div>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}