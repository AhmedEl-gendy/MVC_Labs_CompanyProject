using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Lab_Day02.Models
{
    public class MVC_DbContext : DbContext
    {
        public MVC_DbContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<WorkOn> WorksOn { get; set; }

        public MVC_DbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I56ECAU\\SS22;Initial Catalog=MVC_Company;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
            .HasKey(c => new { c.DeptNum, c.Loc });

            modelBuilder.Entity<Dependent>()
                .HasKey(c => new { c.EmpSSN, c.DependName });

            modelBuilder.Entity<WorkOn>()
                .HasKey(c => new { c.EmpSSN, c.ProjectNum });

            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentNum);

            modelBuilder.Entity<Employee>(b =>
            {
                b.Property(e => e.SSN).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Department>(b =>
            {
                b.Property(e => e.DeptNum).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Project>(b =>
            {
                //b.HasKey(e => e.ProjectNumber);
                b.Property(e => e.ProjectNumber).ValueGeneratedOnAdd();
            });
        }
        


    }
}
