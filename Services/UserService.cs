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
                Email = request.Email,
                FIO = request.FIO,
                Role = request.Role,
                Department = request.Department,
                StudentBranch = request.StudentBranch,
                CourseNumber = request.CourseNumber,
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

        public async Task<UserEntity?> Update(int user_id, UpdateUserRequest request)
        {
            return _userRepository.Update(new UserEntity
            {
                Id = user_id,
                Phone = request.Phone,
                Email = request.Email,
                FIO = request.FIO,
                Role = request.Role,
                Department = request.Department,
                StudentBranch = request.StudentBranch,
                CourseNumber = request.CourseNumber,
                Password = request.Password,
            });
        }

        public async Task<UserEntity?> ShowById(ShowByIdRequest request)
        {
            return _userRepository.ShowById(request.id);
        }
        public async Task<UserEntity?> ShowByPhone(ShowByPhoneRequest request)
        {
            return _userRepository.ShowByPhone(request.Phone);
        }
    }
}
