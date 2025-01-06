using System.Text;
using Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.IdentityModel.Tokens;
using TRIMAPAPI.Context;
using TRIMAPAPI.recordsUser;
using TRIMAPAPI.Repositories;
using TRIMAPAPI.Repositories.Interfaces;
using TRIMAPAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();

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




// Adicione a autorização
builder.Services.AddAuthorization();

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddScoped<ContatoService>(); //DI - Adicionando no Scopo novas instâncias de Contato

// Registrar o repositório no DI
builder.Services.AddScoped<ILinhaRepository, LinhaRepository>();


// Registrar o serviço no DI
builder.Services.AddScoped<LinhaService>();


var app = builder.Build();
app.MapGet("/", (TokenService service) 
    => service.GerarTokenUsuario(new Users(1, 
    "TestEncoder@gmail.com",
    "1321",
    "student", // Adiciona o parâmetro 'Roles'
    new[] { "student", "premium" })));




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

// No método `app.Use` para middleware (normalmente em Program.cs ou Startup.cs)
app.UseAuthentication();
app.UseAuthorization();
