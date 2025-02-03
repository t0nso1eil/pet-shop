using PetShop.Core.Enums;

namespace PetShop.Core.Abstractions.Services;

public interface IPermissionService
{
    public Task<HashSet<Permission>> GetUserPermissions(Guid userId);
}