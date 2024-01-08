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

        public LessonEntity Update(LessonEntity entity)
        {

            _applicationContext.Lessons.Update(entity);
            _applicationContext.SaveChanges();
            return entity;
        }
        public LessonEntity ShowById(int lesson_id)
        {
            return _applicationContext.Lessons.Where(p => p.Id == lesson_id).First();
        }

        public List<LessonEntity> ShowAll()
        {
            return _applicationContext.Lessons.ToList();
        }

        public List<LessonEntity> ShowByWeek(int week)
        {
            return _applicationContext.Lessons.Where(p => p.Week == week).ToList();
        }

        public void Delete(int lesson_id)
        {
            _applicationContext.Remove(ShowById(lesson_id));
            _applicationContext.SaveChanges();
        }
    }
}
