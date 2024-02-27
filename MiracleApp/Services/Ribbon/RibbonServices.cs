using CommunityToolkit.Maui.Alerts;
using Core.Entity;
using DTO.News;
using MiracleApp.Entity;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MiracleApp.Services.News
{
    public static class RibbonServices
    {
        private static async Task<List<PostWithPictureEntity>> ShowRibbon(int lastPost)
        {
            try
            {
                string serverURI = "http://45.153.69.204:5000/Ribbon/ShowRibbon";
                List<string> resList= new List<string>();
                List<PostWithPictureEntity> postList = new List<PostWithPictureEntity>();
                HttpClient httpClient = new HttpClient();
                JsonContent content = JsonContent.Create(lastPost);
                var response = await httpClient.PostAsync(serverURI, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    resList = JsonConvert.DeserializeObject<List<string>>(result);
                    foreach (var post in resList)
                        postList.Add(JsonConvert.DeserializeObject<PostWithPictureEntity>(post));
                    return postList;
                };
            }catch (Exception ex)
            {
                var toast = Toast.Make(ex.Message, CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
            return null;
            
        }

       
    }
}
