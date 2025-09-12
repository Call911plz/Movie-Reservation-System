public interface IMovieLookUpService
{
    public List<Movie> GetByGenre();
}

public class MovieLookUpService(IMovieRepository repo) : IMovieLookUpService
{
    protected readonly IMovieRepository _repo = repo;

    public List<Movie> GetByGenre()
    {
        var moviesByGenre = _repo.GetMovies().OrderBy(movie => movie.Genre).ToList();

        return moviesByGenre;
    }
}