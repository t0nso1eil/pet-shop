using Microsoft.AspNetCore.Authorization;
using PetShop.Core.Enums;

namespace PetShop.Infrastructure;

public class PermissionRequirement : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = [];
    public PermissionRequirement(Permission[] permissions)
    {
        Permissions = permissions;
    }
}