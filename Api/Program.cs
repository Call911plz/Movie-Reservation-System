
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        Env.Load(); // Loading env variables from .env file
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<MovieReservationDbContext>(
            opt => opt.UseSqlServer($@"
                Server={Environment.GetEnvironmentVariable("DB_HOST")};
                Database={Environment.GetEnvironmentVariable("DB")};
                User Id={Environment.GetEnvironmentVariable("DB_USER_ID")};
                Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};
                TrustServerCertificate=True;
            ")
        );
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IUserRepoTesting, UserRepoTesting>(); // remove for development
        builder.Services.AddScoped<IRegisterService, RegisterService>();
        builder.Services.AddScoped<ILoginService, LoginService>();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
