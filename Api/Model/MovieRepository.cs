using Microsoft.EntityFrameworkCore;

public interface IMovieRepository
{
    public Task<Movie> CreateMovieAsync(Movie newMovie);
    public List<Movie> GetMovies();
    public Task<Movie?> UpdateMovieAsync(Movie movieToUpdate);
    public Task<Movie?> DeleteMovieAsync(int id);
}

public class MovieRepository(MovieReservationDbContext context) : IMovieRepository
{
    protected readonly MovieReservationDbContext _context = context;

    public async Task<Movie> CreateMovieAsync(Movie newMovie)
    {
        var result = _context.Movies.Add(newMovie);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Movie?> DeleteMovieAsync(int id)
    {
        var movieEntity = await _context.Movies.SingleOrDefaultAsync(movie => movie.Id == id);

        if (movieEntity == null)
            return null;

        _context.Remove(movieEntity);

        await _context.SaveChangesAsync();
        
        return movieEntity;
    }

    public List<Movie> GetMovies()
    {
        var result = _context.Movies
            .Include(m => m.Seats)
            .ToList();
        return result;
    }

    public async Task<Movie?> UpdateMovieAsync(Movie movieToUpdate)
    {
        var movieEntity = await _context.Movies.FindAsync(movieToUpdate.Id);

        if (movieEntity == null)
            return null;

        movieEntity.Name = movieToUpdate.Name;
        movieEntity.Description = movieToUpdate.Description;
        movieEntity.ImagePath = movieToUpdate.ImagePath;
        movieEntity.Cost = movieToUpdate.Cost;
        movieEntity.PlayLength = movieToUpdate.PlayLength;
        movieEntity.Genre = movieToUpdate.Genre;
        movieEntity.AnnouncmentTime = movieToUpdate.AnnouncmentTime;
        movieEntity.ShowTime = movieToUpdate.ShowTime;
        movieEntity.Seats = movieToUpdate.Seats;

        await _context.SaveChangesAsync();

        return movieEntity;
    }
}