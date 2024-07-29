using Manticora.Application.Services;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ICharacterService, CharacterApiService>();
builder.Services.AddHttpClient<ILocationService, LocationApiService>();

builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<CharacterService>();

var app = builder.Build();

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