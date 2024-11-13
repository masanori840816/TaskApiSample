using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskApiSample.AppUsers.DTO;

namespace TaskApiSample.AppUsers.Auth;

public interface IAuthService
{
    Task<IdentityResult> CreateUserAsync(RegistrationAppUser user);
    Task<IResult> LogoutAsync();
}