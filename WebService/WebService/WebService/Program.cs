using AutoMapper;
using Business;
using Business.Automapper;
using HealthChecks.UI.Client;
using WatchDog;
using WebService.Modules.Authentication;
using WebService.Modules.HealthChecks;
using WebService.Modules.injection;
using WebService.Modules.Mapper;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
// AutoMapper
builder.Services.AddMapper();

builder.Services.AddVersioning();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDogServices(options =>
{
    options.SetExternalDbConnString = "Server=192.168.146.44;Database=postgres;UserId=UserLogs;Password=@Mc2fxLcHWs$d46N";
    options.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.PostgreSql;
    options.IsAutoClear = true;
    options.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Quarterly;
});


//Authentication
builder.Services.AddAuthenticationExtensions(builder.Configuration);
builder.Services.AddBusinessServices();

var app = builder.Build();



// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebService API");
    c.RoutePrefix = string.Empty; // Esto hace que la página de Swagger sea la predeterminada al iniciar la aplicación
});
app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecksUI();

app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
    conf.Blacklist = "health, healthchecks-ui, ui/resources/healthchecksui-min.css, ui/resources/healthchecks-bundle.js, ui/resources/vendors-dll.js, healthchecks-api/ui-settings, healthchecks-api, healthchecks-webhooks, healthchecks-ui#/healthchecks";
});
app.MapControllers();
app.UseEndpoints(_ => { });

app.Run();
