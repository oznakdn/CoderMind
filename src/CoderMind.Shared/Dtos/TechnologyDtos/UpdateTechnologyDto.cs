using System.ComponentModel.DataAnnotations;

namespace CoderMind.Shared.Dtos.TechnologyDtos;

public class UpdateTechnologyDto
{
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Logo { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
