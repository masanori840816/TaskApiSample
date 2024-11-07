using Microsoft.AspNetCore.Mvc;
using TaskApiSample.AppUsers.DTO;

namespace TaskApiSample.AppUsers;

public class AppUsersController : Controller
{
    public AppUsersController(IConfiguration config)
    {
        Console.WriteLine(config.GetConnectionString("OurTasks"));
    }
    [HttpGet("/appusers")]
    public IActionResult GetLoginUser()
    {
        var user = new DisplayAppUser("Masanori");
        return Json(user);
    }
}