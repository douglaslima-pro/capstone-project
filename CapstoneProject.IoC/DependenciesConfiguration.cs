using CapstoneProject.Business.Interfaces.Repositories;
using CapstoneProject.Business.Interfaces.Services;
using CapstoneProject.Business.Services;
using CapstoneProject.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CapstoneProject.IoC;

public static class DependenciesConfiguration
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
