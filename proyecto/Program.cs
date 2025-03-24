using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Services; // Asegúrate de incluir este namespace
using proyecto.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar los servicios
builder.Services.AddScoped<EquipoService>(); // Servicio para los equipos
builder.Services.AddScoped<TecnicoService>(); // Servicio para los técnicos
builder.Services.AddScoped<UsuarioService>(); // Servicio para los usuarios

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
