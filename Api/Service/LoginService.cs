using Isopoh.Cryptography.Argon2;

public interface ILoginService
{
    public bool LoginUserAsync(UserDataDto userInfo);
}

public class LoginService(IUserRepository repo) : ILoginService
{
    IUserRepository _repo = repo;

    public bool LoginUserAsync(UserDataDto userInfo)
    {
        User? foundUser = _repo.GetUsers().Find(user => user.Username == userInfo.Username);

        if (foundUser == null)
            return false;

        if (VerifyHashPassword(foundUser.Password, userInfo.Password) == false)
            return false;

        return true;
    }

    private bool VerifyHashPassword(string hashedPassword, string inputedPassword)
    {
        return Argon2.Verify(hashedPassword, inputedPassword);
    }
}