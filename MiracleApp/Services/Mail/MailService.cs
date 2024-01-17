using DTO.Mail;
using MiracleApp.Services.User;
using System.Net.Http.Json;

namespace MiracleApp.Services.Mail
{
    public static class MailService
    {
        public static async Task<bool> VerifiCode(string code)
        {

            return false;
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
            var response = await httpClient.PostAsync("http://45.153.69.204:5000/Mail/SendCode", content);
            return response.IsSuccessStatusCode;
        }
    }
}
