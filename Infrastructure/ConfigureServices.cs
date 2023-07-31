using Application.Common.Interfaces;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        /// <summary>
        /// Adds infrastructure services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> containing the configuration settings.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Adds the AuditableEntitySaveChangesInterceptor as a scoped service
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            // Registers the AppDbContext as a service with the specified connection string
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("defaultConnectionString")));

            // Registers IApplicationDbContext as a scoped service, using the AppDbContext implementation
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            // Configures identity services using AppUser and AppRole, with AppDbContext as the store
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            // Adds the AppDbContextInitialiser as a scoped service
            services.AddScoped<AppDbContextInitialiser>();

            // Adds DateTimeService as a transient service for providing current date and time
            services.AddTransient<IDatetime, DateTimeService>();

            //// Register EmailService and TelegramService as scoped services
            //services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<ITelegramService, TelegramService>();
            services.AddScoped<ICurrentUser, CurrentUserService>();


            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidAudience = configuration.GetSection("TokenOptions:Audience").Value,
            //        ValidIssuer = configuration.GetSection("TokenOptions:Issuer").Value,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("TokenOptions:SecurityKey").Value)),
            //        ClockSkew = TimeSpan.Zero,
            //        ValidateIssuerSigningKey = true,
            //    };
            //});

            return services;
        }
    }
}
