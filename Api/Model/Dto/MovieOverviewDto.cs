public class MovieOverviewDto(Movie movie)
{
    public string Name { get; set; } = movie.Name;
    public string Description { get; set; } = movie.Description;
    public string ImagePath { get; set; } = movie.ImagePath;
    public float Cost { get; set; } = movie.Cost;
    public string PlayLength { get; set; } = movie.PlayLength;
    public string Genre { get; set; } = movie.Genre;
    public DateTime AnnouncmentTime { get; set; } = movie.AnnouncmentTime;
    public DateTime ShowTime { get; set; } = movie.ShowTime;

    // Passing seats to seat overview dto
    public ICollection<SeatOverviewDto> Seats { get; set; } = movie.Seats
        .Select(seat => new SeatOverviewDto(seat))
        .ToList(); 

}