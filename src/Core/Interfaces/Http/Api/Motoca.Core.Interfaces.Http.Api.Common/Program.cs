using Microsoft.Extensions.FileProviders;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.IoC.Middlewares;
using CoreIoC = Motoca.Core.Infrastructure.IoC.CoreStartupDependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGlobalExceptionHandlerMiddleware();
builder.Services.AddMediatR(p => p.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
CoreIoC.AddAuthenticationAndAuthorization(builder.Services);
CoreIoC.AddDependencyInjection(builder.Services);
    
var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine("", EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH"))),
    RequestPath = "/assets"
});

app.UseGlobalExceptionHandlerMiddleware();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

public class CoreApi : Program {}