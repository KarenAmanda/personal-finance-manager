
using UserService.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;

namespace Infrastructure.Dependencies;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
