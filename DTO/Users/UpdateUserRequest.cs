using Core.Const;

namespace DTO.Users
{
    public class UpdateUserRequest
    {
        public string Phone { get; set; }

        public string FIO { get; set; }

        public UserRoleEnum Role { get; set; }

        public DepartmentEnum Department { get; set; }

        public StudentBranchEnum StudentBranch { get; set; }

        public string CourseNumber { get; set; }

        public string Password { get; set; }
    }
}
