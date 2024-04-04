using LegacyApp;

namespace LegacyAppTests;

public class FakeUserRepository
{
    private readonly List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }
    public void Clear()
    {
        _users.Clear();
    }
}