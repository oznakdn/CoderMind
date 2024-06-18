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

    public async Task DeleteTechnologyAsync(string id, CancellationToken cancellationToken = default)
    {
        var filter = new FilterDefinitionBuilder<Technology>().Eq(x => x.Id, id);
        await Collection.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<GetTechnologyDto> GetTechnologyAsync(string id, CancellationToken cancellationToken = default)
    {
        var technology = await Collection
            .Find(x => x.Id == id)
            .SingleOrDefaultAsync(cancellationToken);

        return new GetTechnologyDto(technology.Id, technology.Name, technology.Logo, technology.Description);
    }

    public async Task<IEnumerable<GetTechnologySubjectsDto>> GetTechnologySubjectsAsync(CancellationToken cancellationToken = default)
    {
        var technologies = await Collection
            .Find(_ => true)
            .ToListAsync(cancellationToken);


        var result = new List<GetTechnologySubjectsDto>();
        var subjectsDto = new List<Shared.Dtos.SubjectDtos.GetSubjectDto>();

        foreach (var technology in technologies)
        {
            var subjects = await _subject
                .Find(x => x.TechnologyId == technology.Id)
                .ToListAsync(cancellationToken);

            subjectsDto = subjects
                .Select(x => new Shared.Dtos.SubjectDtos.GetSubjectDto(x.Id, x.Title, x.Tags, x.CreatedDate.ToString()))
                .ToList();

            result.Add(new GetTechnologySubjectsDto(technology.Id, technology.Name, technology.Logo, technology.Description, subjectsDto));
        }

        return result;


    }

    public async Task UpdateTechnologyAsync(UpdateTechnologyDto updateTechnologyDto, CancellationToken cancellationToken = default)
    {
        var filterDefinition = new FilterDefinitionBuilder<Technology>().Eq(x => x.Id, updateTechnologyDto.Id);
      
        var updateDefinition = new UpdateDefinitionBuilder<Technology>()
            .Set(x=>x.Name, updateTechnologyDto.Name)
            .Set(x => x.Logo, updateTechnologyDto.Logo)
            .Set(x=>x.Description, updateTechnologyDto.Description);

       await Collection.UpdateOneAsync(filter: filterDefinition, update: updateDefinition, cancellationToken: cancellationToken);

    }

}
