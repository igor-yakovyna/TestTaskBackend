using Microsoft.Extensions.DependencyInjection;
using Project.Application.Contracts.Persistence;
using Project.Infrastructure.Repositories;

namespace Project.Infrastructure.Configuration;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}