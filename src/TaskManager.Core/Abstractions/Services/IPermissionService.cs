using TaskManager.Core.Enums;

namespace TaskManager.Core.Abstractions.Services;

public interface IPermissionService
{
    public Task<HashSet<Permission>> GetUserPermissions(Guid userId);
}