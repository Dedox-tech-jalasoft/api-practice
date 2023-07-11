using InsuranceAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientBenefit> PatientsBenefits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(properties => properties.Carrier)
                .WithMany(properties => properties.Patients)
                .HasForeignKey(properties => properties.CarrierId)
                .IsRequired();

            modelBuilder.Entity<PatientBenefit>()
                .HasKey(properties => new
                {
                    properties.PatientId,
                    properties.BenefitId
                });

            modelBuilder.Entity<PatientBenefit>()
                .HasOne(properties => properties.Patient)
                .WithMany(properties => properties.PatientsBenefits)
                .HasForeignKey(properties => properties.PatientId);

            modelBuilder.Entity<PatientBenefit>()
                .HasOne(properties => properties.Benefit)
                .WithMany(properties => properties.PatientsBenefits)
                .HasForeignKey(properties => properties.BenefitId);
        }
    }
}
