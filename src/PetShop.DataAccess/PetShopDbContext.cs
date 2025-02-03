using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PetShop.DataAccess.Configurations;
using PetShop.DataAccess.Entities;

namespace PetShop.DataAccess;

public class PetShopDbContext(DbContextOptions<PetShopDbContext> options, IOptions<AuthorizationOptions> authOptions) : DbContext(options)
{
    public DbSet<PetEntity> Pets { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetShopDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
    }
}