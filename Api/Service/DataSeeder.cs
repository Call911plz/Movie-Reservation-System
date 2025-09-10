using Isopoh.Cryptography.Argon2;

public class DataSeeder(MovieReservationDbContext context)
{
    protected readonly MovieReservationDbContext _context = context;

    public async Task SeedAdminAsync()
    {
        await _context.Database.EnsureCreatedAsync();

        if (!_context.Users.Any(user => user.Role == UserRoles.Admin))
        {
            var admin = new User
            {
                Username = "admin",
                Password = Argon2.Hash("admin"),
                Role = UserRoles.Admin
            };

            _context.Users.Add(admin);

            await _context.SaveChangesAsync();
        }
    }
}