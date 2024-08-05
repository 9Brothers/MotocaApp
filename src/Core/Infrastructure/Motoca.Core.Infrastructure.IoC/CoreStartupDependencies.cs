using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Motoca.Core.Domain.Interfaces.Repositories;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.Database.Contexts;
using Motoca.Core.Infrastructure.Database.Repositories;
using Motoca.Core.Infrastructure.Database.UoW;

namespace Motoca.Core.Infrastructure.IoC;

public static class CoreStartupDependencies
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        AddRepositories(services);
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<CoreReadContext>();
        services.AddDbContext<CoreWriteContext>();
        services.AddScoped<ICoreWriteUnitOfWork, CoreWriteUnitOfWork>();
        services.AddScoped<ICoreReadUnitOfWork, CoreReadUnitOfWork>();
        services.AddScoped<ICoreReaderConnection, CoreReaderConnection>();
        services.AddScoped<IAdministratorRepository, AdministratorRepository>();
    }
    
    public static void AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        var secret = EnvironmentUtils.TryGetEnvironmentVariable("JWT_SECRET");

        var secretBytes = Encoding.ASCII.GetBytes(secret);         

        services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(a =>
            {                
                a.RequireHttpsMetadata = false;
                a.SaveToken = true;
                a.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromHours(12)
                };
            });

        services.AddAuthorization(o =>
        {
            o.AddPolicy("Administrator", p => p.RequireClaim("Administrator"));
            o.AddPolicy("Deliveryman", p => p.RequireClaim("Deliveryman"));
        });
    }
}
