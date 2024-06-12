using CoderMind.Application.Services.Implementations;
using CoderMind.Application.Services.Interfaces;
using CoderMind.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using CoderMind.Persistence;

namespace CoderMind.Application;

public static class DependencyInjections
{
    public static void AddApplicationService(this IServiceCollection services, Action<MongoOptions> options)
    {
        services.AddMongoContext(options);
        services.AddScoped<IUserService, UserService>();
    }
}
