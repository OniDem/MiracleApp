using Core.Entity;

namespace Infrastructure.Repositories
{
    public class UserRepository
    {
        private ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public UserEntity Create(UserEntity user)
        {
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
            return user;
        }

        public UserEntity? ShowByPhone(string phone)
        {
            return _applicationContext.Users.Where(p => p.Phone == phone).First();
            
        }
    }
}
