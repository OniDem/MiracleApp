using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "student_marks")]
    public class StudentMarkEntity
    {
        [Key]
        public int Id { get; set; }
        public int Mark { get; set; }

        public int Student_id { get; set; }

        public int Teacher_id { get; set; }

        public string Course { get; set; }
    }
}
