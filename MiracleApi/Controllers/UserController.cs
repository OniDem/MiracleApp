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
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<UserEntity?> Create([FromBody] CreateUserRequest userCreate)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Create(userCreate);
                return user;
            }
            return null;
        }

        [HttpPost]
        public async Task<AuthUserEntity?> Auth([FromBody] AuthUserRequest userAuth)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Auth(userAuth);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Id.ToString()) };
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                         issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                Response.Cookies.Append(user.Id.ToString(), new JwtSecurityTokenHandler().WriteToken(jwt));
                user.Token = new JwtSecurityTokenHandler().WriteToken(jwt);
                return user;
            }
            return null;
        }

        [HttpPut]
        public async Task<UserEntity?> Update(int user_id, UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(user_id, request);
            }
            return null;
        }

        [HttpPost, Authorize]
        public async Task<UserEntity?> ShowById(ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _userService.ShowById(request);
            }
            return null;
        }
        [HttpPost]
        public async Task<UserEntity?> ShowByPhone(ShowByPhoneRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _userService.ShowByPhone(request);
            }
            return null;
        }

        [HttpDelete, Authorize]
        public async Task LogOut([FromBody] int user_id)
        {
            Response.Cookies.Delete(user_id.ToString());
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
