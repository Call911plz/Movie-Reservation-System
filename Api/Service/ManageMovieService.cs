public interface IManageMovieService
{
    public Task<MovieOverviewDto?> CreateMovieAsync(MovieOverviewDto newMovie);
    public List<MovieOverviewDto> GetMovies();
    public Task<Movie?> UpdateMovieAsync(Movie movieToUpdate);
    public Task<bool?> DeleteMovieAsync(Movie movieToDelete);
}

public class ManageMovieService(IMovieRepository repo) : IManageMovieService
{
    IMovieRepository _repo = repo;

    public async Task<MovieOverviewDto?> CreateMovieAsync(MovieOverviewDto newMovie)
    {
        Movie returnedMovie = await _repo.CreateMovieAsync(new Movie
        {
            Name = newMovie.Name,
            Description = newMovie.Description,
            ImagePath = newMovie.ImagePath,
            Cost = newMovie.Cost,
            PlayLength = newMovie.PlayLength,
            Genre = newMovie.Genre,
            AnnouncmentTime = newMovie.AnnouncmentTime,
            ShowTime = newMovie.ShowTime,
            Seats = newMovie.Seats
                .Select(seat => new Seat
                {
                    Row = seat.Row,
                    Column = seat.Column
                })
                .ToList()
        });
        return new MovieOverviewDto(returnedMovie);
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