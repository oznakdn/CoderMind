using System.ComponentModel.DataAnnotations;

namespace CoderMind.Shared.Dtos.SubjectDtos;

public class UpdateSubjectDto
{
    public string Id { get; set; }

    [Required]
    public string Title { get; set; }
    public string? Tags { get; set; }

}
