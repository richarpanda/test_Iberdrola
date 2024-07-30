using Manticora.Application.Services;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Repositories;
using Manticora.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Registrar clientes HTTP
builder.Services.AddHttpClient<ICharacterApiService, CharacterApiService>();
builder.Services.AddHttpClient<ILocationApiService, LocationApiService>();

// Registro de repositorios
builder.Services.AddScoped<IDefenderRepository, DefenderRepository>();
builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

// Registro de servicios
builder.Services.AddScoped<IDefenderService, DefenderService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();

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
