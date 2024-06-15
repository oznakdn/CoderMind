using CoderMind.Application.Services.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.TechnologyDtos;
using MongoDB.Driver;

namespace CoderMind.Application.Services.Implementations;

public class TechnologyService : MongoContext<Technology>, ITechnologyService
{
    private readonly IMongoCollection<Subject> _subject;
    public TechnologyService(MongoOptions options) : base(options)
    {
        _subject = Database.GetCollection<Subject>(nameof(Subject));
    }

    public async Task CreateTechnologyAsync(CreateTechnologyDto createTechnologyDto, CancellationToken cancellationToken = default)
    {
        var technology = Technology.CreateTechnology(createTechnologyDto.Name, createTechnologyDto.Logo, createTechnologyDto.Description);
        await Collection.InsertOneAsync(technology, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<GetTechnologySubjectsDto>> GetTechnologySubjectsAsync(CancellationToken cancellationToken = default)
    {
        var technologies = await Collection
            .Find(_ => true)
            .ToListAsync(cancellationToken);


        var result = new List<GetTechnologySubjectsDto>();
        foreach (var technology in technologies)
        {
            var subjects = await _subject.Find(x => x.TechnologyId == technology.Id).ToListAsync(cancellationToken);
            result = technologies
                .Select(x => new GetTechnologySubjectsDto(x.Id, x.Name, x.Logo, x.Description,
                subjects.Select(y => new Shared.Dtos.SubjectDtos.GetSubjectDto(y.Id, y.Title, y.Tags, y.CreatedDate.ToString()))
                .ToList())).ToList();

        }

        return result;

    }
}
