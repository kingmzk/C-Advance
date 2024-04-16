/*
 * using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IEnumerableIQueryable.Demo
{
    public class EmployeeContext : DbContext
    {
        private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(config => config.AddConsole());

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
*/

using IEnumerableIQueryable.Demo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class EmployeeContext : DbContext
{
    
    private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(config => config.AddConsole());
    public EmployeeContext()
    {
    }

    public DbSet<Employee> Employees { get; set; }

    // Set up the database connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KINGMZK\\SQLEXPRESS;Database=AdvanceC#;Trusted_Connection=True;TrustServerCertificate=True;");
        optionsBuilder.UseLoggerFactory(loggerFactory);
    }
    



}
