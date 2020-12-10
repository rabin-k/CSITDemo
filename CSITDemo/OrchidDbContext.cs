using CSITDemo.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CSITDemo
{
    public class OrchidDbContext : DbContext
    {
        public OrchidDbContext(DbContextOptions<OrchidDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Class>().ToTable("Class");
        }
    }
}