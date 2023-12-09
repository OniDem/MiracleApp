namespace MiracleApp.Entity
{
    class StudentLessonEntity
    {
        public int Lesson_id { get; set; }

        public string Lesson_name { get; set; }

        public string Lesson_date { get; set; }

        public string Lesson_time { get; set; }

        public int Lesson_teacher_id { get; set; }

        public string Lesson_course {  get; set; }

        public bool Lesson_choised { get; set; }

    }
}
