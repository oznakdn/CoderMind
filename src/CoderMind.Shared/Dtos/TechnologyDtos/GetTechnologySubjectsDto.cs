using CoderMind.Shared.Dtos.SubjectDtos;

namespace CoderMind.Shared.Dtos.TechnologyDtos;

public record GetTechnologySubjectsDto(string TechnologyId, string Name, string Logo, string Description, List<GetSubjectDto> Subjects);

