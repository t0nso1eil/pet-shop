namespace TaskManager.Core.Models;

public class Pet
{
    private const int MIN_NAME_LENGTH = 2;
    private const int MAX_NAME_LENGTH = 20;
    
    private Pet(Guid id, string name, int age, decimal price)
    {
        Id = id;
        Name = name;
        Age = age;
        Price = price;
    } 
    
    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public int Age { get; }
    public decimal Price { get; }

    public static (Pet Pet, string Error) Create(Guid id, string name, int age, decimal price)
    {
        var error = string.Empty;
        if (string.IsNullOrEmpty(name) || name.Length < MIN_NAME_LENGTH || name.Length > MAX_NAME_LENGTH)
        {
            error = "Name must be between 2 and 20 characters long.";
        }
        var pet = new Pet(id, name, age, price);
        return (pet, error);
    }
    
    
}