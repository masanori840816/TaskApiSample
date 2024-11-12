using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskApiSample.AppUsers.Auth;
using TaskApiSample.AppUsers.DTO;

namespace TaskApiSample.AppUsers;

public class AppUsersController(IAuthService auth) : Controller
{
    [HttpGet("/appusers/sample")]
    public async Task<IdentityResult> CreateSampleUser()
    {
        RegistrationAppUser sampleUser = new(null, "Sample", "sample@example.com", "sample");
        return await auth.CreateUserAsync(sampleUser);
    }
    [HttpGet("/appusers")]
    public IActionResult GetLoginUser()
    {
        var user = new DisplayAppUser("Masanori");
        return Json(user);
    }
}