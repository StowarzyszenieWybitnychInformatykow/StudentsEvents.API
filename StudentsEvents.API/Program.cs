using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentsEvents.Library.Models;
using StudentsEvents.Library.Services;
using StudentsEvents.Library.Data;
using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.DBEntityModels;
using StudentsEvents.Library.Models;
using System.Text;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = configuration["Issuer"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration["Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["Audience"],
            ValidateLifetime = true
        };
    });

builder.Services.AddDbContext<StudentsEventsDataDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("StudentsEventsDataDb")));


builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<EventDatabaseModel, EventModel>();
    config.CreateMap<EventModel, EventDatabaseModel>();
    config.CreateMap<TagDatabaseModel, TagModel>();
    config.CreateMap<TagModel, TagDatabaseModel>();
    config.CreateMap<Event, EventDatabaseModel>();
    config.CreateMap<Tag, TagDatabaseModel>();
    config.CreateMap<Event, EventModel>();
    config.CreateMap<Tag, TagModel>();
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
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IEventData, EventData>();
builder.Services.AddScoped<ITagData, TagData>();
builder.Services.AddScoped<ITagEventData, TagEventData>();

//Services
builder.Services.AddScoped<IEventDataManaging, EventDataManaging>();
builder.Services.AddScoped<ITagDataManaging, TagDataManaging>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
