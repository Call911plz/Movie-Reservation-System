using Microsoft.EntityFrameworkCore;

public class Seat
{
    public int Id { get; set; }
    public char Row { get; set; }
    public int Column { get; set; }

    // One to Many relation to movie
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
   
    // Optionaly One to Many relation to user
    public int? ReservedUserId { get; set; }
    public User? ReservedUser { get; set; }
}