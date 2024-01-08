using Core.Entity;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MiracleApp.Services.News
{
    public static class NewsServices
    {
        public static async Task<List<NewsEntity>> ShowAll()
        {
            string serverURI = "http://45.153.69.204:5000/News/ShowAll";
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
                return JsonConvert.DeserializeObject<List<NewsEntity>>(result);
            }
            return null;
        }
    }
}
