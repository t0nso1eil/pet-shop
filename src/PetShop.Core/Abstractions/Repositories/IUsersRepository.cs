using PetShop.Core.Enums;
using PetShop.Core.Models;

namespace PetShop.Core.Abstractions.Repositories;

public interface IUsersRepository
{
    public Task<Guid> Create(User user);
    public Task<User> GetByEmail(string email);
    public Task<HashSet<Permission>> GetPermissions(Guid userId);
}