
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("register")]
public class RegisterController(IRegisterService service) : ControllerBase
{
    protected readonly IRegisterService _service = service;

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUserAsync(UserDataDto userInfo)
    {
        var result = await _service.RegisterUserAsync(userInfo);

        if (result == null)
            return BadRequest();

        return Ok(result);
    }
}