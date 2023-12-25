using Core.Const;
using Core.Entity;
using DTO.Users;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MiracleApp.Services.User
{
    public class UserService
    {
        public static async Task<int> RegUser(CreateUserRequest request)
        {
            if (request.Role == UserRoleEnum.Teacher)
            {
                request.CourseNumber = "";
                request.Department = "";
            }
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/Create", content);
            var result = await response.Content.ReadFromJsonAsync<UserEntity>();
            return result.Id;
        }

        public static async Task<bool> AuthUser(AuthUserRequest request)
        {
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/Auth", content);
            var result = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            if (token != null)
            {
                var user_token = token.First();
                await SecureStorage.SetAsync("id", user_token.Key);
                await SecureStorage.SetAsync("token", user_token.Value);
                return true;
            }
            return false;
        }
    }
}
