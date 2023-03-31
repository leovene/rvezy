using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RVezy.WebAPI.Middlewares;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RVezy.WebAPI.Infra.Data;
using RVezy.WebAPI.Domain.Interfaces;
using RVezy.WebAPI.Domain.Entities;
using RVezy.WebAPI.Infra.Repositories;
using RVezy.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqliteConnectionString")
          ?? "Data Source=maindatabase.db";

var secret = "FEA301A09CE7A864CF9D2A6C64A6D2E04546BAA6D94487A0E91C738A76F1A5A9";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });

// Add authorization
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
    .Build();
});

builder.Services.AddSqlite<MainContext>(connectionString);

builder.Services.AddScoped<ListingRepository>();
builder.Services.AddScoped<CalendarRepository>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<CSVParseService>();


var app = builder.Build();

await CheckDatabase(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>(secret);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


async Task CheckDatabase(IServiceProvider services)
{
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<MainContext>();

    await db.Database.MigrateAsync();
}
