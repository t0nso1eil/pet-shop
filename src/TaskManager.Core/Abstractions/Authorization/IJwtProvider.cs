using TaskManager.Core.Models;

namespace TaskManager.Core.Abstractions.Authorization;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}