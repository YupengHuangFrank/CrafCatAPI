using System.Net.Http.Headers;

namespace CrafCatAPI.Infrastructure.Clients
{
    public interface IEmailHttpClient
    {
        Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content);
    }

    public class EmailHttpClient : IEmailHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _userName = "api";
        private readonly string _password = "11e427683f4252c7891172c221e477ee-6fafb9bf-4fc32a2f";

        public EmailHttpClient(IConfiguration configuration) 
        {
            _configuration = configuration;
            _userName = _configuration["Mailgun:UserName"] ?? "";
            _password = _configuration["Mailgun:Password"] ?? "";

            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2) // Recreate every 15 minutes
            };

            _httpClient = new(handler)
            { 
                BaseAddress = new Uri(_configuration["Mailgun:BaseAddress"] ?? ""),
            };
            var authenticationString = $"{_userName}:{_password}";
            var base64String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authenticationString));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
        }

        public async Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content)
        {
            return await _httpClient.PostAsync(requestUri, content);
        }
    }
}
