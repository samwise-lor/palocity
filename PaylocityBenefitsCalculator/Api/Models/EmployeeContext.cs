using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class EmployeeContext : DbContext
    {
        //protected readonly IConfiguration Configuration;
        //public EmployeeContext(DbContextOptions<EmployeeContext> options, IConfiguration configuration) : base(options)
        //{
        //    Configuration = configuration;
        //}     

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseInMemoryDatabase("EmployeeDb");
        //}

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()            
            .HasMany(d => d.Dependents)
            .WithOne(e => e.Employee)
            .HasForeignKey(f => f.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Employee>().Property(e => e.Salary).HasPrecision(18, 2);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}
