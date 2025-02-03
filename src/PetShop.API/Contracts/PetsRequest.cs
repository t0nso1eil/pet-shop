namespace PetShop.API.Contracts;

public record PetsRequest(
    string Name,
    int Age,
    decimal Price);