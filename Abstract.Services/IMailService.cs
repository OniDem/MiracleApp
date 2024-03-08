using DTO.Mail;

namespace Abstract.Services
{
    public interface IMailService
    {

        public Task<bool> VerifyCode(VerifyCodeRequest request);

        public Task<int> SendCodeOnMail(SendCodeOnMailRequest request);

    }
}
