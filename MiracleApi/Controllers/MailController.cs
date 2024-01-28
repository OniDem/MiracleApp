using Abstract.Services;
using DTO.Mail;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<bool> VerifyCode([FromBody] VerifyCodeRequest request)
        {
            if (ModelState.IsValid)
            {
                var answer = await _mailService.VerifyCode(request);
                return answer;
            }
            return false;
        }

        [HttpPost]
        public async Task<int> SendCodeOnMail([FromBody] SendCodeOnMailRequest request)
        {
            if (ModelState.IsValid)
            {
                var answer = await _mailService.SendCodeOnMail(request);
                return answer;
            }
            return 0;
        }

        [HttpPost]
        public async Task Delete(DeleteMailRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mailService.Delete(request.Email);
            }
        }
    }
}
