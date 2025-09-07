
using Microsoft.EntityFrameworkCore;

public class MovieReservationDbContext : DbContext
{
    public MovieReservationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}