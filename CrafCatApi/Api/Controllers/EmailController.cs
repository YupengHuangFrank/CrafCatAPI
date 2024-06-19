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
        public async Task<IActionResult> SendEmailAsync(string receiverEmail, string subject, string emailContent)
        {
            var response = await _emailHttpService.SendEmailAsync(receiverEmail, subject, emailContent);

            return Ok(response);
        }
    }
}
