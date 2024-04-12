using Abstract.Services;
using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.Comments;
using DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiracleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommentController : ControllerBase
    {
        /*
        private ICommentsService _commentService;
        public CommentController(ICommentsService commentsService)
        {
            _commentService = commentsService;
        }
        [HttpPost]
        public async Task<bool> AddComments([FromBody] AddCommentsRequest request)
        {
            if(ModelState.IsValid)
            {
                var res = await _commentService.AddComment(request);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> UpdateComment([FromBody] UpdateCommentRequest request)
        {
            if(ModelState.IsValid)
            {
                var res = await _commentService.UpdateComment(request);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> BlockComment(int commentId)
        {
            if(ModelState.IsValid)
            {
                var res = await _commentService.BlockComment(commentId);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> DeleteComment(int commentId)
        {
            if(ModelState.IsValid)
            {
                var res = await _commentService.DeleteComment(commentId);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<List<string>> ShowComments(int lastCommentId, int postId)
        {
            if(ModelState.IsValid && lastCommentId > 0)
            {
                var res = await _commentService.ShowComments(lastCommentId, postId);
                return res;
            }
            return null;
        }
        [HttpPost]
        public async Task<bool> Like(int commentId, bool status)
        {
            if (ModelState.IsValid)
            {
                var res = await _commentService.Like(commentId, status);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> DisLike(int commentId, bool status)
        {
            if (ModelState.IsValid)
            {
                var res = await _commentService.DisLike(commentId, status);
                return res;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> Complaint(int commentId, bool status)
        {
            if (ModelState.IsValid)
            {
                var res = await _commentService.Complaint(commentId, status);
                return res;
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
        */
    }
}
