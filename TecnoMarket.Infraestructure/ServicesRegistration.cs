using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
            .AddEntityFrameworkStores<ApplicationContext>();

        services.ConfigureApplicationCookie(options =>
         {
             options.LoginPath = new PathString("/Session/Login");
             options.AccessDeniedPath = new PathString("/Session/Login");
         });

        services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 5;
        });

    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
    }
}

