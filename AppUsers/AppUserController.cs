using Microsoft.AspNetCore.Mvc;

namespace TaskApiSample.AppUsers;

public class AppUsersController : Controller
{
    [HttpGet("/appusers")]
    public IActionResult GetLoginUser()
    {
        var user = new AppUser("Masanori");
        return Json(user);
    }
}