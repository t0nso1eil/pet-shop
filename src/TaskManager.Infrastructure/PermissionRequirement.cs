using Microsoft.AspNetCore.Authorization;
using TaskManager.Core.Enums;

namespace TaskManager.Infrastructure;

public class PermissionRequirement : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = [];
    public PermissionRequirement(Permission[] permissions)
    {
        Permissions = permissions;
    }
}