
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AdminMovieManageController(IManageMovieService service) : ControllerBase
{
    protected readonly IManageMovieService _service = service;

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<MovieOverviewDto>> CreateMovieAsync(MovieOverviewDto newMovie)
    {
        return Ok(await _service.CreateMovieAsync(newMovie));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public ActionResult<List<MovieOverviewDto>> GetMovies()
    {
        return Ok(_service.GetMovies());
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<MovieOverviewDto>> UpdateMovieAsync(int id, MovieOverviewDto movieToUpdate)
    {
        return Ok(await _service.UpdateMovieAsync(id, movieToUpdate));
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> DeleteMovieAsync(Movie movieToDelete)
    {
        return Ok(await _service.DeleteMovieAsync(movieToDelete));
    }
}