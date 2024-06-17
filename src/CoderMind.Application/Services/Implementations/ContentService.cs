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
        var content = Content.CreateContent(createContentDto.SubjectId, createContentDto.Text, createContentDto.Files?.Trim().Split(','), createContentDto.Links?.Trim().Split(','));
        await Collection.InsertOneAsync(content, cancellationToken: cancellationToken);
    }

    public async Task<GetContentDto> GetSubjectContentBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default)
    {
        var content = await Collection.Find(x => x.SubjectId == subjectId).SingleOrDefaultAsync(cancellationToken);

        var subject = await _subject.Find(x => x.Id == subjectId).SingleOrDefaultAsync(cancellationToken);

        if (content is null) return null;

        return new GetContentDto(content.Id, subject.Title, content.Text, content.Files, content.Links);
    }
}
