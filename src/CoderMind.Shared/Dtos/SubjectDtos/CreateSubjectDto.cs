using System.ComponentModel.DataAnnotations;

namespace CoderMind.Shared.Dtos.SubjectDtos;

public class CreateSubjectDto
{
    public string TechnologyId { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Tags { get; set; }
}

