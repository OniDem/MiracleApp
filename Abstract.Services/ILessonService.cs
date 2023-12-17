using Core.Entity;
using DTO.Lesson;

namespace Abstract.Services
{
    public interface ILessonService
    {
        public Task<LessonEntity?> Create(CreateLessonRequest lessonRequest);

        public Task<LessonEntity?> Update(int lesson_id, UpdateLessonRequest request);

        public Task Delete(int lesson_id);
    }
}
