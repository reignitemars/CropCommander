using CropCommander.Common.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CropCommander.Common;

public class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServices(IServiceCollection services)
    {
        services.AddScoped<IDataAccess, FieldDataAccess>();
        // Add other dependencies here
        return services;
    }
}