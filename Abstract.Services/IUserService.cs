using Core.Entity;
using DTO.Users;

namespace Abstract.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserEntity?> Create(CreateUserRequest request);

        public Task<UserEntity?> Auth(AuthUserRequest request);

        public Task<UserEntity?> Update(int user_id, UpdateUserRequest request);

        public Task<UserEntity?> ShowById(ShowByIdRequest request);
    }
}
