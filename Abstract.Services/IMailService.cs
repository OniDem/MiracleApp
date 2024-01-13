using Core.Entity;
using DTO.Mail;

namespace Abstract.Services
{
    public interface IMailService
    {
        public Task<MailEntity> SendCode(SendCodeRequest request);

        public Task Delete(string phone);

        public Task<bool> VerifyCode(VerifyCodeRequest request);

        public Task<bool> SendCodeOnMail(SendCodeOnMailRequest request);

    }
}
