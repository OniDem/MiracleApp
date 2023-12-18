using Abstract.Services;
using Core.Entity;
using DTO.Lesson;
using Infrastructure.Repositories;

namespace Services
{
    public class LessonService : ILessonService
    {
        private LessonRepository _lessonRepository;

        public LessonService(LessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonEntity?> Create(CreateLessonRequest request)
        {
            return _lessonRepository.Create(new LessonEntity
            {
                Lesson_name = request.Lesson_name,
                Lesson_date = request.Lesson_date,
                LessonDoW = request.LessonDoW,
                Lesson_time = request.Lesson_time,
                Lesson_teacher_id = request.Lesson_teacher_id,
                Lesson_course = request.Lesson_course
            });
        }

        public async Task<LessonEntity?> Update(int lesson_id, UpdateLessonRequest request)
        {
            return _lessonRepository.Update(new LessonEntity
            {
                Id = lesson_id,
                Lesson_name = request.Lesson_name,
                Lesson_date = request.Lesson_date,
                LessonDoW = request.LessonDoW,
                Lesson_time = request.Lesson_time,
                Lesson_teacher_id = request.Lesson_teacher_id,
                Lesson_course = request.Lesson_course
            });
        }

        public async Task Delete(int lesson_id)
        {
            _lessonRepository.Delete(lesson_id);
        }
    }
}
