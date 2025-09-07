
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ReservedSeat { get; set; } = null;
    public bool IsAdmin { get; set; }
}