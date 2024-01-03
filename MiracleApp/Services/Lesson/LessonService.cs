using Core.Entity;

namespace MiracleApp.Services.Lesson
{
    static class LessonService
    {
        public static StackLayout ShowLesson(LessonEntity lesson)
        {
            return new StackLayout
            {
                new Frame
                {
                    Margin = 5,
                    ZIndex = 0,
                    BackgroundColor = Color.FromArgb("#1E1E1E"),
                    BorderColor = Color.FromArgb("#1E1E1E"),
                    Content = new StackLayout
                    {
                    new Label
                    {
                        Text=$"{lesson.Name} {lesson.TimeStart} к.310 {lesson.Department} ",
                        TextColor = Color.FromArgb("#FAE073"),
                        FontSize = 20,
                        FontFamily="QANELASBLACK"
                    },

                    new Label
                    {
                        Text=$"Начало: {lesson.TimeStart}",
                        TextColor = Color.FromArgb("#FAE073"),
                        FontSize = 20,
                        FontFamily="QANELASBLACK"
                    },
                    new Label
                    {
                        Text=$"Конец: {lesson.TimeEnd}",
                        TextColor = Color.FromArgb("#FAE073"),
                        FontSize = 20,
                        FontFamily="QANELASBLACK"
                    },
                    new Label
                    {
                        Text=$"Где: {lesson.Department}",
                        TextColor = Color.FromArgb("#FAE073"),
                        FontSize = 20,
                        FontFamily="QANELASBLACK"
                    },
                    new Label
                    {
                        Text=$"Преподователь: {lesson.TeacherFIO}",
                        TextColor = Color.FromArgb("#FAE073"),
                        FontSize = 20,
                        FontFamily="QANELASBLACK"
                    }
                    }
                }
            };
        }
    }
}
