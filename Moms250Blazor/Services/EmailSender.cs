using Microsoft.Extensions.Options;
using Moms250Blazor.Common;
using Moms250Blazor.Data.Repository;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Moms250Blazor.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailAsync(string email, string subject, string body, Attachment? attach = null);
    }

    public class EmailSender(IOptions<SmtpConfig?> smtpConfig, ILoggerFactory loggerFactory, IWebHostEnvironment env, IExceptionLogRepo eLog) : IEmailSender
    {
        readonly IOptions<SmtpConfig?> _smtpConfig = smtpConfig;
        readonly ILogger _logger = loggerFactory.CreateLogger<EmailSender>();
        readonly IWebHostEnvironment _env = env;
        private IExceptionLogRepo _eLog = eLog;

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return SendEmailAsync(email, subject, message, null);
        }
        public Task SendEmailAsync(string email, string subject, string body, Attachment? attach = null)
        {
            int retVal = 0;
            try
            {
                string[]? tos = null;

                if (_smtpConfig?.Value?.Debug ?? true)
                {
                    body = string.Format("{0}<br />DEBUG EMAIL from [{1}] - Original To's: {2}", body, _env.EnvironmentName, email);
                    email = _smtpConfig?.Value?.DebugEmailAddress ?? "erikcheatham@gmail.com";
                }
                if (email.Contains(';') || email.Contains(','))
                {
                    tos = email.Split([';', ',']);
                    if (tos.Length > 0)
                    {
                        email = tos[0];
                    }
                }
                MailMessage message = new(_smtpConfig?.Value?.From ?? "no-reply@statmtf.azurewebsites.net", email, subject, body) { BodyEncoding = Encoding.UTF8, SubjectEncoding = Encoding.UTF8, IsBodyHtml = true };
                if (tos != null && tos.Length > 1)
                {
                    for (int loop = 1; loop < tos.Length; loop++)
                    {
                        message.To.Add(tos[loop]);
                    }
                }
                message.From = new MailAddress(_smtpConfig?.Value?.From ?? "no-reply@statmtf.azurewebsites.net", _smtpConfig?.Value?.FromDisplayName);
                if (attach != null)
                {
                    message.Attachments.Add(attach);
                }
                if (_smtpConfig?.Value?.Enabled ?? false)
                {
                    SmtpClient mySmtpClient;
                    NetworkCredential creds;
                    if (_smtpConfig?.Value?.FileSystemMail ?? false)
                    {
                        mySmtpClient = new SmtpClient() { DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory, PickupDirectoryLocation = _smtpConfig?.Value?.FileSystemFolder ?? "C:\\temp" };
                    }
                    else
                    {
                        creds = new NetworkCredential(_smtpConfig?.Value?.User, _smtpConfig?.Value?.Pass);
                        mySmtpClient = new SmtpClient() { DeliveryMethod = SmtpDeliveryMethod.Network, Credentials = creds, Host = _smtpConfig?.Value?.Server ?? "smtp.sendgrid.net", Port = _smtpConfig?.Value?.Port ?? 587, EnableSsl = true };
                    }
                    mySmtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Data.ExceptionLog el = new Data.ExceptionLog()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };
                _eLog.AddExceptionLogAsync(el, "System");
                _logger.LogCritical(new EventId(100, "Email"), ex, "Unable to send email");
                retVal = -1;
            }
            return Task.FromResult(retVal);
        }
    }
}
