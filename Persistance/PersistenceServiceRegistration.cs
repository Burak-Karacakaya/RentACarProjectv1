using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistance;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(optiıns => optiıns.UseInMemoryDatabase("nArchitecture"));

        services.AddDbContext<BaseDbContext>(
            optiıns => optiıns.UseNpgsql(Configuration.ConnectionString));

        services.AddScoped<IModelRepository,ModelRepository>();
        services.AddScoped<IBrandRepository,BrandRepository>();

        return services;
    }
}