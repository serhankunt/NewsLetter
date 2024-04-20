using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsLetter.Domain.Entities;
using TS.Result;

namespace NewsLetter.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p=>p.Email == request.UserNameOrEmail ||
        p.UserName == request.UserNameOrEmail, cancellationToken);

        if (appUser == null)
        {
            return Result<string>.Failure("User not found");
        }

        bool checkPassword = await userManager.CheckPasswordAsync(appUser,request.Password);
        if(!checkPassword)
        {
            return Result<string>.Failure("Password is wrong");
        }

        return "Login is successful";
    }
}
