using ERP.Application;
using ERP.Application.Interfaces;
using ERP.Domain.Entities.User;
using ERP.Infrastructure.Persistence;
using ERP.Infrastructure.Persistence.Contaxt;
using ERP.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
namespace ERP.Infrastructure.IocConfig;

public static class IdentityServices
{
    public static IServiceCollection AddIdentityServies(this IServiceCollection Services)
    {
        Services.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddUserManager<UserManager<ApplicationUser>>()
        .AddRoleManager<RoleManager<ApplicationRole>>().AddEntityFrameworkStores<WriteDbContext>();
        
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        string jwtKey = config["Jwt:SecretKey"];
        string Issuer = config["Jwt:ValidIssuer"];


        Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Issuer",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jwtKey")),

            };
        });

        Services.AddCors(option =>
        {
            option.AddPolicy("EnableCors", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .Build();


            });
        });
        Services.AddAuthorization(option =>
        {
            // PremiumUser  SpecialAccess

            option.AddPolicy("PremiumUser", policy =>
            {
                policy.RequireClaim("SpecialAccess");
            });
        });


      

        return Services;
    }
}

public static class AuditServices
{
    public static IServiceCollection AddAuditServies(this IServiceCollection Services)
    {

        Services.AddHttpContextAccessor();
        Services.AddScoped<IUserContextService, UserContextService>();
        Services.AddScoped<IAuditService, AuditService>();

        return Services;
    }
}