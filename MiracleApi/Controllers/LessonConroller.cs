using Abstract.Services;
using Core.Entity;
using DTO.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiracleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LessonController : ControllerBase
    {

        private ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost, Authorize]
        public async Task<LessonEntity?> Create([FromBody] CreateLessonRequest request)
        {
            if (ModelState.IsValid)
            {
                var lesson = await _lessonService.Create(request);
                return lesson;
            }
            return null;
        }

        [HttpPut, Authorize]
        public async Task<LessonEntity?> Update(int lesson_id, UpdateLessonRequest request)
        {
            if (ModelState.IsValid)
            {
                var lesson = await _lessonService.Update(lesson_id, request);
                return lesson;
            }
            return null;
        }

        [HttpPost, Authorize]
        public async Task<List<LessonEntity>?> ShowAll()
        {
            if (ModelState.IsValid)
            {
                return await _lessonService.ShowAll();
            }
            return null;
        }

        [HttpPost, Authorize]
        public async Task<LessonEntity?> ShowById(int lesson_id)
        {
            if (ModelState.IsValid)
            {
                return await _lessonService.ShowById(lesson_id);
            }
            return null;
        }

        [HttpDelete, Authorize]
        public async Task Delete(int lesson_id)
        {
            if (ModelState.IsValid)
            {
                await _lessonService.Delete(lesson_id);
            }
        }
    }
}
