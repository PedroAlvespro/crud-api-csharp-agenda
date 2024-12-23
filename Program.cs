using System.Text;
using Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


// Adicione este código dentro do método ConfigureServices em sua classe Program.cs ou Startup.cs
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero // Define tolerância de tempo zero para expiração do token
    };
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
