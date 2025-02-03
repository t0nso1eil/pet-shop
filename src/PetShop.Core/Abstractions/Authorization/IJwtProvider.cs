using PetShop.Core.Models;

namespace PetShop.Core.Abstractions.Authorization;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}