using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskManager.DataAccess.Configurations;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess;

public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options, IOptions<AuthorizationOptions> authOptions) : DbContext(options)
{
    public DbSet<PetEntity> Pets { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
    }
}