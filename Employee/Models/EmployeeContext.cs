using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employeecs> Employees { get; set; }
    }
}
