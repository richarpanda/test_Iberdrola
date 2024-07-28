using Manticora.Application.Services;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Manticora.Application.Services;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHttpClient<ICharacterService, CharacterApiService>();
builder.Services.AddHttpClient<ILocationService, LocationApiService>();

builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<CharacterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
