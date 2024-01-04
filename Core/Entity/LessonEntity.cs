using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "lessons")]
    public class LessonEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string TimeStart { get; set; }

        public string TimeEnd { get; set; }

        public LessonDoWEnum DayOfWeek { get; set; }

        public int TeacherId { get; set; }

        public string Teacher { get; set; }

        public string CourseNumber { get; set; }

        public string Department { get; set; }

        public string Where { get; set; }

        public string Branch { get; set; }

        public int StudentCount { get; set; }

        public bool Online { get; set; }

        public string Extra { get; set; }

    }
}
