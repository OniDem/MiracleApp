using Abstract.Services;
using Core.Entity;
using DTO.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO.Mail;

namespace MiracleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MailController : ControllerBase
    {
        private IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<MailEntity?> SendCode([FromBody] SendCodeRequest request)
        {
            if (ModelState.IsValid)
            {
                var mail = await _mailService.SendCode(request);
                return mail;
            }
            return null;
        }

        [HttpPost]
        public async Task Delete(string phone)
        {
            if (ModelState.IsValid)
            {
                await _mailService.Delete(phone);
            }
        }

    }
}
