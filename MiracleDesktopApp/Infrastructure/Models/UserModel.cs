namespace MiracleDesktopApp.Infrastructure.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FIO { get; set; }

        public int Role { get; set; }

        public string? Department { get; set; }

        public string? StudentBranch { get; set; }

        public string? CourseNumber { get; set; }

        public string? Token { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? PasswordChangeDate { get; set; }
    }
}
