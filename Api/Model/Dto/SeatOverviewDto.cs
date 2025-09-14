
using System.Text.Json.Serialization;

public class SeatOverviewDto
{
    public char Row { get; set; }
    public int Column { get; set; }
    public bool IsReserved { get; set; }

    [JsonConstructor]
    public SeatOverviewDto(char row, int column, bool isReserved)
    {
        Row = row;
        Column = column;
        IsReserved = isReserved; 
    }

    public SeatOverviewDto(Seat seat) : this(
        seat.Row, seat.Column, seat.ReservedUser != null
    )
    {

    }
}