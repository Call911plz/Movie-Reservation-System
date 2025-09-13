public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public float Cost { get; set; }
    public string PlayLength { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime AnnouncmentTime { get; set; }
    public DateTime ShowTime { get; set; }

    // One to Many relation to seats
    public ICollection<Seat> Seats { get; set; } = [];
}