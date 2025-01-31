using Microsoft.EntityFrameworkCore;
using ssi.API.Interfaces;
using ssi.API.Models;
using ssi.API.Repository;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner

// Adicionar DbContext
builder.Services.AddDbContext<ssiContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)));
});

// Adicionar reposit�rio de Acompanhar
builder.Services.AddScoped<IAcompanhar, AcompanharRepository>();

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
