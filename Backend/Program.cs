using Backend.Data;
using Backend.Models;
using Backend.Mappers;
using Backend.Interfaces;
using Backend.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Backend.Helpers;
using Backend.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAreaInvestigacaoRepository , AreaInvestigacaoRepository>();
builder.Services.AddScoped<ISubmissaoProjetoRepository, SubmissaoProjetoRepository>();
builder.Services.AddScoped<ICandidaturaRepository, CandidaturaRepository>();
builder.Services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
builder.Services.AddScoped<IAlunosProjetoRepository, AlunosProjetoRepository>();
builder.Services.AddScoped<IOrientadorRepository, OrientadorRepository>();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});




builder.Services.AddDbContext<ProjetoGestaoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = 
    options.DefaultChallengeScheme = 
    options.DefaultForbidScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"] 
    ?? throw new InvalidOperationException("JWTSettings:Key is missing")))
    };
});




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjetoGestaoContext>();
    try
    {
        Console.WriteLine("A começar o Seed...");
        DbSeeder.Seed(context);
        Console.WriteLine("Seed terminado.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Seed falhou: {ex.Message}");
    }
}

app.UseCors(MyAllowSpecificOrigins);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();