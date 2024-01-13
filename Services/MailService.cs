using Abstract.Services;
using Core.Entity;
using DTO.Mail;
using Infrastructure.Repositories;

namespace Services
{
    public class MailService : IMailService
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
    }
}
