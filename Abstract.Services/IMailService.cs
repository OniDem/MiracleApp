using Core.Entity;

namespace Abstract.Services
{
    public interface IMailService
    {
        public Task<MailEntity> SendCode(/*Сюда реквест за отпраку кода*/);

        public Task<bool> Delete(int id);

    }
}
