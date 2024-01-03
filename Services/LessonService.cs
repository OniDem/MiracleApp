﻿using Abstract.Services;
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
                Name = request.Name,
                Date = request.Date,
                DayOfWeek = request.DayOfWeek,
                //Time = request.Time,                    Edit!
                TeacherId = request.TeacherId,
                CourseNumber = request.Course,
                Department = request.Department,
                StudentCount = request.StudentCount,
                Online = request.Online,
            });
        }

        public async Task<LessonEntity?> Update(int lesson_id, UpdateLessonRequest request)
        {
            return _lessonRepository.Update(new LessonEntity
            {
                Id = lesson_id,
                Name = request.Name,
                Date = request.Date,
                DayOfWeek = request.DayOfWeek,
                //Time = request.Time,                    Edit!
                TeacherId = request.TeacherId,
                CourseNumber = request.Course,
                Department = request.Department,
                StudentCount = request.StudentCount,
                Online = request.Online,
            });
        }

        public async Task<List<LessonEntity>?> ShowAll()
        {
            return _lessonRepository.ShowAll();
        }

        public async Task<LessonEntity?> ShowById(int lesson_id)
        {
            return _lessonRepository.ShowById(lesson_id);
        }

        public async Task Delete(int lesson_id)
        {
            _lessonRepository.Delete(lesson_id);
        }
    }
}
