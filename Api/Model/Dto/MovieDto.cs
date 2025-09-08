public class MovieDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public float Cost { get; set; }
    public TimeOnly PlayLength { get; set; }
    public string Genre { get; set; } = string.Empty;
    public DateTime ShowTime { get; set; }
    public required List<SeatRow> SeatRows { get; set; }
}