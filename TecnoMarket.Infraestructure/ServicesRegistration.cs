using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TecnoMarket.Core.Entities.SecurityEntities;
using TecnoMarket.Core.Interfaces;
using TecnoMarket.Infraestructure.Data;
using TecnoMarket.Infraestructure.Repositories;

public static class ServicesRegistration
{
    public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
        });
    }

    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}

