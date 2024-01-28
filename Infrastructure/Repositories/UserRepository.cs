using Core.Entity;
using DTO.Users;


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

        public UserEntity Update(int id, UpdateUserRequest request)
        {
            var user = _applicationContext.Users.Where(p => p.Id == id).First();
            user.Phone = request.Phone;
            user.Email = request.Email;
            user.FIO = request.FIO;
            user.Role = request.Role;
            user.Department = request.Department;
            user.StudentBranch = request.StudentBranch;
            user.CourseNumber = request.CourseNumber;
            user.Password = request.Password;
            user.Photo = request.Photo;
            _applicationContext.Users.Update(user);
            _applicationContext.SaveChanges();
            return user;
        }

        public UserEntity? ShowByPhone(string phone)
        {
            return _applicationContext.Users.Where(p => p.Phone == phone).First();
        }

        public UserEntity? ShowById(int id)
        {
            return _applicationContext.Users.Where(p => p.Id == id).First();
        }
    }
}
