using Core.Entity;
using DTO.News;
using MiracleApp.Entity;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MiracleApp.Services.News
{
    public static class NewsServices
    {
        private static async Task<List<NewsEntity>> GetAll()
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

        public static async Task<int> CreateNews(CreateNewsRequest request)
        {
            string serverURI = "http://45.153.69.204:5000/News/Create";
            NewsEntity result = new();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            JsonContent content = JsonContent.Create(request);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<NewsEntity>(await response.Content.ReadAsStringAsync());
            }
            return result.Id;
        }

        public static async Task<List<ShowNewsEntity>> ShowAll()
        {
            List<ShowNewsEntity> showList = new();
            var news = await GetAll();
            ImageSourceConverter conv = new();
            foreach (var e in news)
            {
                showList.Add(new()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Image = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(e.Image))),
                    Content = e.Content
                });
            }
            showList.Reverse();
            return showList;
        }
    }
}
