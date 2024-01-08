using Abstract.Services;
using Core.Entity;

namespace Services
{
    public class MailService : IMailService
    {
        public async Task<MailEntity> SendCode(/*Здесь реквест*/)
        {
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            return false;
        }
    }
}
