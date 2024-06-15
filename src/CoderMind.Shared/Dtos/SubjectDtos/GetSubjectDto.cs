namespace CoderMind.Shared.Dtos.SubjectDtos;

public record GetSubjectDto(string SubjectId, string Title, string[]? Tags,string CreatedDate);

