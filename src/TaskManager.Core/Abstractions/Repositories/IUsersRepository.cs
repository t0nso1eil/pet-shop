using TaskManager.Core.Enums;
using TaskManager.Core.Models;

namespace TaskManager.Core.Abstractions.Repositories;

public interface IUsersRepository
{
    public Task<Guid> Create(User user);
    public Task<User> GetByEmail(string email);
    public Task<HashSet<Permission>> GetPermissions(Guid userId);
}