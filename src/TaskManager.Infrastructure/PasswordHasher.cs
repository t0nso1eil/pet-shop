using TaskManager.Core.Abstractions.Authorization;

namespace TaskManager.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
}