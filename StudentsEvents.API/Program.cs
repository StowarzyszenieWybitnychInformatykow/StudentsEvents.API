using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentsEvents.API.DataModels;
using StudentsEvents.API.Models;
using StudentsEvents.API.Services;
using StudentsEvents.Library.Data;
using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.SampleData;
using System.Text;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = configuration["Auth:Jwt:Issuer"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["Auth:Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["Auth:Jwt:Audience"],
            ValidateLifetime = true
        };
    });


builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<EventDatabaseModel, EventModel>();
    config.CreateMap<EventModel, EventDatabaseModel>();
    config.CreateMap<TagDatabaseModel, TagModel>();
    config.CreateMap<TagModel, TagDatabaseModel>();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Students Events API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

//Data
//TODO: Change Singleton to Transient
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IEventData, SampleEventData>();
builder.Services.AddSingleton<ITagData, SampleTagData>();

//Services
builder.Services.AddSingleton<IEventDataManaging, EventDataManaging>();
builder.Services.AddSingleton<ITagDataManaging, TagDataManaging>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
