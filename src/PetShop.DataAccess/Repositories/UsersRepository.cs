using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PetShop.Core.Abstractions;
using PetShop.Core.Abstractions.Repositories;
using PetShop.Core.Enums;
using PetShop.Core.Models;
using PetShop.DataAccess.Entities;

namespace PetShop.DataAccess.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly PetShopDbContext _context;
    public UsersRepository(PetShopDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(User user)
    {
        var roleEntity = await _context.Roles
            .SingleOrDefaultAsync(r => r.Id == (int)Role.User)
            ?? throw new InvalidOperationException();
        
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Roles = [roleEntity]
        };
        
        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
        return user.Id;
    }
    
    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
        var user = User.Create(userEntity.Id, userEntity.Username, userEntity.PasswordHash, userEntity.Email);
        return user;
    }

    public async Task<HashSet<Permission>> GetPermissions(Guid userId)
    {
        var roles = await _context.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();
        
        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permission)p.Id)
            .ToHashSet();
    }
}