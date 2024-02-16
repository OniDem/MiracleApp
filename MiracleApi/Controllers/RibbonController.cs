using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiracleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RibbonController: ControllerBase
    {
        private IRibbonService _ribbonService;
        public RibbonController(IRibbonService ribbonService)
        {
            _ribbonService = ribbonService;
        }

        [HttpPost]
        public async Task<bool> AddPost([FromBody] AddPostRequest request)
        {
            if (ModelState.IsValid)
            {
                var res = await _ribbonService.AddPost(request);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<int?> UpdateCounter( int postId, bool status, string parametr)
        {
            if (ModelState.IsValid)
            {
                return await _ribbonService.UpdateCounter(postId, status, parametr);
            }
            return null;
        }
        [HttpPost]
        public async Task<bool> UpdatePost(UpdatePostRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _ribbonService.UpdatePost(request);
            }
            return false;
        }
        [HttpPost]
        public async Task<List<string>> ShowRibbon(int lastPostId)
        {
            if (ModelState.IsValid)
            {
                return await _ribbonService.ShowRibbon(lastPostId);
            }
            return null;
        }
        [HttpPost]
        public async Task<bool> BlockPost(int postId)
        {
            if(ModelState.IsValid)
            {
                return await _ribbonService.BlockPost(postId);
            }
            return false;
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
