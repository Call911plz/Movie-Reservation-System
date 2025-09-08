
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("login")]
public class LoginController(ILoginService service) : ControllerBase
{
    protected readonly ILoginService _service = service;

    [HttpPost]
    public ActionResult<bool> RegisterUserAsync(UserDataDto userInfo)
    {
        return Ok(_service.LoginUserAsync(userInfo));
    }
}