public interface IManageMovieService
{
    public Task<Movie?> CreateMovieAsync(Movie newMovie);
    public List<MovieOverviewDto> GetMovies();
    public Task<Movie?> UpdateMovieAsync(Movie movieToUpdate);
    public Task<bool?> DeleteMovieAsync(Movie movieToDelete);
}

public class ManageMovieService(IMovieRepository repo) : IManageMovieService
{
    IMovieRepository _repo = repo;

    public async Task<Movie?> CreateMovieAsync(Movie newMovie)
    {
        return await _repo.CreateMovieAsync(newMovie);
    }

    public async Task<bool?> DeleteMovieAsync(Movie movieToDelete)
    {
        return await _repo.DeleteMovieAsync(movieToDelete);
    }

    public List<MovieOverviewDto> GetMovies()
    {
        return _repo.GetMovies()
            .Select(movie => new MovieOverviewDto(movie))
            .ToList();
    }

    public Task<Movie?> UpdateMovieAsync(Movie movieToUpdate)
    {
        return _repo.UpdateMovieAsync(movieToUpdate);
    }
}