using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.SubjectDtos;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CoderMind.Application.Services.EFCoreServices.Implementations;

public class EfSubjectService : IEfSubjectService
{

    private readonly EFContext context;

    public EfSubjectService(EFContext context)
    {
        this.context = context;
    }

    public async Task CreateSubjectAsync(CreateSubjectDto createSubject, CancellationToken cancellationToken = default)
    {
        var subject = Subject.CreateEfSubject(createSubject.TechnologyId, createSubject.Title, createSubject.Tags);

        context.Entry<Subject>(subject).State = EntityState.Added;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteSubjectAsync(string id, CancellationToken cancellationToken = default)
    {
        var subject = await context.Subjects.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        context.Entry<Subject>(subject).State = EntityState.Deleted;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetSubjectDto> GetSubjectAsync(string id, CancellationToken cancellationToken = default)
    {
        var subject = await context.Subjects
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return new GetSubjectDto(subject.Id, subject.Title, subject.Tags, subject.CreatedDate.ToString());
    }

    public async Task UpdateSubjectAsync(UpdateSubjectDto updateSubject, CancellationToken cancellationToken = default)
    {
        var subject = await context.Subjects.SingleOrDefaultAsync(x => x.Id == updateSubject.Id, cancellationToken);

        subject.Title = updateSubject.Title;
        subject.Tags = updateSubject.Tags;

        context.Entry<Subject>(subject).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
    }
}
