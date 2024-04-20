using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsLetter.Domain.Entities;
using NewsLetter.Domain.Repositories;
using NewsLetter.Infrastructure.Context;
using NewsLetter.Infrastructure.Repositories;
using Scrutor;

namespace NewsLetter.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            //options.UseInMemoryDatabase(configuration.GetConnectionString("InMemory") ?? "");
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ISubscribeRepository, SubscribeRepository>();

        //services.Scan(action =>
        //    action
        //    .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
        //    .AddClasses(publicOnly:false)
        //    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        //    .AsImplementedInterfaces()
        //    .WithScopedLifetime()
        //);

        return services;
    }
}
