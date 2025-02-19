using Microsoft.EntityFrameworkCore;
using ssi.API.Interfaces;
using ssi.API.Models;
using ssi.API.Repository;
using Microsoft.AspNetCore.Builder;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using ssi.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner

// Adicionar DbContext
builder.Services.AddDbContext<ssiContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)));
});

// Adicionar reposit�rio de Acompanhar
builder.Services.AddScoped<IAcompanhar, AcompanharRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<AuthService>();


// Configurar autentica��o JWT
var chave = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(chave)
        };
    });

// Adicionar controladores
builder.Services.AddControllers();

// Configura��o do Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear os controladores da API
app.MapControllers();

app.Run();
