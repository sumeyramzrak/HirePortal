using Hangfire;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendMailService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                RecurringJob.AddOrUpdate(() => SendEmail(), "35 7 * * MON - FRI"); //Hafta içi her sabah 07.35 de mail atsın
            }
            Console.ReadKey();
        }

        public void SendEmail()
        {
            var content = "";
       

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("from name", "gönderici mail adresi"));
            mailMessage.To.Add(new MailboxAddress("to name", "alıcı mail adresi"));
            mailMessage.Subject = "User List";
            mailMessage.Body = new TextPart()
            {
                Text = content
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("gönderici mail adresi", 587, true);
                smtpClient.Authenticate("user", "password");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
