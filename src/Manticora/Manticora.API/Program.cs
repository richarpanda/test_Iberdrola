using Manticora.Application.Services;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Repositories;
using Manticora.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Registrar clientes HTTP
builder.Services.AddHttpClient<ICharacterApiService, CharacterApiService>();
builder.Services.AddHttpClient<ILocationApiService, LocationApiService>();

// Registro de repositorios
builder.Services.AddScoped<IDefenderRepository, DefenderRepository>();
builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

// Registro de servicios
builder.Services.AddScoped<IDefenderService, DefenderService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddHttpClient<ILocationApiService, LocationApiService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Configuración de la base de datos
builder.Services.AddDbContext<ManticoraDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
