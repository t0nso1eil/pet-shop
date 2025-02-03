using Microsoft.EntityFrameworkCore;
using PetShop.API.Extensions;
using PetShop.Application.Services;
using PetShop.Core.Abstractions.Authorization;
using PetShop.Core.Abstractions.Repositories;
using PetShop.Core.Abstractions.Services;
using PetShop.DataAccess;
using PetShop.DataAccess.Repositories;
using PetShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.Configure<AuthorizationOptions>(builder.Configuration.GetSection(nameof(AuthorizationOptions)));

builder.Services.AddDbContext<PetShopDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(PetShopDbContext)));
    });

builder.Services.AddScoped<IPetsService, PetsService>();
builder.Services.AddScoped<IPetsRepository, PetsRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
//builder.Services.AddScoped<IPermissionService, PermissionsService>();

//builder.Services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.AddMappedEndpoints();

app.Run();