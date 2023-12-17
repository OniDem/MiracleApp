using Core.Const;

namespace DTO.Lesson
{
    public class CreateLessonRequest
    {
        public string Lesson_name { get; set; }

        public string Lesson_date { get; set; }

        public LessonDoWEnum LessonDoW { get; set; }

        public TimeOnly Lesson_time { get; set; }

        public int Lesson_teacher_id { get; set; }

        public string Lesson_course { get; set; }
    }
}
