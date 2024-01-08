using Core.Entity;
using DTO.Lesson;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MiracleApp.Services.Lesson
{
    static class LessonService
    {
        public static async Task<bool> CreateLesson(CreateLessonRequest request)
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/ShowAll";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            JsonContent content = JsonContent.Create(request);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<LessonEntity>> ShowAll()
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/ShowAll";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            Dictionary<string, string> Params = new()
            {

            };
            FormUrlEncodedContent content = new(Params);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LessonEntity>>(result);
            }
            return null;
        }

        public static async Task<List<LessonEntity>> ShowByWeek(ShowByWeekRequest request)
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/ShowByWeek";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            JsonContent content = JsonContent.Create(request);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LessonEntity>>(result);
            }
            return null;
        }
    }
}
