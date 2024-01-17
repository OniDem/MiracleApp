using Core.Entity;
using DTO.Mail;
using Infrastructure.Repositories;
using MimeKit;
using MailKit.Net.Smtp;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;


namespace Services
{
    public class MailService : Abstract.Services.IMailService
    {
        private MailRepository _mailRepository;
        public MailService(MailRepository mailRepository)
        {
            _mailRepository = mailRepository;
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
        public async Task<int> SendCodeOnMail(SendCodeOnMailRequest request)
        {
            Random rnd = new();
            var Code = rnd.Next(100000, 999999).ToString();
            var mail = _mailRepository.SendCode(new MailEntity
            {
                Email = request.Email,
                Code = Code
            });
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ваш код для сброса пароля", "recovery.code.miracle@gmail.com"));
            message.To.Add(new MailboxAddress("OniDem", request.Email));
            message.Subject = "Ваша Мира";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Email Template</title>\r\n</head>\r\n<body style=\"text-align: center; background-color: #f4f4f4; font-family: Arial, sans-serif; color: #242323; font-size: 16px; line-height: 1.6;\">\r\n\r\n    <h1 style=\"color: #242323; font-size: 96px;\">Miracle</h1>\r\n\r\n    <p style=\"color: #242323; font-size: 32px;\">Ваш код сброса пароля:</p>\r\n\r\n<p style=\"color: #242323; font-size: 24px; text-align: left; max-width: 669px; margin: 0 auto; word-wrap: break-word;\" align=\"center\">Здравствуйте, {request.Email}.<br><br>\r\n\r\n    <table width=\"372px\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">\r\n        <tr>\r\n            <td align=\"center\">\r\n                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">{Code[0]}<span style=\"color: #f4f4f4;\">&zwnj;</span></div>\r\n            </td>\r\n            <td align=\"center\">\r\n                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">{Code[1]}<span style=\"color: #f4f4f4;\">&zwnj;</span></div>\r\n            </td>\r\n            <td align=\"center\">\r\n                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">{Code[2]}<span style=\"color: #f4f4f4;\">&zwnj;</span></div>\r\n            </td>\r\n            <td align=\"center\">\r\n                <div style=\"width: 12px;\"></div>\r\n            </td>\r\n            <td align=\"center\">\r\n                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">{Code[3]}<span style=\"color: #f4f4f4;\">&zwnj;</span></div>\r\n            </td>\r\n            <td align=\"center\">\r\n                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">{Code[4]}<span style=\"color: #f4f4f4;\">&zwnj;</span></div>\r\n            </td>\r\n            <td align=\"center\">\r\n                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">{Code[5]}<span style=\"color: #f4f4f4;\">&zwnj;</span></div>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n\r\n    <p>\r\n    Недавно вы попытались сбросить пароль с учетной записи.\r\n    Если это были не вы, то проигнорируйте это сообщение.\r\n    Используйте данный код, чтобы завершить операцию.<br><br>\r\n    С благодарностью,<br>\r\n    Команда Miracle</p>\r\n\r\n</body>\r\n</html>\r\n";
            message.Body = bodyBuilder.ToMessageBody();
            try
            {
                var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("recovery.code.miracle@gmail.com", "wnmt ylas bpyc kivo");
                client.Send(message);
                client.Disconnect(true);
                return mail.Id;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

                
        }
    }
}
