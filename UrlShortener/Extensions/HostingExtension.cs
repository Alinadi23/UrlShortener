using Microsoft.EntityFrameworkCore;
using UrlShortener.BL.ShortUrls.ServiceContracts;
using UrlShortener.BL.ShortUrls.Sevices;
using UrlShortener.DAL.Data;
using UrlShortener.DAL.ShortUrls.Repositories;
using UrlShortener.DAL.ShortUrls.RepositoryContracts;

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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
            services.AddScoped<IShortUrlService, ShortUrlService>();

        }
    }
}
