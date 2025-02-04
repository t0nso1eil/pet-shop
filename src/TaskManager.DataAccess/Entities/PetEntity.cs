namespace TaskManager.DataAccess.Entities;

public class PetEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public decimal Price { get; set; }
}