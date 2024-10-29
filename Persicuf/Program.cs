using DB.Data;
using Microsoft.EntityFrameworkCore;
using Servicios.Servicios;
using Servicios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersicufContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IColorServicio, ColorServicio>();
builder.Services.AddScoped<ICamperaServicio, CamperaServicio>();
builder.Services.AddScoped<ICorteCuelloServicio, CorteCuelloServicio>();
builder.Services.AddScoped<IDomicilioServicio, DomicilioServicio>();
builder.Services.AddScoped<IImagenServicio, ImagenServicio>();
builder.Services.AddScoped<ILargoServicio, LargoServicio>();
builder.Services.AddScoped<ILocalidadServicio, LocalidadServicio>();
builder.Services.AddScoped<IMangaServicio, MangaServicio>();
builder.Services.AddScoped<IMaterialServicio, MaterialServicio>();
builder.Services.AddScoped<IPantalonServicio, PantalonServicio>();
builder.Services.AddScoped<IPedidoPrendaServicio, PedidoPrendaServicio>();
builder.Services.AddScoped<IPedidoServicio, PedidoServicio>();
builder.Services.AddScoped<IPermisoServicio, PermisoServicio>();
builder.Services.AddScoped<IPrendaEstampadoServicio, PrendaEstampadoServicio>();
builder.Services.AddScoped<IPrendaServicio, PrendaServicio>();
builder.Services.AddScoped<IProvinciaServicio, ProvinciaServicio>();
builder.Services.AddScoped<IRemeraServicio, RemeraServicio>();
builder.Services.AddScoped<IRubroServicio, RubroServicio>();
builder.Services.AddScoped<ITalleAlfabeticoServicio, TalleAlfabeticoServicio>();
builder.Services.AddScoped<ITalleNumericoServicio, TalleNumericoServicio>();
builder.Services.AddScoped<IUbicacionServicio, UbicacionServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IZapatoServicio, ZapatoServicio>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PersicufContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
