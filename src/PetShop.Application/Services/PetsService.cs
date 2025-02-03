using PetShop.Core.Abstractions.Repositories;
using PetShop.Core.Abstractions.Services;
using PetShop.Core.Models;

namespace PetShop.Application.Services;

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