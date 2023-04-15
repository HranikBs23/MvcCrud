using Microsoft.EntityFrameworkCore;
using MvcCrud.Models.Domain;

namespace MvcCrud.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)

        {
            
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
