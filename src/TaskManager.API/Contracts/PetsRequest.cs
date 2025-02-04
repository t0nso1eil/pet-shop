namespace TaskManager.API.Contracts;

public record PetsRequest(
    string Name,
    int Age,
    decimal Price);