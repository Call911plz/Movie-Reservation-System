
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserMovieRequestController(IMovieLookUpService service) : ControllerBase
{
    protected readonly IMovieLookUpService _service = service;

    [HttpGet("genre")]
    [Authorize(Roles = "Admin, User")]
    public ActionResult<List<Movie>> GetByGenre()
    {
        return Ok(_service.GetByGenre());
    }
}