using Core.Entity;
using System.Net.Mail;

namespace Infrastructure.Repositories
{
    public class MailRepository
    {
        private ApplicationContext _applicationContext;

        public MailRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public MailEntity SendCode(MailEntity mailEntity)
        {
            _applicationContext.Mails.Add(mailEntity);
            _applicationContext.SaveChanges();
            return mailEntity;
        }
        public bool Delete(string phone)
        {
            var mailEntity = _applicationContext.Mails.Where(p => p.Phone == phone).First();
            _applicationContext.Mails.Remove(mailEntity);
            _applicationContext.SaveChanges(true);
            return true;
        }
        public bool VerifyCode(VerifyCodeEntity VerifyCode)
        {
            var mailEntity = _applicationContext.Mails.Where(p => p.Email == VerifyCode.Email).FirstOrDefault();
            if (mailEntity == null)
            {
                return false;
            }
            return true;
        }
    }
}
