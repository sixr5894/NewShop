using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.AuthRepos
{
    public static class StartupExtentions
    {
        public static void SetAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                            ValidateIssuer = true,
                            ValidIssuer = JwtConfig.ISSUER,

                            ValidateAudience = true,
                            ValidAudience = JwtConfig.AUDIENCE,
                            ValidateLifetime = true,

                            IssuerSigningKey = JwtToken.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
            };
        });
        }
        public static void AddAuth(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
        }
    }
}
