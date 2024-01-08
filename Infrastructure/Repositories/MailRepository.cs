namespace Infrastructure.Repositories
{
    public class MailRepository
    {
        private ApplicationContext _applicationContext;

        public MailRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


    }
}
