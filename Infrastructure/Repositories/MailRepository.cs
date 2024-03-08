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
                _applicationContext.Mails.Add(mailEntity);
                _applicationContext.SaveChanges();
                return mailEntity;
        }

        public bool VerifyCode(VerifyCodeEntity VerifyCode)
        {
            var mailEntity = _applicationContext.Mails.Where(p => p.Email == VerifyCode.Email).OrderByDescending(p => p.ExpireDate).First();
            if (DateTime.Now.ToUniversalTime() < mailEntity.ExpireDate)
            {
                if (mailEntity.Code == VerifyCode.Code)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
