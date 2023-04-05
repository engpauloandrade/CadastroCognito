using Cadastro.Application.Contracts;
using Cadastro.Application.Services.Gravacao;
using Cadastro.Domain;
using Cadastro.Persistence.Contextos;
using Cadastro.Persistence.Contracts;
using Cadastro.Persistence.Persistencia;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("SQLserver");

//builder.Services.AddDbContext<IDataContext, DataContext>(options =>
//    options.UseSqlServer(connection)
//);


builder.Services.AddDbContext<IDataContext, DataContext>(options =>
    options.UseSqlServer(connection, b => b.MigrationsAssembly("Cadastro.Persistence"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();


builder.Services.AddScoped<IPersistenciaDinamica<Usuario>, PersistenciaDinamica<Usuario>>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();


builder.Services.AddScoped<IPersistenciaDinamica<Usuario>, PersistenciaDinamica<Usuario>>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
