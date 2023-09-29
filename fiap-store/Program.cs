using Application.Interfaces;
using Application.Interfaces.Token;
using Application.Repositories;
using Application.Services;
using fiap_store.Validation;
using FluentValidation.AspNetCore;
using Infrastructure.DbConnection;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;
var key = Encoding.ASCII.GetBytes(config.GetValue<string>("JWTSecret")!);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FiapStore", Version = "v1" });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    // Add JWT authentication support in Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Digite como o exemplo 'Bearer xxxxxx'",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    };
    c.AddSecurityRequirement(securityRequirement);
});

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

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddScoped<IClienteService,ClienteService>();
builder.Services.AddScoped<IClienteRepository,ClienteRepository>();

builder.Services.AddScoped<IProdutoService,ProdutoService>();
builder.Services.AddScoped<IProdutoRepository,ProdutoRepository>();

builder.Services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);

builder.Services.AddSingleton<LogErrorRepository>();

builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();


app.MapControllers();

app.Run();
