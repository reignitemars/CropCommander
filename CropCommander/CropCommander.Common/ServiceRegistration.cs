using CropCommander.Common.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CropCommander.Common;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddLibraryServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IDataAccess, FieldDataAccess>();
    }
}