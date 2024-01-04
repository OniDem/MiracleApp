using Core.Entity;
using Newtonsoft.Json;

namespace MiracleApp.Services.Lesson
{
    static class LessonService
    {
        public static async Task<List<LessonEntity>> ShowAll()
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/ShowAll";
            HttpClient client = new HttpClient();
            Dictionary<string, string> Params = new()
            {

            };
            FormUrlEncodedContent content = new(Params);
            HttpResponseMessage response = await client.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LessonEntity>>(result);
            }
            return null;
        }
    }
}
