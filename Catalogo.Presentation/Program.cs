using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ruta del archivo JSON — se guarda en la carpeta "data" del proyecto
var jsonPath = Path.Combine(
    builder.Environment.ContentRootPath, "Controllers", "Data", "items.json");

// Registrar el repositorio JSON como implementación de IItemRepository
builder.Services.AddSingleton<IItemRepository>(
    new JsonItemRepository(jsonPath)
);

// Registrar el servicio de Application
builder.Services.AddScoped<ItemService>();

// Agregar soporte para controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();