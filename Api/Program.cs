
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Isopoh.Cryptography.Argon2;
using System.Threading.Tasks;

namespace Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        Env.Load(); // Loading env variables from .env file
        var builder = WebApplication.CreateBuilder(args);

        // Adding necessary services and dingys
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

        // Repos
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();

        // Main services
        builder.Services.AddScoped<IUserRepoTesting, UserRepoTesting>(); // remove for development
        builder.Services.AddScoped<IManageMovieService, ManageMovieService>();
        builder.Services.AddScoped<IRegisterService, RegisterService>();
        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<IMovieLookUpService, MovieLookUpService>();

        // Secondary services supplementing main
        builder.Services.AddScoped<IJwtService, JwtService>();

        // JWT Extraction
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer( options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
        });

        var app = builder.Build();

        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();

        // Seeding data
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<MovieReservationDbContext>();
            DataSeeder seeder = new(context);
            await seeder.SeedAdminAsync();
        }

        app.Run();
    }
}
