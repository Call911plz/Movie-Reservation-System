public interface IUserRepoTesting
{
    public Task<User> CreateUserAsync(User newUser);
    public List<User> GetUsers();
    public Task<User?> UpdateUserAsync(User userToUpdate);
    public Task<bool?> DeleteUserAsync(User userToDelete);
}

public class UserRepoTesting(IUserRepository repo) : IUserRepoTesting
{
    protected readonly IUserRepository _repo = repo;

    public async Task<User> CreateUserAsync(User newUser)
    {
        return await _repo.CreateUserAsync(newUser);
    }

    public async Task<bool?> DeleteUserAsync(User userToDelete)
    {
        return await _repo.DeleteUserAsync(userToDelete);
    }

    public List<User> GetUsers()
    {
        return _repo.GetUsers();
    }

    public async Task<User?> UpdateUserAsync(User userToUpdate)
    {
        return await _repo.UpdateUserAsync(userToUpdate);
    }
}