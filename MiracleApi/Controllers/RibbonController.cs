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
        /*
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
        public async Task<bool> UpdatePost(UpdatePostRequest request)
        {
            if(ModelState.IsValid)
                return await _ribbonService.UpdatePost(request);
            return false;
        }
        [HttpPost]
        public async Task<List<string>> ShowRibbon(int lastPostId)
        {
            if (ModelState.IsValid)
                return await _ribbonService.ShowRibbon(lastPostId);
            return null;
        }

        [HttpPost]
        public async Task<List<string>> ShowUserPost(int UserPost, int lastPostId)
        {
            if (ModelState.IsValid)
                return await _ribbonService.ShowUserPost(UserPost, lastPostId);
            return null;
        }

        [HttpPost]
        public async Task<bool> BlockPost(int postId)
        {
            if(ModelState.IsValid)
                return await _ribbonService.BlockPost(postId);
            return false;
        }
        [HttpPost]
        public async Task<bool> Like(int postId, bool status)
        {
            if (ModelState.IsValid)
                return await _ribbonService.Like(postId, status);
            return false;
        }
        [HttpPost]
        public async Task<bool> DisLike(int postId, bool status)
        {
            if (ModelState.IsValid)
                return await _ribbonService.DisLike(postId, status);
            return false;
        }
        [HttpPost]
        public async Task<bool> Complaint(int postId, bool status)
        {
            if (ModelState.IsValid)
                return await _ribbonService.Complaint(postId, status);
            return false;
        }
        [HttpPost]
        public async Task<bool> Comment(int postId, bool status)
        {
            if (ModelState.IsValid)
                return await _ribbonService.Comment(postId, status);
            return false;
        }
        [HttpPost]
        public async Task<bool> Download(int postId, bool status)
        {
            if (ModelState.IsValid)
                return await _ribbonService.Download(postId, status);
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
        */

    }
}
