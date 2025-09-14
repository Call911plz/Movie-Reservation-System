public interface IMovieLookUpService
{
    public List<MovieOverviewDto> GetByGenre();
}

public class MovieLookUpService(IMovieRepository repo) : IMovieLookUpService
{
    protected readonly IMovieRepository _repo = repo;

    public List<MovieOverviewDto> GetByGenre()
    {
        List<Movie> moviesByGenres = _repo
            .GetMovies()
            .OrderBy(movie => movie.Genre)
            .ToList();

        List<MovieOverviewDto> dtos = moviesByGenres
            .Select(movie => new MovieOverviewDto(movie))
            .ToList();

        return dtos;
    }
}