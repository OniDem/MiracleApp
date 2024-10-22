﻿using Core.Entity;
using DTO.Users;
using MiracleApp.Services;
using MiracleDesktopApp.Infrastructure;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace MiracleDesktopApp.Services
{
    public static class UserService
    {

        readonly static ApplicationContext db = new();

        private static string CreateRandomPhoto()
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(0, 100);
            List<int> array = new List<int>();
            int[] arrayLiky = new int[10]
            {1, 2, 3, 6, 9, 12, 15, 19, 23, 10 };
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < arrayLiky[i]; j++)
                    array.Add(arrayLiky[i]);
            string result = "";
            switch (array[randomNum])
            {
                case 1: result = "10"; break;
                case 2: result = "9"; break;
                case 3: result = "8"; break;
                case 6: result = "7"; break;
                case 9: result = "6"; break;
                case 12: result = "5"; break;
                case 15: result = "4"; break;
                case 19: result = "3"; break;
                case 23: result = "2"; break;
                case 10: result = "1"; break;
            }
            return result;
        }

        public static async Task<int> RegUserWithoutToken(CreateUserRequest request)
        {
            if (request.Role == 1)
            {
                request.CourseNumber = "";
                request.Department = "";
                request.Password = Convert.ToBase64String(await EncryptService.EncryptStringToByteArrayAsync(request.Password));
            }
            request.Photo = CreateRandomPhoto();
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/CreateWithoutToken", content);
            var result = await response.Content.ReadFromJsonAsync<UserEntity>();
            return result.Id;
        }

        public static async Task<bool> RegUserWithToken(CreateUserRequest request)
        {
            if (request.Role == 1)
            {
                request.CourseNumber = "";
                request.Department = "";
                request.Password = Convert.ToBase64String(await EncryptService.EncryptStringToByteArrayAsync(request.Password));
            }
            request.Photo = CreateRandomPhoto();
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/CreateWithToken", content);
            var user = JsonConvert.DeserializeObject<AuthUserEntity>(await response.Content.ReadAsStringAsync());
            //string debugString =
            //    "password send: " + request.Password + ";\n" +
            //    "number send: " + request.Phone + ";\n" +
            //    "number get: " + user.Phone + ";";
            if (user != null)
            {
                db.Database.EnsureCreated();
                if (db.Users.Find(user.Id) == null)
                {
                    db.Users.Add(new()
                    {
                        Id = user.Id,
                        Phone = user.Phone,
                        Email = user.Email,
                        FIO = user.FIO,
                        Role = user.Role,
                        Department = user.Department,
                        StudentBranch = user.StudentBranch,
                        CourseNumber = user.CourseNumber,
                        Token = user.Token
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public static async Task<bool> AuthUser(AuthUserRequest request)
        {
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/Auth", content);
            var user = JsonConvert.DeserializeObject<AuthUserEntity>(await response.Content.ReadAsStringAsync());
            string debugString =
                "password send: " + request.Password + ";\n" +
                "number send: " + request.Phone + ";\n" +
                "number get: " + user.Phone + ";";
            if (user != null)
            {
                db.Database.EnsureCreated();
                if (db.Users.Find(user.Id) == null)
                {
                    db.Users.Add(new()
                    {
                        Id = user.Id,
                        Phone = user.Phone,
                        Email = user.Email,
                        FIO = user.FIO,
                        Role = user.Role,
                        Department = user.Department,
                        StudentBranch = user.StudentBranch,
                        CourseNumber = user.CourseNumber,
                        Token = user.Token
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public static async Task<bool> LogOut()
        {
            try
            {
                db.Users.Remove(db.Users.First());
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static async Task<UserEntity> GetUserById(ShowByIdRequest request)
        {
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
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
