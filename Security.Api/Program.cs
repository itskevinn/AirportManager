using System.Reflection;
using System.Text;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Security.Api.Utils.Extensions;
using Security.Api.Utils.Filters;
using Security.Application.Http.Dto;
using Security.Infrastructure.Core.Helpers;
using Security.Infrastructure.Persistence.Context;
using Security.Infrastructure.Security.Jwt;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var config = builder.Configuration;

builder.Services.AddControllers(opts => { opts.Filters.Add(typeof(AppExceptionFilterAttribute)); });

builder.Services.AddEndpointsApiExplorer().AddMappings();
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
        { securityScheme, Array.Empty<string>() }
    });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Security Api", Version = "v1" });
});
builder.Services.AddAutoMapper(Assembly.Load("Security.Application"));

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

builder.Services.AddPersistence(config).AddServices();

builder.Services.AddAuthorization();

var appSettingsSection = config.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
builder.Services.AddSingleton<AppSettings>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
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

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddDbContext<SecurityContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("local"),
        sqlOpts =>
        {
            sqlOpts.MigrationsHistoryTable("_MigrationHistory",
                config.GetValue<string>("SchemaName"));
        });
}, ServiceLifetime.Singleton);


builder.Services.AddScoped(typeof(IJwtUtils), typeof(JwtUtils));

builder.Services.AddDefaultAWSOptions(config.GetAWSOptions());
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddHttpContextAccessor();

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true,
    reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        $"AppLogs/Api-{DateTime.Now.Year}-" +
        $"{DateTime.Now.Month}-{DateTime.Now.Day}-" +
        $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-" +
        $"{DateTime.Now.Second}-{DateTime.Now.Millisecond}.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Security Api"); }
    );
}

//Apply migrations automatically
var context = app.Services.GetRequiredService<SecurityContext>();
if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}

app.UseMiddleware<JwtMiddleware<UserDto>>();
app.UseCors(myAllowSpecificOrigins);
app.UseRouting();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();