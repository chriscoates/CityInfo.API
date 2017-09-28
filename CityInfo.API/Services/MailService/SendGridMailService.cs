using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CityInfo.API.Services
{
    public class SendGridMailService : BaseMailService
    {
        private readonly string _apiKey;

        public SendGridMailService(IConfiguration configuration)
            :base (configuration)
        {
            _apiKey = configuration["NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY"];
        }

        public override async Task SendAsync(string subject, string message, string fromEmail, string fromName, string toEmail, string toName)
        {
            Debug.WriteLine($@"Mail from {fromName} ({fromEmail}) to {toName} ({toEmail}), with SendGridMailService.
Subject: {subject}
Message: {message}");

            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail, toName);

            var htmlContent = $"<div>{message}</div>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}