namespace PetShop.API.Contracts;

public record PetsResponse(
    Guid Id,
    string Name,
    int Age,
    decimal Price);