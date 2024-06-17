namespace CoderMind.Shared.Dtos.ContentDtos;

public record GetContentDto(string Id,string SubjectTitle, string Text, string[]? Files, string[]? Links);

