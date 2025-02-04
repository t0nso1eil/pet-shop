using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Abstractions.Services;
using TaskManager.API.Contracts;

namespace TaskManager.API.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);

        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> Register(
        [FromBody] RegisterRequest request,
        IUsersService usersService)
    {
        await usersService.Register(request.Username, request.Email, request.Password);

        return Results.Ok();
    }

    private static async Task<IResult> Login(
        [FromBody] LoginRequest request,
        IUsersService usersService,
        HttpContext context)
    {
        var token = await usersService.Login(request.Email, request.Password);

        context.Response.Cookies.Append("tasty-cookies", token);

        return Results.Ok();
    }
}