using Microsoft.EntityFrameworkCore;

[Owned]
public class Seat
{
    public int MovieId { get; set; }
    public int Row { get; set; }
    public char Column { get; set; }
    public User? ReservedUser { get; set; }
}