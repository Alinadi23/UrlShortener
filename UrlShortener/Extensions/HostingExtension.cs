using Microsoft.EntityFrameworkCore;
using UrlShortener.DAL.Data;

namespace UrlShortener.UI.Extensions
{
    public static class HostingExtensions
    {
        private static IConfiguration _configuration { get; set; }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;

            var cnn = _configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationDbContext>(c => c.UseInMemoryDatabase(cnn));
            services.AddLogging(config => config.AddConfiguration(_configuration.GetSection("Logging")).AddConsole());

        }
    }
}
