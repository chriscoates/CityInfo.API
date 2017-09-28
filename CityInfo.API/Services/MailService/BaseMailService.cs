using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API.Services
{
    public abstract class BaseMailService : IMailService
    {
        protected readonly string _mailTo;
        protected readonly string _mailToName;
        protected readonly string _mailFrom;
        protected readonly string _mailFromName;

        protected BaseMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailToName = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromName"];
            _mailFromName = configuration["mailSettings:mailFromName"];
        }

        public Task SendAsync(string subject, string message)
        {
            return SendAsync(subject, message, _mailFrom, _mailFromName, _mailTo, _mailToName);
        }

        public Task SendAsync(string subject, string message, string toEmail, string toName)
        {
            return SendAsync(subject, message, _mailFrom, _mailFromName, toEmail, toName);
        }

        public abstract Task SendAsync(string subject, string message, string fromEmail, string fromName, string toEmail, string toName);
    }
}
