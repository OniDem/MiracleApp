using Core.Entity;

namespace Infrastructure.Repositories
{
    public class LessonRepository
    {
        private ApplicationContext _applicationContext;

        public LessonRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public LessonEntity Create(LessonEntity lesson)
        {
            _applicationContext.Lessons.Add(lesson);
            _applicationContext.SaveChanges();
            return lesson;
        }

        public LessonEntity Update(int lesson_id, LessonEntity entity)
        {
            var lesson = _applicationContext.Lessons.Where(p => p.Id == lesson_id).First();
            _applicationContext.Lessons.Update(lesson);
            _applicationContext.SaveChanges();
            return lesson;
        }


        public LessonEntity Delete(int lesson_id)
        {
            return _applicationContext.Lessons.Where(p => p.Id == lesson_id).First();

        }

        public LessonEntity ShowById(int id)
        {
            return _applicationContext.Lessons.Where(p => p.Id == id).First();
        }
    }
}
