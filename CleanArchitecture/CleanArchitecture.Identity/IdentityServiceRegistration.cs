using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Configurations;
using CleanArchitecture.Identity.Models;
using CleanArchitecture.Identity.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


            var configurations = new ConfigurationBuilder()
            .SetBasePath("C:\\Users\\camil\\OneDrive\\Documentos\\GitHub\\udemy-c-\\CleanArchitecture\\CleanArchitecture.API")
            .AddJsonFile("appSettings.json")
            .Build();


           configurations.GetSection("ConnectionStrings")["IdentityConnectionString"]= "Data Source=SQL2019\\DLLO,14333;Initial Catalog=SEGURIDAD;User ID=practica;Password=practica;TrustServerCertificate=True";


            var resultado = configuration.GetConnectionString("IdentityConnectionString");
            var resultado2 = configurations.GetConnectionString("IdentityConnectionString");


            services.AddDbContext<CleanArchitectureIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"),
                b => b.MigrationsAssembly(typeof(CleanArchitectureIdentityDbContext).Assembly.FullName)));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleanArchitectureIdentityDbContext>().AddDefaultTokenProviders();


            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };

            });


            return services;

        }
    }
}
