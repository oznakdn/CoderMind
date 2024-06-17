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
        services.AddScoped<ITechnologyService, TechnologyService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IContentService, ContentService>();
    }
}
