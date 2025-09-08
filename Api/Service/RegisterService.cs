using Isopoh.Cryptography.Argon2;

public interface IRegisterService
{
    public Task<User> RegisterUserAsync(UserRegisterDto userInfo);
}

public class RegisterService(IUserRepository repo) : IRegisterService
{
    IUserRepository _repo = repo;

    public async Task<User> RegisterUserAsync(UserRegisterDto userInfo)
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