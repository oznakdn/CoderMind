using System.ComponentModel.DataAnnotations;

namespace CoderMind.Shared.Dtos.AccountDtos;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
