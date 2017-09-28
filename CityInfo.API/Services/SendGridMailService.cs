using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API.Services
{
    public class SendGridMailService : IMailService
    {
        private readonly string _mailTo;
        private readonly string _mailToName;
        private readonly string _mailFrom;
        private readonly string _mailFromName;

        private readonly string _apiKey;

        public SendGridMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailToName = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromName"];
            _mailFromName = configuration["mailSettings:mailFromName"];

            _apiKey = configuration["NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY"];
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
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail, toName);

            var htmlContent = $"<div>{message}</div>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}