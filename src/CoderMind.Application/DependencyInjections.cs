using CoderMind.Application.Services.Implementations;
using CoderMind.Application.Services.Interfaces;
using CoderMind.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using CoderMind.Persistence;
using Microsoft.Extensions.Configuration;
using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Application.Services.EFCoreServices.Implementations;

namespace CoderMind.Application;

public static class DependencyInjections
{
    public static void AddApplicationMongoService(this IServiceCollection services, Action<MongoOptions> options)
    {
        services.AddMongoPersistence(options);
        services.AddScoped<ITechnologyService, TechnologyService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IContentService, ContentService>();
    }

    public static void AddApplicationEfService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEFCorePersistence(configuration);
        services.AddScoped<IEfTechnologyService, EfTechnologyService>();
        services.AddScoped<IEfSubjectService, EfSubjectService>();
        services.AddScoped<IEfContentService, EfContentService>();
    }
}
