using System;
using System.Linq;
using IEnumerableIQueryable.Demo;
using Microsoft.EntityFrameworkCore;

//IEnumerable is an interface in C# which returns Enumerator that represents a collection of items that can be enumerated using a foreach loop.

//IQueryable is an interface in C# that represents a queryable collection of data that can be queried using LINQ operators.


namespace EmployeeManagement
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            // Create a connection to the database
            EmployeeContext context = new EmployeeContext();

            // Configure the database connection
            context.Database.EnsureCreated();

            // Retrieve employees with ID greater than 1

           // IQueryable gives a queryable collection that is executed against the database.
            // The filtering condition (e => e.Id > 1) is translated into SQL and executed on the database server.
            IQueryable<Employee> employees = context.Employees.Where(e => e.Id > 1);

            // IEnumerable gives an in-memory collection that retrieves all records from the database
            // and performs filtering in-memory using LINQ to Objects.
            // IEnumerable<Employee> employees = context.Employees.Where(e => e.Id > 1);

            var topEmployee = employees.Take(1);
            // Print the first name of each employee
            foreach (var employee in topEmployee)
            {
                Console.WriteLine(employee.FirstName);
            }

            Console.WriteLine("Hi");
        }
    }  
}
/*
 using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IEnumerableIQueryable
{
  class Program : IDesignTimeDbContextFactory<EmployeeContext>
  {
    public EmployeeContext CreateDbContext(string[] args = null)
    {
      var serviceProvider = new ServiceCollection()
          .AddDbContext<EmployeeContext>(options => options.UseSqlServer("Server=KINGMZK\\SQLEXPRESS;Database=AdvanceC#;Trusted_Connection=True;TrustServerCertificate=True;"))
          .BuildServiceProvider();

      var context = serviceProvider.GetService<EmployeeContext>();

      // Optional: Configure logging (if needed)
      // context.Database.EnsureCreated(); // Uncomment this if you want migrations to create the database

      return context;
    }

    static void Main(string[] args)
    {
      // Rest of your code using the service provider as before...

      Console.WriteLine("Hi");

      using (var serviceProvider = new ServiceCollection()
          .AddDbContext<EmployeeContext>(options => options.UseSqlServer("Server=KINGMZK\\SQLEXPRESS;Database=AdvanceC#;Trusted_Connection=True;TrustServerCertificate=True;"))
          .BuildServiceProvider())
      {
        using (var context = serviceProvider.GetService<EmployeeContext>())
        {
          IEnumerable<Employee> employees = context.Employees.Where(e => e.Id > 1).ToList();
          foreach (var employee in employees)
          {
            Console.WriteLine(employee.FirstName);
          }
        }
      }
    }
  }
}

  */