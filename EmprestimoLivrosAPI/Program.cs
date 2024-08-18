using EmprestimoLivrosAPI;
using EmprestimoLivrosAPI.Database;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using EmprestimoLivrosAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfraestructureSwagger();

var connectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<EmprestimoDbContext>(
        options => options.UseMySql(connectionString, serverVersion)
    );

builder.Services.AddScoped<IEntityRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IEntityRepository<Livro>, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddAutoMapper(typeof(MappingDTO));
    
var app = builder.Build();

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
