using Microsoft.Extensions.DependencyInjection;
using NewsLetter.Domain.Entities;

namespace NewsLetter.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly,typeof(Blog).Assembly);
        });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
