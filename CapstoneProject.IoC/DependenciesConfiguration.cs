using CapstoneProject.Business.Interfaces.Repositories;
using CapstoneProject.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CapstoneProject.IoC;

public static class DependenciesConfiguration
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
