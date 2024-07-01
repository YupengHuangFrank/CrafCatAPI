using CrafCatApi.Api.Models;
using CrafCatAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrafCatAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailHttpService _emailHttpService;

        public EmailController(IEmailHttpService emailHttpService)
        {
            _emailHttpService = emailHttpService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromBody]EmailApi email)
        {
            var response = await _emailHttpService.SendEmailAsync(email.ReceiverEmail, email.Subject, email.EmailContent);

            return Ok(response);
        }
    }
}
