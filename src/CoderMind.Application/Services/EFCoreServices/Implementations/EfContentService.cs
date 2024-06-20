using CoderMind.Application.Services.EFCoreServices.Interfaces;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.ContentDtos;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CoderMind.Application.Services.EFCoreServices.Implementations;

public class EfContentService : IEfContentService
{
    private readonly EFContext context;
    public EfContentService(EFContext context)
    {
        this.context = context;
    }

    public async Task CreateContentAsync(CreateContentDto createContentDto, CancellationToken cancellationToken = default)
    {
        var content = Content.CreateEfContent(
            createContentDto.SubjectId,
            createContentDto.Text,
            createContentDto.Files,
            createContentDto.Links);

        context.Entry<Content>(content).State = EntityState.Added;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetContentDto> GetContentAsync(string id, CancellationToken cancellationToken = default)
    {
        var content = await context.Contents.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return new GetContentDto(content.Id, content.SubjectId, content.SubjectId, content.Text, content.Files, content.Links);
    }

    public async Task<GetContentDto?>? GetSubjectContentBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default)
    {

        var subject = await context.Subjects.Where(x => x.Id == subjectId)
            .SingleOrDefaultAsync(cancellationToken);

        var content = await context.Contents
            .SingleOrDefaultAsync(x => x.SubjectId == subject!.Id, cancellationToken);

        if(content is null)
        {
            return null;
        }

        return new GetContentDto(content.Id, subject.Id, subject.Title, content.Text, content.Files, content.Links);
    }

    public async Task UpdateContentAsync(UpdateContentDto updateContentDto, CancellationToken cancellationToken = default)
    {

        var content = await context.Contents
            .SingleOrDefaultAsync(x => x.Id == updateContentDto.Id, cancellationToken);


        content.Text = updateContentDto.Text;
        content.Files = updateContentDto.Files is null ? null : updateContentDto.Files;
        content.Links = updateContentDto.Links is null ? null : updateContentDto.Links;

        context.Entry<Content>(content).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);

    }
}
