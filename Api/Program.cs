
using Microsoft.EntityFrameworkCore;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<MovieReservationDbContext>(
            opt => opt.UseSqlServer(@"
                Server=localhost;
                Database=MovieReservation;
                User Id=;
                Password=;
                TrustServerCertifcate=True;
            ")
        );

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
