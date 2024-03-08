using Core.Entity;

namespace Infrastructure.Repositories
{
    public class MailRepository
    {
        private ApplicationContext _applicationContext;

        public MailRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public MailEntity? SendCode(MailEntity mailEntity)
        {
            var sendedMail = _applicationContext.Mails.Where(p => p.Email == mailEntity.Email).Last();
            if (sendedMail.ExpireDate > DateTime.Now)
            {
                _applicationContext.Mails.Add(mailEntity);
                _applicationContext.SaveChanges();
                return mailEntity;
            }
            else
                return null;
        }

        public bool VerifyCode(VerifyCodeEntity VerifyCode)
        {
            var mailEntity = _applicationContext.Mails.Where(p => p.Email == VerifyCode.Email).Last();
            if (mailEntity.Code == VerifyCode.Code && DateTime.Now < mailEntity.ExpireDate)
            {
                return true;
            }
            return false;
        }
    }
}
