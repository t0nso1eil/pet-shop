using Microsoft.EntityFrameworkCore;
using PetShop.Core.Abstractions.Repositories;
using PetShop.Core.Models;
using PetShop.DataAccess.Entities;

namespace PetShop.DataAccess.Repositories;

public class PetsRepository : IPetsRepository
{
    private readonly PetShopDbContext _context;
    public PetsRepository(PetShopDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pet>> GetAll()
    {
        var petEntities = await _context.Pets
            .AsNoTracking()
            .ToListAsync();
        var pets = petEntities
            .Select(p => Pet.Create(p.Id, p.Name, p.Age, p.Price).Pet)
            .ToList();
        return pets;
    }
    
    public async Task<Guid> Create(Pet pet)
    {
        var petEntity = new PetEntity
        {
            Id = pet.Id,
            Name = pet.Name,
            Age = pet.Age,
            Price = pet.Price
        };
        await _context.Pets.AddAsync(petEntity);
        await _context.SaveChangesAsync();
        return petEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, decimal age, decimal price)
    {
        await _context.Pets
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, name)
                .SetProperty(p => p.Age, age)
                .SetProperty(p => p.Price, price));
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Pets
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}