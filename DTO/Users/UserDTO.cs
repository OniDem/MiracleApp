using Core.Const;

namespace DTO.Users
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public UserRoleEnum Role { get; set; }

        public string Course { get; set; }

        public string Password { get; set; }
    }
}
