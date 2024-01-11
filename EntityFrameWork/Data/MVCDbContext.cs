using EntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> EmployeeTable { get; set; }
    }
}
