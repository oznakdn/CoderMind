using CoderMind.Application.Helpers;
using CoderMind.Application.Services.Interfaces;
using CoderMind.Application.Validations.UserValidations;
using CoderMind.Domain.Models;
using CoderMind.Persistence.Database;
using CoderMind.Shared.Dtos.UserDtos;
using CoderMind.Shared.Results;
using MongoDB.Driver;

namespace CoderMind.Application.Services.Implementations;

public class UserService : MongoContext<User>, IUserService
{
    public UserService(MongoOptions options) : base(options)
    {
    }

    public async Task<IResult> Login(LoginDto loginDto)
    {
        var validator = new LoginValidator();
        var validate = validator.Validate(loginDto);

        if (!validate.IsValid)
            return Result.Failure(errors:validate.Errors.Select(x => x.ErrorMessage).ToList());
        
        var existUser = await Collection
            .Find(x => x.Username == loginDto.Username)
            .FirstOrDefaultAsync();

        if (existUser is null) return Result.Failure(message: "Credential is not valid!");

        var verifyPassword = PasswordHashHelper.VerifyHashPassword(loginDto.Password, existUser.Password);
        if(!verifyPassword)
            return Result.Failure(message:"Credential is not valid!");

        return Result.Success();
    }

    public async Task<IResult> Register(RegisterDto registerDto)
    {
        var validator = new RegisterValidator();
        var validate = validator.Validate(registerDto);

        if (!validate.IsValid)
            return Result.Failure(errors: validate.Errors.Select(x => x.ErrorMessage).ToList());

        var existUser = await Collection
            .Find(x => x.Username == registerDto.Username)
            .FirstOrDefaultAsync();

        if(existUser is not null) return Result.Failure(message: "Username already exist!");

        var createdUser = User.CreateUser(registerDto.Username, registerDto.Password.HashPassword());

        if (createdUser is null) return Result.Failure(message: "Something went wrong!");

        await Collection.InsertOneAsync(createdUser);
        return Result.Success();
    }

}
