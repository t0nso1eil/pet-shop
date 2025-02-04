namespace TaskManager.API.Contracts;
public record RegisterRequest(
    string Username,
    string Email,
    string Password);