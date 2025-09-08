
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("register")]
public class RegisterController(IRegisterService service) : ControllerBase
{
    protected readonly IRegisterService _service = service;

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUserAsync(UserRegisterDto userInfo)
    {
        return Ok(await _service.RegisterUserAsync(userInfo));
    }
}