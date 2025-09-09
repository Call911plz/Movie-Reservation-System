
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("login")]
public class LoginController(ILoginService service, IConfiguration config) : ControllerBase
{
    protected readonly ILoginService _service = service;
    protected readonly IConfiguration _config = config;

    [HttpPost]
    public ActionResult<string> LoginUserAsync(UserDataDto userInfo)
    {
        var result = _service.LoginUserAsync(userInfo);

        if (result == null)
            return Unauthorized();

        return Ok(GenerateJWT(result));
    }

    private string GenerateJWT(User userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(ClaimTypes.Role, userInfo.Role)
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