using Microsoft.EntityFrameworkCore;
using PLM.Models.EF;

namespace PLM.Extensions.ServiceCollection;

public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddDatabaseServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<plmDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}