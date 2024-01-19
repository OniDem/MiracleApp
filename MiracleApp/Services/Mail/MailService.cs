using DTO.Mail;
using MiracleApp.Services.User;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MiracleApp.Services.Mail
{
    public static class MailService
    {
        public static async Task<bool> VerifiCode(string phone, string code)
        {
            var user = await UserService.GetUserByPhone(new() { Phone = phone });
            VerifyCodeRequest request = new()
            {
                Email = user.Email,
                Code = code
            };
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/Mail/VerifyCode", content);
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        public static async Task<bool> SendCode(string phone)
        {
            var user = await UserService.GetUserByPhone(new() { Phone = phone });
            SendCodeRequest request = new()
            {
                Email = user.Email
            };
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/Mail/SendCodeOnMail", content);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> Delete(string phone)
        {
            var user = await UserService.GetUserByPhone(new() { Phone = phone });
            DeleteMailRequest request = new()
            {
                Email = user.Email
            };
            JsonContent content = JsonContent.Create(request);
            HttpClient httpClient = new();
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/Mail/Delete", content);
            return response.IsSuccessStatusCode;
        }
    }
}
