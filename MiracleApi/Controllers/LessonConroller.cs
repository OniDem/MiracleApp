using Abstract.Services;
using Core.Entity;
using DTO.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                await _lessonService.Update(lesson_id, request);
            }
            return null;
        }

        [HttpPost, Authorize]
        public async Task Delete([FromBody] int lesson_id)
        {
            if (ModelState.IsValid)
            {
                await _lessonService.Delete(lesson_id);
            }
        }

        

        public class AuthOptions
        {
            public const string ISSUER = "MiracleApi"; // издатель токена
            public const string AUDIENCE = "SessionUser"; // потребитель токена
            const string KEY = "mira31MiracleApi";   // ключ для шифрации(16 символов)
            public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
