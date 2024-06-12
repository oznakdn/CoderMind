using CoderMind.Domain.Models;
using CoderMind.Shared.Dtos.UserDtos;
using CoderMind.Shared.Results;

namespace CoderMind.Application.Services.Interfaces;

public interface IUserService
{
    Task<IResult> Register(RegisterDto registerDto);
    Task<IResult> Login(LoginDto loginDto);
}
