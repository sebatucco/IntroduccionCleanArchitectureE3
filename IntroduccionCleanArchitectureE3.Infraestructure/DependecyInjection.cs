using IntroduccionCleanArchitectureE3.Application.Abstractions.Clock;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Email;
using IntroduccionCleanArchitectureE3.Infraestructure.Clock;
using IntroduccionCleanArchitectureE3.Infraestructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Infraestructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IDateTimeeProvider, DateTimeProvider>();
            service.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention();
            });
            return service;
        }
    }
}
