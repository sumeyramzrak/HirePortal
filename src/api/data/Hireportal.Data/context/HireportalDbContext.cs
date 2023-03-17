using Hireportal.Entites.CompanyManager;
using Hireportal.Entites.Profile;

namespace Hireportal.Data.context
{
    public class HireportalDbContext : DbContext
    {
        public HireportalDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LookUp> LookUps { get; set; }
        public DbSet<LookUpType> LookUpTypes { get; set; }
        public DbSet<SystemParameter> SystemParameters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<PayRoll> PayRolls { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }

}
