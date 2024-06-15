using CoderMind.Application.Services.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.SubjectDtos;

namespace CoderMind.Application.Services.Implementations;

public class SubjectService : MongoContext<Subject>, ISubjectService
{
    public SubjectService(MongoOptions options) : base(options)
    {
    }

    public async Task CreateSubjectAsync(CreateSubjectDto createSubject, CancellationToken cancellationToken = default)
    {
        var subject = Subject.CreateSubject(createSubject.TechnologyId, createSubject.Title, createSubject.Tags!.Trim().Split(','));
        await Collection.InsertOneAsync(subject, cancellationToken: cancellationToken);
    }
}
