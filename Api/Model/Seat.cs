public class Seat
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public User? ReservedUser { get; set; }
}