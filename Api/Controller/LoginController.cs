
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("login")]
public class LoginController(ILoginService service, IConfiguration config, IJwtService jwtService) : ControllerBase
{
    protected readonly ILoginService _service = service;
    protected readonly IConfiguration _config = config;
    protected readonly IJwtService _jwtService = jwtService;

    [HttpPost]
    public ActionResult<string> LoginUserAsync(UserLoginDataDto userInfo)
    {
        var result = _service.LoginUserAsync(userInfo);

        if (result == null)
            return Unauthorized();

        return Ok(_jwtService.GenerateJWT(result));
    }
}