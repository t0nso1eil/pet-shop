using PetShop.Core.Abstractions.Repositories;
using PetShop.Core.Abstractions.Services;
using PetShop.Core.Enums;

namespace PetShop.Application.Services;

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