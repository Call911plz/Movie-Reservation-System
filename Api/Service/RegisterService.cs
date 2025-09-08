using Isopoh.Cryptography.Argon2;

public interface IRegisterService
{
    public Task<User> RegisterUserAsync(UserDataDto userInfo);
}

public class RegisterService(IUserRepository repo) : IRegisterService
{
    IUserRepository _repo = repo;

    public async Task<User> RegisterUserAsync(UserDataDto userInfo)
    {
        User newUser = new User()
        {
            Name = userInfo.Name,
            Username = userInfo.Username,
            Password = HashPassword(userInfo.Password),
            IsAdmin = false
        };

        return await _repo.CreateUserAsync(newUser);
    }

    private string HashPassword(string rawPassword)
    {
        return Argon2.Hash(rawPassword);
    }
}