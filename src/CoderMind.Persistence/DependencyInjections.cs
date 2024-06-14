using CoderMind.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CoderMind.Persistence;

public static class DependencyInjections
{
    public static void AddMongoContext(this IServiceCollection services, Action<MongoOptions> options)
    {
        services.AddSingleton<MongoOptions>(sp =>
        {
            options.Invoke(sp.GetRequiredService<IOptions<MongoOptions>>().Value);
            return sp.GetRequiredService<IOptions<MongoOptions>>().Value;
        });
    }
}
