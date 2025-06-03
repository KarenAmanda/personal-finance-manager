
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Context;
using UserService.Infrastructure.Data.Repositories;

namespace UserService.Infrastructure.Dependencies;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UserDbContext>(options =>
                options.UseNpgsql(connectionString));


        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
