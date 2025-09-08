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
            Password = userInfo.Password,
            IsAdmin = false
        };

        return await _repo.CreateUserAsync(newUser);
    }
}