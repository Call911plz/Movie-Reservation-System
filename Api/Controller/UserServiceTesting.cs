
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("")]
public class UserServiceTesting(IUserRepoTesting service) : ControllerBase
{
    protected readonly IUserRepoTesting _service = service;

    [HttpPost]
    public async Task<ActionResult<User>> CreateUserAsync(User newUser)
    {
        return Ok(await _service.CreateUserAsync(newUser));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public ActionResult<List<User>> GetUsers()
    {
        return Ok(_service.GetUsers());
    }

    [HttpPut]
    public async Task<ActionResult<User>> UpdateUserAsync(User userToUpdate)
    {
        return Ok(await _service.UpdateUserAsync(userToUpdate));
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteUserAsync(User userToDelete)
    {
        return Ok(await _service.DeleteUserAsync(userToDelete));
    }
}