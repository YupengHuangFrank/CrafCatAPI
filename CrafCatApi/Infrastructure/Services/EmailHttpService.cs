using CrafCatAPI.Infrastructure.Clients;
namespace CrafCatAPI.Infrastructure.Services
{
    public interface IEmailHttpService
    {
        Task<HttpResponseMessage> SendEmailAsync(string receiverEmail, string subject, string emailContent);
    }

    public class EmailHttpService : IEmailHttpService
    {
        private readonly IEmailHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public EmailHttpService(IEmailHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> SendEmailAsync(string receiverEmail, string subject, string emailContent)
        {
            var content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string> ("from", _configuration["MailGun:From"] ?? ""),
                new KeyValuePair<string, string> ("to", receiverEmail),
                new KeyValuePair<string, string> ("subject", subject),
                new KeyValuePair<string, string> ("text", emailContent)
            ]);

            return await _httpClient.PostAsync($"{_configuration["MailGun:Domain"]}/messages", content);
        }
    }
}
