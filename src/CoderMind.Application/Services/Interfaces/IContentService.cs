using CoderMind.Shared.Dtos.ContentDtos;
using CoderMind.Shared.Dtos.SubjectDtos;

namespace CoderMind.Application.Services.Interfaces;

public interface IContentService
{
    Task<GetContentDto> GetSubjectContentBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default);
    Task<GetContentDto> GetContentAsync(string id, CancellationToken cancellationToken = default);


    Task CreateContentAsync(CreateContentDto createContentDto, CancellationToken cancellationToken = default);
    Task UpdateContentAsync(UpdateContentDto updateContentDto, CancellationToken cancellationToken = default);
}
