using CoderMind.Shared.Dtos.ContentDtos;

namespace CoderMind.Shared.Dtos.SubjectDtos;

public record GetSubjectDetailDto(string SubjectId, string Title, GetContentDto Content);

