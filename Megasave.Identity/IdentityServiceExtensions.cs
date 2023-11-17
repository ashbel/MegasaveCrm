using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Megasave.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataConnection") ?? throw new InvalidOperationException("Connection string not found.");
            services.AddDbContext<MopaneIdentityDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 7, 41))));
        }
    }
}