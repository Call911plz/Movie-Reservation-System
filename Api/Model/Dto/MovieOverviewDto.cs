using System.Text.Json.Serialization;

public class MovieOverviewDto
{
    public int Id { get; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public float Cost { get; set; }
    public string PlayLength { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime AnnouncmentTime { get; set; }
    public DateTime ShowTime { get; set; }
    public ICollection<SeatOverviewDto> Seats { get; set; } = [];

    // Constructor for json serialization 
    [JsonConstructor]
    public MovieOverviewDto(
        string name, string description, string imagePath,
        float cost, string playLength, string genre,
        DateTime announcmentTime, DateTime showTime, ICollection<SeatOverviewDto> seats)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
        Cost = cost;
        PlayLength = playLength;
        Genre = genre;
        AnnouncmentTime = announcmentTime;
        ShowTime = showTime;
        Seats = seats;
    }

    // Constructor for quick movie to dto
    public MovieOverviewDto(Movie movie) : this(
        movie.Name, movie.Description, movie.ImagePath,
        movie.Cost, movie.PlayLength, movie.Genre,
        movie.AnnouncmentTime, movie.ShowTime,
        movie.Seats.Select(seat => new SeatOverviewDto(seat)).ToList()
    )
    {
        Id = movie.Id; // assigning visible id only when retrieving from existing movie
    }
}