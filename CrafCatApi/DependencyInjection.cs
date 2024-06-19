using CrafCatAPI.Infrastructure.Clients;
using CrafCatAPI.Infrastructure.Services;
using System.Diagnostics.CodeAnalysis;

namespace CrafCatAPI
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IEmailHttpClient, EmailHttpClient>();
            services.AddSingleton<IEmailHttpService, EmailHttpService>();
        }
    }
}
