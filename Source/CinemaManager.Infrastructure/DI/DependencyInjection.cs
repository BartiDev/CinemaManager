using CinemaManager.Application.Authentication.Persistence.Repositories;
using CinemaManager.Application.Common.Interfaces.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using CinemaManager.Infrastructure.Authentication;
using CinemaManager.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CinemaManager.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            AddAuth(services, configuration);

            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddAuth(IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddAuthentication();

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });
        }
    }
}
