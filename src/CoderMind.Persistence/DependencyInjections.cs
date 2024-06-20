using CoderMind.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CoderMind.Persistence;

public static class DependencyInjections
{
    const string sqlServerConnection = "MsSQLConnection";
    public static void AddMongoPersistence(this IServiceCollection services, Action<MongoOptions> options)
    {
        services.AddSingleton<MongoOptions>(sp =>
        {
            var mongoOption = sp.GetRequiredService<IOptions<MongoOptions>>().Value;
            options.Invoke(mongoOption);
            return mongoOption;
        });
    }

    public static void AddEFCorePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EFContext>(opt => opt.UseSqlServer(configuration.GetConnectionString(sqlServerConnection)));
    }
}
