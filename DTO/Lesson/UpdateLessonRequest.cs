using Core.Const;

namespace DTO.Lesson
{
    public class UpdateLessonRequest
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public LessonDoWEnum DayOfWeek { get; set; }

        public TimeOnly Time { get; set; }

        public int TeacherId { get; set; }

        public string Course { get; set; }

        public DepartmentEnum Department { get; set; }

        public int StudentCount { get; set; }

        public bool Online { get; set; }
    }
}
