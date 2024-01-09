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
        public async Task<MailEntity> SendCode(AddMailRequest request)
        {
            _mailRepository.MailAdd(new MailEntity
            {
                Phone = request.Phone,
                Email = request.Email,
                Code = request.Code
            });
            return null;
        }

        public async Task<bool> Delete(string phone)
        {
            _mailRepository.MailDelete(phone);
            return false;
        }
    }
}
