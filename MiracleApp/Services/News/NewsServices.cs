using Core.Entity;
using DTO.News;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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

        public static async Task<List<NewsEntity>> NewsConvertForShow()
        {
            var news = await ShowAll();
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
        }
    }
}
