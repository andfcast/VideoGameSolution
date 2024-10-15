using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using VideoGameApp.Application;
using VideoGameApp.Infrastructure.Context;
using VideoGameApp.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IVideojuegoRepository, VideojuegoRepository>();
builder.Services.AddTransient<IRankingRepository, RankingRepository>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
builder.Services.AddTransient<IValidator<RegistroUsuarioDto>, RegistroUsuarioDtoValidator>();
builder.Services.AddTransient<IValidator<VideojuegoDto>, VideojuegoDtoValidator>();
builder.Services.AddTransient<IValidator<RankingRequestDto>, RankingRequestDtoValidator>();
builder.Services.AddDbContext<VideoGameStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"))
);

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters { 
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
