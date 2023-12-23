using Core.Const;

namespace DTO.Users
{
    public class CreateUserRequest
    {
        public string Phone { get; set; }

        public string FIO { get; set; }

        public UserRoleEnum Role { get; set; }

        public string Department { get; set; }

        public string StudentBranch { get; set; }

        //Добавить ветки для преподов(enum)

        public string CourseNumber { get; set; }

        public string Password { get; set; }
    }
}
