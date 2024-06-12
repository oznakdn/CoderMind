using CoderMind.Shared.Dtos.UserDtos;
using FluentValidation;

namespace CoderMind.Application.Validations.UserValidations;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}
