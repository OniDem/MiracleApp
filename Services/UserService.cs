using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.Users;
using Infrastructure.Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity?> Create(CreateUserRequest request)
        {
            return _userRepository.Create(new UserEntity
            {
                Phone = request.Phone,
                Role = request.Role,
                Course = request.Course,
                Password = request.Password,
            });
        }

        public async Task<UserEntity?> Auth(AuthUserRequest request)
        {
            var user = _userRepository.ShowByPhone(request.Phone);
            if (user.Password == request.Password)
                return user;
            return null;
        }
    }
}
