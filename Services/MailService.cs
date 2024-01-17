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
            bodyBuilder.HtmlBody = $"<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\">    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">    <title>Email Template</title></head><body style=\"text-align: center; background-color: #f4f4f4; font-family: Arial, sans-serif; color: #242323; font-size: 16px; line-height: 1.6; margin:0; padding:0\">    <h1 style=\"color: #242323; font-size: 96px; margin:0; padding:0\">Miracle</h1>    <p style=\"color: #242323; font-size: 32px; margin:0; padding:0\">Ваш код сброса пароля:</p>    <p style=\"color: #242323; font-size:0in ; margin:0; padding:0\">* * * * * * Здравствуйте, {request.Email}.        Недавно вы попытались сбросить пароль с учетной записи.        Если это были не вы, то проигнорируйте это сообщение.        Используйте данный код, чтобы завершить операцию.        С благодарностью,        Команда Miracle</p>    <table width=\"372px\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">        <tr>            <td align=\"center\">                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">                    {request.Code[0]}                </div>            </td>            <td align=\"center\">                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">                    {request.Code[2]}                </div>            </td>            <td align=\"center\">                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">                    {request.Code[3]}                </div>            </td>            <td align=\"center\">                <div style=\"width: 12px;\"></div>            </td>            <td align=\"center\">                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">                    {request.Code[4]}                </div>            </td>            <td align=\"center\">                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">        {request.Code[5]}         </div>            </td>            <td align=\"center\">                <div style=\"width: 50px; height: 60px; background-color: #242323; border-radius: 15px; margin: 10px; color: #fff; font-size: 24px; font-weight: bold; line-height: 60px;\">                    {request.Code[6]}                </div>            </td>        </tr>    </table>    <br>    <br>    <p style=\"color: #242323; font-size: 24px; text-align: left; max-width: 669px; margin: 0 auto; word-wrap: break-word;\" align=\"center\">Здравствуйте,{request.Email}.<br><br>    Недавно вы попытались сбросить пароль с учетной записи.    Если это были не вы, то проигнорируйте это сообщение.    Используйте данный код, чтобы завершить операцию.<br><br>    С благодарностью,<br>    Команда Miracle</p></body></html>";
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
