﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserService.Application.Dependencies;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

        return services;
    }
}
