using CoderMind.Shared.Dtos.ContentDtos;
using CoderMind.Shared.Dtos.SubjectDtos;

namespace CoderMind.Application.Services.Interfaces;

public interface IContentService
{
    Task<GetContentDto> GetSubjectContentBySubjectIdAsync(string subjectId, CancellationToken cancellationToken = default);
    Task CreateContentAsync(CreateContentDto createContentDto, CancellationToken cancellationToken = default);
}
