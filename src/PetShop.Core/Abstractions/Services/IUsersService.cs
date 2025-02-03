using PetShop.Core.Enums;

namespace PetShop.Core.Abstractions.Services;

public interface IUsersService
{
    public Task<Guid> Register(string username, string email, string password);
    public Task<string> Login(string email, string password);
}