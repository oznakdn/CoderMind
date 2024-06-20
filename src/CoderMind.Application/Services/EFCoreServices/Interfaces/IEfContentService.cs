using CoderMind.Shared.Dtos.ContentDtos;

namespace CoderMind.Application.Services.EFCoreServices.Interfaces;

public interface IEfContentService
{
    Task<GetContentDto?>? GetSubjectContentBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default);
    Task<GetContentDto> GetContentAsync(string id, CancellationToken cancellationToken = default);
    Task CreateContentAsync(CreateContentDto createContentDto, CancellationToken cancellationToken = default);
    Task UpdateContentAsync(UpdateContentDto updateContentDto, CancellationToken cancellationToken = default);
}
