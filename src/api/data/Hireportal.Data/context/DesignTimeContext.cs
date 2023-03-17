using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.context
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<HireportalDbContext>
    {
        public HireportalDbContext CreateDbContext(string[] args)
        {
            var connectionString = new ConfigurationBuilder()
                            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                            .AddJsonFile("appsettings.json", false, true).Build()
                            .GetValue<string>("MigrationConnectionString");


            var optionsBuilder = new DbContextOptionsBuilder<HireportalDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new HireportalDbContext(optionsBuilder.Options);
        }

    }
}
