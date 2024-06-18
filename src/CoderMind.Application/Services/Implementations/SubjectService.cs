using CoderMind.Application.Services.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.SubjectDtos;
using MongoDB.Driver;

namespace CoderMind.Application.Services.Implementations;

public class SubjectService : MongoContext<Subject>, ISubjectService
{
    public SubjectService(MongoOptions options) : base(options)
    {
    }

    public async Task CreateSubjectAsync(CreateSubjectDto createSubject, CancellationToken cancellationToken = default)
    {
        var subject = Subject.CreateSubject(createSubject.TechnologyId, createSubject.Title, createSubject.Tags is null ? null : createSubject.Tags!.Trim().Split(','));
        await Collection.InsertOneAsync(subject, cancellationToken: cancellationToken);
    }

    public async Task DeleteSubjectAsync(string id, CancellationToken cancellationToken = default)
    {
        var filter = new FilterDefinitionBuilder<Subject>().Eq(x => x.Id, id);
        await Collection.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<GetSubjectDto> GetSubjectAsync(string id, CancellationToken cancellationToken = default)
    {
        var subject = await Collection
            .Find(x => x.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
        return new GetSubjectDto(subject.Id, subject.Title, subject.Tags, subject.CreatedDate.ToString());
    }

    public async Task UpdateSubjectAsync(UpdateSubjectDto updateSubject, CancellationToken cancellationToken = default)
    {
        var filterDefinition = new FilterDefinitionBuilder<Subject>().Eq(x => x.Id, updateSubject.Id);
        var updateDefinition = new UpdateDefinitionBuilder<Subject>()
            .Set(x => x.Title, updateSubject.Title)
            .Set(x => x.Tags, updateSubject.Tags is null ? null : updateSubject.Tags!.Trim().Split(','));
        await Collection.UpdateOneAsync(filter: filterDefinition, update: updateDefinition, cancellationToken: cancellationToken);
    }

}
