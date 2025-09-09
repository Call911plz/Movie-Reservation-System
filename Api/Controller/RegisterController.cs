
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("register")]
public class RegisterController(IRegisterService service, IConfiguration config) : ControllerBase
{
    protected readonly IRegisterService _service = service;
    protected readonly IConfiguration _config = config;

    [HttpPost]
    public async Task<ActionResult<string>> RegisterUserAsync(UserDataDto userInfo)
    {
        var result = await _service.RegisterUserAsync(userInfo);

        if (result == null)
            return BadRequest();

        return Ok(GenerateJWT(userInfo));
    }

    private string GenerateJWT(UserDataDto userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username)
        };

        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}