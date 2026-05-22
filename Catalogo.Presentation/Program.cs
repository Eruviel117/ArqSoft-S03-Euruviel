using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Rutas JSON
var jsonPath = Path.Combine(
    builder.Environment.ContentRootPath, "Controllers", "Data", "items.json");
var usuariosPath = Path.Combine(
    builder.Environment.ContentRootPath, "Controllers", "Data", "usuarios.json");

// Repositorios y servicios
builder.Services.AddSingleton<IItemRepository>(new JsonItemRepository(jsonPath));
builder.Services.AddScoped<ItemService>();
builder.Services.AddSingleton<UsuarioService>(new UsuarioService(usuariosPath));

// Sesiones
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();