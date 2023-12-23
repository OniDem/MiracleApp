using Core.Const;
using Core.Entity;
using DTO.Users;
using System.Net.Http.Json;

namespace MiracleApp.Services.User
{
    public class UserService
    {
        public static async Task<int> RegUSer(CreateUserRequest entity)
        {
            if (entity.Role == UserRoleEnum.Teacher)
            {
                entity.CourseNumber = "";
                entity.Department = "";
            }
            JsonContent content = JsonContent.Create(entity);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/Create", content);
            var result = await response.Content.ReadFromJsonAsync<UserEntity>();
            return result.Id;
        }


    }
}
