using Microsoft.EntityFrameworkCore;

public interface IUserRepository
{
    public Task<User> CreateUserAsync(User newUser);
    public List<User> GetUsers();
    public Task<User?> UpdateUserAsync(User userToUpdate);
    public Task<bool?> DeleteUserAsync(User userToDelete);
}

public class UserRepository(MovieReservationDbContext context) : IUserRepository
{
    protected readonly MovieReservationDbContext _context = context;

    public async Task<User> CreateUserAsync(User newUser)
    {
        var result = _context.Users.Add(newUser);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool?> DeleteUserAsync(User userToDelete)
    {
        var userEntity = await _context.Users.SingleOrDefaultAsync(user => user.Id == userToDelete.Id);

        if (userEntity == null)
            return null;

        _context.Remove(userEntity);

        await _context.SaveChangesAsync();
        
        return true;
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public async Task<User?> UpdateUserAsync(User userToUpdate)
    {
        var userEntity = await _context.Users.FindAsync(userToUpdate.Id);

        if (userEntity == null)
            return null;

        userEntity.Name = userToUpdate.Name;
        userEntity.Role = userToUpdate.Role;
        userEntity.ReservedSeat = userToUpdate.ReservedSeat;

        await _context.SaveChangesAsync();

        return userEntity;
    }
}