using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Services;

// Formato numérico consistente (punto decimal) sin importar la configuración regional del equipo.
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // Evita que propiedades no nulables (p. ej. la navegación Categoria) se marquen como obligatorias.
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddDbContext<TechStoreDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Inversión de Control + Inyección de Dependencias:
// los controladores dependen de interfaces y el contenedor decide qué implementación entregar.
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

// Aplica las migraciones pendientes (crea la base de datos si no existe) y carga datos iniciales.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TechStoreDbContext>();
    await context.Database.MigrateAsync();
    await DbSeeder.SeedAsync(context);
}

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
