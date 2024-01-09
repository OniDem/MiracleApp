using Core.Entity;
using DTO.Mail;

namespace Abstract.Services
{
    public interface IMailService
    {
        public Task<MailEntity> SendCode(AddMailRequest request);

        public Task<bool> Delete(string phone);

    }
}
