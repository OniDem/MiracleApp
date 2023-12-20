using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name:"lessons")]
    public class LessonEntity
    {
        [Key]
        public int Id { get; set; }

        public string Lesson_name { get; set; }

        public string Lesson_date { get; set; }

        public LessonDoWEnum LessonDoW { get; set; }

        public TimeOnly Lesson_time { get; set; }

        public int Lesson_teacher_id { get; set; }

        public string Lesson_course {  get; set; }

    }
}
