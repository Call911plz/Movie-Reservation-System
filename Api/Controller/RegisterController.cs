
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("register")]
public class RegisterController(IRegisterService service, IConfiguration config, IJwtService jwtService) : ControllerBase
{
    protected readonly IRegisterService _service = service;
    protected readonly IConfiguration _config = config;
    protected readonly IJwtService _jwtService = jwtService;

    [HttpPost]
    public async Task<ActionResult<string>> RegisterUserAsync(UserDataDto userInfo)
    {
        var result = await _service.RegisterUserAsync(userInfo);

        if (result == null)
            return BadRequest();

        return Ok(_jwtService.GenerateJWT(result));
    }
}