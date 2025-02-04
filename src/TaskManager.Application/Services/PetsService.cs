using TaskManager.Core.Abstractions.Repositories;
using TaskManager.Core.Abstractions.Services;
using TaskManager.Core.Models;

namespace TaskManager.Application.Services;

public class PetsService : IPetsService
{
    private readonly IPetsRepository _petsRepository;
    public PetsService(IPetsRepository petShopRepository)
    {
        _petsRepository = petShopRepository;
    }

    public async Task<List<Pet>> GetAllPets()
    {
        return await _petsRepository.GetAll();
    }

    public async Task<Guid> CreatePet(Pet pet)
    {
        return await _petsRepository.Create(pet);
    }

    public async Task<Guid> UpdatePet(Guid id, string name, int age, decimal price)
    {
        return await _petsRepository.Update(id, name, age, price);
    }

    public async Task<Guid> DeletePet(Guid id)
    {
        return await _petsRepository.Delete(id);
    }
}