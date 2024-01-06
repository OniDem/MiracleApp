using Core.Const;

namespace DTO.Users
{
    public class UpdateUserRequest
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public string FIO { get; set; }

        public UserRoleEnum Role { get; set; }

        public string Department { get; set; }

        public string StudentBranch { get; set; }

        public string CourseNumber { get; set; }

        public string Password { get; set; }
    }
}
