using CoderMind.Application.Services.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.ContentDtos;
using MongoDB.Driver;

namespace CoderMind.Application.Services.Implementations;

public class ContentService : MongoContext<Content>, IContentService
{
    private readonly IMongoCollection<Subject> _subject;
    public ContentService(MongoOptions options) : base(options)
    {
        _subject = Database.GetCollection<Subject>(nameof(Subject));
    }

    public async Task CreateContentAsync(CreateContentDto createContentDto, CancellationToken cancellationToken = default)
    {
        var content = Content.CreateMongoContent(
            createContentDto.SubjectId,
            createContentDto.Text,
            createContentDto.Files,
            createContentDto.Links);

        await Collection.InsertOneAsync(content, cancellationToken: cancellationToken);
    }

    public async Task<GetContentDto> GetContentAsync(string id, CancellationToken cancellationToken = default)
    {
        var content = await Collection.Find(x => x.Id == id).SingleOrDefaultAsync(cancellationToken);
        return new GetContentDto(content.Id, content.SubjectId, content.SubjectId, content.Text, content.Files, content.Links);
    }

    public async Task<GetContentDto> GetSubjectContentBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default)
    {
        var content = await Collection.Find(x => x.SubjectId == subjectId).SingleOrDefaultAsync(cancellationToken);

        var subject = await _subject.Find(x => x.Id == subjectId).SingleOrDefaultAsync(cancellationToken);

        if (content is null) return null;

        return new GetContentDto(content.Id, content.SubjectId, subject.Title, content.Text, content.Files, content.Links);
    }

    public async Task UpdateContentAsync(UpdateContentDto updateContentDto, CancellationToken cancellationToken = default)
    {
        var filterDefinition = new FilterDefinitionBuilder<Content>().Eq(x => x.Id, updateContentDto.Id);

        var updateDefinition = new UpdateDefinitionBuilder<Content>()
            .Set(x => x.Text, updateContentDto.Text)
            .Set(x => x.Files, updateContentDto.Files)
            .Set(x => x.Links, updateContentDto.Links);

        await Collection.UpdateOneAsync(filter: filterDefinition, update: updateDefinition, cancellationToken: cancellationToken);

    }

}
