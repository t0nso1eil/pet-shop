using TaskManager.Core.Models;

namespace TaskManager.Core.Abstractions.Repositories;

public interface IPetsRepository
{
    public Task<List<Pet>> GetAll();
    public Task<Guid> Create(Pet pet);
    public Task<Guid> Update(Guid id, string name, decimal age, decimal price);
    public Task<Guid> Delete(Guid id);
}