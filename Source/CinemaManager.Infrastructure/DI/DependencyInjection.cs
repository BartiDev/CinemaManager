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

namespace CinemaManager.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddAuth(services);

            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddAuth(IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddOptions<JwtSettings>()
                .BindConfiguration(JwtSettings.SectionName);
        }
    }
}
