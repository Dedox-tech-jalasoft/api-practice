using InsuranceAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(properties => properties.Carrier)
                .WithMany(properties => properties.Patients)
                .HasForeignKey(properties => properties.CarrierId)
                .IsRequired();
        }
    }
}
