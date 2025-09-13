
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    // Optional One to Many relation with seat
    public ICollection<Seat> ReservedSeats { get; set; } = null!;
}