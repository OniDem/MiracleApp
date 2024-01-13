using Abstract.Services;
using Core.Entity;
using DTO.Mail;
using Infrastructure.Repositories;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;


namespace Services
{
    public class MailService : Abstract.Services.IMailService
    {
        private MailRepository _mailRepository;
        public MailService(MailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }
        public async Task<MailEntity> SendCode(SendCodeRequest request)
        {
            return _mailRepository.SendCode(new MailEntity
            {
                Phone = request.Phone,
                Email = request.Email,
                Code = request.Code
            });
        }

        public async Task Delete(string phone)
        {
            _mailRepository.Delete(phone);
        }

        public async Task<bool> VerifyCode(VerifyCodeRequest request)
        {
            return _mailRepository.VerifyCode(new VerifyCodeEntity
            {
                Code = request.Code,
                Email = request.Email
            });
        }
        public async Task<bool> SendCodeOnMail(SendCodeOnMailRequest request)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "recovery.code.miracle@gmail.com"));
            message.To.Add(new MailboxAddress("OniDem", request.Email));
            message.Subject = "Test";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<p>Привет, ваш код восстановления: " + request.Code + "</p>";
            message.Body = bodyBuilder.ToMessageBody();
            try
            {
                var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("recovery.code.miracle@gmail.com", "wnmt ylas bpyc kivo");
                client.Send(message);
                client.Disconnect(true);
                return true;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

                
        }
    }
}
