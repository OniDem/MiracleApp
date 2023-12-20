using Core.Entity;
using DTO.Lesson;

namespace Abstract.Services
{
    public interface ILessonService
    {
        public Task<LessonEntity?> Create(CreateLessonRequest lessonRequest);

        public Task<LessonEntity?> Update(int lesson_id, UpdateLessonRequest request);

        public Task<List<LessonEntity>?> ShowAll();

        public Task<LessonEntity?> ShowById(int lesson_id);

        public Task Delete(int lesson_id);
    }
}
