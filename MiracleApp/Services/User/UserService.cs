using Core.Const;
using Core.Entity;
using DTO.Users;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MiracleApp.Services.User
{
    public class UserService
    {
        public static async Task<int> RegUser(CreateUserRequest request)
        {
            if (request.Role == UserRoleEnum.Преподователь)
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
            var token = JsonConvert.DeserializeObject<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
            if (token != null)
            {
                var user_token = token.First();
                await SecureStorage.SetAsync("id", user_token.Key);
                await SecureStorage.SetAsync("phone", request.Phone);
                await SecureStorage.SetAsync("token", user_token.Value);
                return true;
            }
            return false;
        }

        public static async Task<UserEntity> GetUserById(ShowByIdRequest request)
        {
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/ShowById", content);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserEntity>(result);
        }

        public static async Task<bool> UpdateUser(int id, UpdateUserRequest request)
        {
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsync($"http://45.153.69.204:5000/User/Update?user_id={id}", content);
           
            return response.IsSuccessStatusCode;
        }

        public static async Task<UserEntity> GetUserByPhone(ShowByPhoneRequest request)
        {
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/ShowByPhone", content);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserEntity>(result);
        }   
    }
}
