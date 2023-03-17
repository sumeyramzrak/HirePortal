using Hireportal.Common;
using Hireportal.Data.Concretes;
using Hireportal.Data.context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection($"{nameof(Settings)}:Database");
            var settings = section.Get<Settings.DatabaseConfiguration>();
            services.AddDbContext<HireportalDbContext>(builder =>
            {
                builder.UseSqlServer(settings.ConnectionString);
            });
            services.AddScoped<DbContext, HireportalDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
