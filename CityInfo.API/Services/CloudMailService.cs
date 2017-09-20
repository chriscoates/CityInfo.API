using System.Diagnostics;

namespace CityInfo.API.Services
{
    public class CloudMailService
  {
    private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
    private string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];

    public void SendAsync(string subject, string message)
    {
      // send all mail - output to debug window
      Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
      Debug.WriteLine($"Subject: {subject}");
      Debug.WriteLine($"Message: {message}");
    }
  }
}