using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskApiSample.AppUsers.DTO;
using TaskApiSample.AppUsers.Models;

namespace TaskApiSample.AppUsers.Auth;

public class AuthService(SignInManager<AppUser> signInManager): IAuthService
{
    public async Task<IdentityResult> CreateUserAsync(RegistrationAppUser user)
    {
        AppUser newUser = AppUser.Create(user);
        return await signInManager.UserManager.CreateAsync(newUser);
    }
    public async Task<IResult> LogoutAsync()
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}