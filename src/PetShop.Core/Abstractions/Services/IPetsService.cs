using PetShop.Core.Models;

namespace PetShop.Core.Abstractions.Services;

public interface IPetsService
{
    public Task<List<Pet>> GetAllPets();
    public Task<Guid> CreatePet(Pet pet);
    public Task<Guid> UpdatePet(Guid id, string name, int age, decimal price);
    public Task<Guid> DeletePet(Guid id);
}