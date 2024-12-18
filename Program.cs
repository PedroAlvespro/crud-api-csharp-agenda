using Context;
using Microsoft.EntityFrameworkCore;
using TRIMAPAPI.Context;
using TRIMAPAPI.Repositories;
using TRIMAPAPI.Repositories.Interfaces;
using TRIMAPAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

//adicionar o Jwt

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LinhaContext>(option  =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadraoLinha"));
});

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddScoped<ContatoService>(); //DI - Adicionando no Scopo novas instâncias de Contato

// Registrar o repositório no DI
builder.Services.AddScoped<ILinhaRepository, LinhaRepository>();


// Registrar o serviço no DI
builder.Services.AddScoped<LinhaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); /*mapeamento, para que saiba onde estão os controllers*/
app.Run();
