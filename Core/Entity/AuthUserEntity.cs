namespace Core.Entity
{
    public class AuthUserEntity
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
    }
}
