using employees_manager_api;
using Microsoft.EntityFrameworkCore;


namespace employees_managamenta_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        

    }
}
