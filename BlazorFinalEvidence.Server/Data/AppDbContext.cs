using BlazorFinalEvidence.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorFinalEvidence.Server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
