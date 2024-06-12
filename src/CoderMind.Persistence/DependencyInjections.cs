using CoderMind.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CoderMind.Persistence;

public static class DependencyInjections
{
    public static void AddMongoContext(this IServiceCollection services, Action<MongoOptions> options)
    {
        var mongoOptions = new MongoOptions();
        options(mongoOptions);
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOptions>>().Value);
    }
}
