using Microsoft.AspNetCore.Identity;
using TaskApiSample.AppUsers.DTO;

namespace TaskApiSample.AppUsers.Auth;

public interface IAuthService
{
    Task<IdentityResult> CreateUserAsync(RegistrationAppUser user);
}