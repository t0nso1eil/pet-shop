namespace PetShop.API.Contracts;
public record RegisterRequest(
    string Username,
    string Email,
    string Password);