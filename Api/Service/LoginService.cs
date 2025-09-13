using Isopoh.Cryptography.Argon2;

public interface ILoginService
{
    public User? LoginUserAsync(UserLoginDataDto userInfo);
}

public class LoginService(IUserRepository repo) : ILoginService
{
    IUserRepository _repo = repo;

    public User? LoginUserAsync(UserLoginDataDto userInfo)
    {
        User? foundUser = _repo.GetUsers().Find(user => user.Username == userInfo.Username);

        if (foundUser == null)
            return null;

        if (VerifyHashPassword(foundUser.Password, userInfo.Password) == false)
            return null;

        return foundUser;
    }

    private bool VerifyHashPassword(string hashedPassword, string inputedPassword)
    {
        return Argon2.Verify(hashedPassword, inputedPassword);
    }
}