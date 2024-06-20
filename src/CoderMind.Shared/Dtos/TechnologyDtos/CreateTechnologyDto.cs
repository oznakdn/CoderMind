using System.ComponentModel.DataAnnotations;

namespace CoderMind.Shared.Dtos.TechnologyDtos;

public record CreateTechnologyDto([Required]string Name, string Logo, string Description);

