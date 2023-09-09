using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using fiap_store.Infraestructure;
using fiap_store.Validation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;
var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.DB_FIAP_STORE, config.GetValue<string>("ConnectionStrings:DB_FIAP_STORE")! },
            };

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<Program>();
    x.DisableDataAnnotationsValidation = true;
});
builder.Services.AddControllers();
builder.Services.AddScoped<IClienteService,ClienteService>();
builder.Services.AddScoped<IClienteRepository,ClienteRepository>();
builder.Services.AddScoped<IProdutoService,ProdutoService>();
builder.Services.AddScoped<IProdutoRepository,ProdutoRepository>();
builder.Services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
