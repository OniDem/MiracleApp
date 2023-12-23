using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name:"users")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Phone { get; set; }

        public string FIO { get; set; }

        public UserRoleEnum Role { get; set; }
        
        public string? Department { get; set; }

        public string? StudentBranch { get; set; }

        public string? CourseNumber { get; set; }

        public string Password { get; set; }

    }
}

