public interface IManageMovieService
{
    public Task<MovieOverviewDto?> CreateMovieAsync(MovieOverviewDto newMovie);
    public List<MovieOverviewDto> GetMovies();
    public Task<MovieOverviewDto?> UpdateMovieAsync(int id, MovieOverviewDto movieToUpdate);
    public Task<MovieOverviewDto?> DeleteMovieAsync(int id);
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

    public async Task<MovieOverviewDto?> DeleteMovieAsync(int id)
    {
        Movie? returnedMovie = await _repo.DeleteMovieAsync(id);

        if (returnedMovie == null)
            return null;

        return new MovieOverviewDto(returnedMovie);
    }

    public List<MovieOverviewDto> GetMovies()
    {
        return _repo.GetMovies()
            .Select(movie => new MovieOverviewDto(movie))
            .ToList();
    }

    public async Task<MovieOverviewDto?> UpdateMovieAsync(int id, MovieOverviewDto movieToUpdate)
    {
        Movie? returnedMovie = await _repo.UpdateMovieAsync(new Movie
        {
            Id = id,
            Name = movieToUpdate.Name,
            Description = movieToUpdate.Description,
            ImagePath = movieToUpdate.ImagePath,
            Cost = movieToUpdate.Cost,
            PlayLength = movieToUpdate.PlayLength,
            Genre = movieToUpdate.Genre,
            AnnouncmentTime = movieToUpdate.AnnouncmentTime,
            ShowTime = movieToUpdate.ShowTime,
            Seats = movieToUpdate.Seats
                .Select(seat => new Seat
                {
                    Row = seat.Row,
                    Column = seat.Column
                })
                .ToList()
        });

        return new MovieOverviewDto(returnedMovie);
    }
}