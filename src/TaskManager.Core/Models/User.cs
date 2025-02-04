namespace TaskManager.Core.Models;

public class User
{
    private User(Guid id, string username, string passwordHash, string email)
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
    }
    
    public Guid Id { get; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }

    public static User Create(Guid id, string username, string passwordHash, string email)
    {
        return new User(id, username, passwordHash, email);
    }
}