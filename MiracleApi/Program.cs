using Abstract.Services;
using Abstract.Services.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using static MiracleApi.Controllers.UserController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

//builder.Services.AddDbContext<ApplicationContext>(options => { options.UseNpgsql(builder.Configuration["MiracleApi:NpgSqlString"]); });
builder.Services.AddDbContext<ApplicationContext>(options => { options.UseNpgsql("Host=45.8.96.144;Database=MiracleAppDB;Username=mira31;Password=G0K/>/F~Kvg8#:"); });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IRibbonService, RibbonService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<CommentsRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<LessonRepository>();
builder.Services.AddScoped<NewsRepository>();
builder.Services.AddScoped<MailRepository>();
builder.Services.AddScoped<RibbonRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = false,
            //
            RequireExpirationTime = false,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();