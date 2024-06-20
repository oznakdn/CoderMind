using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.SubjectDtos;
using CoderMind.Shared.Dtos.TechnologyDtos;
using Microsoft.EntityFrameworkCore;

namespace CoderMind.Application.Services.EFCoreServices.Implementations;

public class EfTechnologyService : IEfTechnologyService
{
    private readonly EFContext context;
    public EfTechnologyService(EFContext context)
    {
        this.context = context;
    }
    public async Task CreateTechnologyAsync(CreateTechnologyDto createTechnologyDto, CancellationToken cancellationToken = default)
    {
        var technology = Technology.CreateEfTechnology(createTechnologyDto.Name, createTechnologyDto.Logo, createTechnologyDto.Description);
        context.Entry<Technology>(technology).State = EntityState.Added;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTechnologyAsync(string id, CancellationToken cancellationToken = default)
    {
        var technology = await context.Technologies.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        context.Entry<Technology>(technology).State = EntityState.Deleted;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTechnologyAsync(UpdateTechnologyDto updateTechnologyDto, CancellationToken cancellationToken = default)
    {
        var technology = await context.Technologies.SingleOrDefaultAsync(x => x.Id == updateTechnologyDto.Id, cancellationToken);
        technology.Name = updateTechnologyDto.Name;
        technology.Logo = updateTechnologyDto.Logo;
        technology.Description = updateTechnologyDto.Description;
        context.Entry<Technology>(technology).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetTechnologyDto> GetTechnologyAsync(string id, CancellationToken cancellationToken = default)
    {
        var technology = await context.Technologies
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return new GetTechnologyDto(technology.Id, technology.Name, technology.Logo, technology.Description);
    }

    public async Task<IEnumerable<GetTechnologySubjectsDto>> GetTechnologySubjectsAsync(CancellationToken cancellationToken = default)
    {
        var technologies = await context.Technologies
            .ToListAsync(cancellationToken);

        var result = new List<GetTechnologySubjectsDto>();
        var subjectsDto = new List<GetSubjectDto>();

        foreach (var technology in technologies)
        {
            var subjects = await context.Subjects
                .Where(x => x.TechnologyId == technology.Id)
                .ToListAsync(cancellationToken);

            subjectsDto = subjects
                .Select(x => new Shared.Dtos.SubjectDtos.GetSubjectDto(x.Id, x.Title, x.Tags, x.CreatedDate.ToString()))
                .ToList();

            result.Add(new GetTechnologySubjectsDto(technology.Id, technology.Name, technology.Logo, technology.Description, subjectsDto));
        }

        return result;
    }


}
