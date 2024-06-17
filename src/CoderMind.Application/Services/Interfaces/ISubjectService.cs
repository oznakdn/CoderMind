using CoderMind.Shared.Dtos.SubjectDtos;

namespace CoderMind.Application.Services.Interfaces;

public interface ISubjectService
{
    Task CreateSubjectAsync(CreateSubjectDto createSubject, CancellationToken cancellationToken = default);
    Task DeleteSubjectAsync(string id, CancellationToken cancellationToken = default);

}
