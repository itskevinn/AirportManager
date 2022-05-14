using System.Reflection;
using Api.Filters;
using Application.Airport.Http.Profiles;
using AutoMapper;
using Infrastructure.Extensions;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var config = builder.Configuration;

builder.Services.AddControllers(opts => { opts.Filters.Add(typeof(AppExceptionFilterAttribute)); });
var mapperConfig = new MapperConfiguration(m =>
{
    var profiles = new List<Profile> { new AirlineProfile(), new CityProfile(), new FlightProfile() };
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
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.Load("Application"));
builder.Services.AddDbContext<PersistenceContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("local"),
        sqlOpts => { sqlOpts.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName")); });
});

builder.Services.AddHealthChecks().AddSqlServer(config["ConnectionStrings:local"]);

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

builder.Services.AddPersistence(config).AddServices();

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

app.UseCors(myAllowSpecificOrigins);
app.UseRouting();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();