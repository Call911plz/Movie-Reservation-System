
using Microsoft.EntityFrameworkCore;

public class MovieReservationDbContext : DbContext
{
    public MovieReservationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(e => e.Seats)
            .WithOne(e => e.Movie)
            .HasForeignKey(e => e.MovieId)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasMany(e => e.ReservedSeats)
            .WithOne(e => e.ReservedUser)
            .HasForeignKey(e => e.ReservedUserId)
            .IsRequired(false);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Seat> Seats { get; set; }
}