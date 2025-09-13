using Isopoh.Cryptography.Argon2;

public interface IRegisterService
{
    public Task<User?> RegisterUserAsync(UserLoginDataDto userInfo);
}

public class RegisterService(IUserRepository repo) : IRegisterService
{
    IUserRepository _repo = repo;

    public async Task<User?> RegisterUserAsync(UserLoginDataDto userInfo)
    {
        if (_repo.GetUsers().Exists(user => user.Username == userInfo.Username))
            return null;

        User newUser = new()
        {
            Name = userInfo.Name,
            Username = userInfo.Username,
            Password = HashPassword(userInfo.Password),
            Role = UserRoles.User
        };

        return await _repo.CreateUserAsync(newUser);
    }

    private string HashPassword(string rawPassword)
    {
        return Argon2.Hash(rawPassword);
    }
}