using System.Reflection;
using System.Text;
using Api.Extensions;
using Api.Filters;
using Api.Middleware;
using Application.Http.Profiles;
using AutoMapper;
using Infrastructure.Core;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers(opts => { opts.Filters.Add(typeof(AppExceptionFilterAttribute)); });
var mapperConfig = new MapperConfiguration(m =>
{
    var profiles = new List<Profile>
    {
        new AirlineProfile(),
        new CityProfile(),
        new FlightProfile()
    };
    m.AddProfiles(profiles);
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        corsPolicyBuilder => { corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});
builder.Services.AddSwaggerGen(c =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});
builder.Services.AddAutoMapper(Assembly.Load("Application"));
builder.Services.AddDbContext<PersistenceContext>(opt =>
{
    opt.UseSqlServer(SecretsService.GetValue("db-string-conn"),
        sqlOpts => { sqlOpts.MigrationsHistoryTable("_MigrationHistory"); });
}, ServiceLifetime.Singleton);
builder.Services.AddHealthChecks().AddSqlServer(SecretsService.GetValue("db-string-conn"));

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

builder.Services.AddPersistence(SecretsService.GetValue("db-string-conn")).AddServices().AddScopedServices();
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var key = Encoding.ASCII.GetBytes(SecretsService.GetValue("secret"));
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
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "Airport Api", Version = "v1" }); });

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File($"AppLogs/Api-{DateTime.Now.Millisecond}.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airport Api"));
}

//Apply migrations automatically
var context = app.Services.GetRequiredService<PersistenceContext>();
if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}

app.UseMiddleware<JwtMiddleware>();
app.UseCors(myAllowSpecificOrigins);
app.UseRouting();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();