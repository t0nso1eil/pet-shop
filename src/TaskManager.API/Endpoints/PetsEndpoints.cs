using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Extensions;
using TaskManager.Core.Abstractions.Services;
using TaskManager.Core.Enums;
using TaskManager.Core.Models;
using TaskManager.API.Contracts;

namespace TaskManager.API.Endpoints;

public static class PetsEndpoints
{
    public static IEndpointRouteBuilder MapPetsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("pets", GetPets);
        app.MapPost("pets", CreatePet).RequirePermissions(Permission.Create);
        app.MapPut("pets/{id:guid}", UpdatePet).RequirePermissions(Permission.Update);
        app.MapDelete("pets/{id:guid}", DeletePet).RequirePermissions(Permission.Delete);

        return app;
    }
    
    private static async Task<IResult> GetPets(IPetsService petsService)
    {
        var pets = await petsService.GetAllPets();
        var response = pets.Select(p => new PetsResponse(p.Id, p.Name, p.Age, p.Price)).ToList();
        return Results.Ok(response);
    }
    
    private static async Task<IResult> CreatePet([FromBody] PetsRequest request, IPetsService petsService)
    {
        var (pet, error) = Pet.Create(
            Guid.NewGuid(),
            request.Name,
            request.Age,
            request.Price
        );
        if (!string.IsNullOrEmpty(error))
        {
            return Results.BadRequest(error);
        }
        
        var petId = await petsService.CreatePet(pet);

        return Results.Ok(petId);
    }
    
    private static async Task<IResult> UpdatePet(Guid id, [FromBody] PetsRequest request, IPetsService petsService)
    {
        var petId = await petsService.UpdatePet(id, request.Name, request.Age, request.Price);
        return Results.Ok(petId);
    }
    
    private static async Task<IResult> DeletePet(Guid id, IPetsService petsService)
    {
        var petId = await petsService.DeletePet(id);
        return Results.Ok(petId);
    }
}