using TaskManager.Core.Abstractions.Repositories;
using TaskManager.Core.Abstractions.Services;
using TaskManager.Core.Enums;

namespace TaskManager.Application.Services;

public class PermissionsService : IPermissionService
{
    private readonly IUsersRepository _usersRepository;

    public PermissionsService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<HashSet<Permission>> GetUserPermissions(Guid userId)
    {
        return await _usersRepository.GetPermissions(userId);
    }
}