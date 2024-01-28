using MiracleApi.Controllers;

namespace MiracleTest
{
    public class LessonTests
    {
        LessonController controller;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateLessonShortTest()
        {
            Task.Run(async () =>
            {
                var lesson = await controller.Create(new() { Name = "test", Week = 3, TimeStart = "test", TimeEnd = "test", DayOfWeek = Core.Const.LessonDoWEnum.Mo, TeacherId = 1, Teacher = "test", CourseNumber = "test", Department = "test", Where = "test", Branch = "test", StudentCount = 0, Online = false });
                Assert.IsTrue(lesson.Id > 0);
            });
        }

        [Test]
        public void CreateLessonFullTest()
        {
            Task.Run(async () =>
            {
                var lesson = await controller.Create(new() { Name = "test", Week = 3, Date = "test", TimeStart = "test", TimeEnd = "test", DayOfWeek = Core.Const.LessonDoWEnum.Mo, TeacherId = 1, Teacher = "test", CourseNumber = "test", Department = "test", Where = "test", Branch = "test", StudentCount = 0, Online = false, Extra = "test" });
                Assert.IsTrue(lesson.Id > 0 && lesson.Date != null);
            });
        }


        [Test]
        public void UpdateLessonTest()
        {
            string updated_name = "foo";
            Task.Run(async () =>
            {
                var lesson = await controller.Update(1, new() { Name = updated_name, Week = 3, Date = "test", TimeStart = "test", TimeEnd = "test", DayOfWeek = Core.Const.LessonDoWEnum.Mo, TeacherId = 1, Teacher = "test", CourseNumber = "test", Department = "test", Where = "test", Branch = "test", StudentCount = 0, Online = false, Extra = "test" });
                Assert.IsTrue(lesson.Id == 1 && lesson.Name == updated_name);
            });
        }


        [Test]
        public void ShowAllLessonTest()
        {
            Task.Run(async () =>
            {
                var lessons = await controller.ShowAll();
                Assert.IsTrue(lessons.Count > 0);
            });
        }


        [Test]
        public void ShowByWeekLessonTest()
        {
            Task.Run(async () =>
            {
                var lessons = await controller.ShowByWeek(new() { Week = 1 });
                Assert.IsTrue(lessons.Count > 0);
            });
        }


        [Test]
        public void ShowByIdLessonTest()
        {
            Task.Run(async () =>
            {
                var lesson = await controller.ShowById(1);
                Assert.IsTrue(lesson != null && lesson.Id == 1);
            });
        }
    }
}
