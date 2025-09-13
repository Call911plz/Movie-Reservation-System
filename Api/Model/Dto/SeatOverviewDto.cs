
public class SeatOverviewDto(Seat seat)
{
    public char Row { get; set; } = seat.Row;
    public int Column { get; set; } = seat.Column;
    public bool IsReserved { get; set; } = (seat.ReservedUser != null);
}