﻿// <auto-generated />
using InsuranceAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsuranceAPI.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.PatientBenefit", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("BenefitId")
                        .HasColumnType("int");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFullCoverage")
                        .HasColumnType("bit");

                    b.HasKey("PatientId", "BenefitId");

                    b.HasIndex("BenefitId");

                    b.ToTable("PatientsBenefits");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Patient", b =>
                {
                    b.HasOne("InsuranceAPI.Infrastructure.Entities.Carrier", "Carrier")
                        .WithMany("Patients")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.PatientBenefit", b =>
                {
                    b.HasOne("InsuranceAPI.Infrastructure.Entities.Benefit", "Benefit")
                        .WithMany("PatientsBenefits")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceAPI.Infrastructure.Entities.Patient", "Patient")
                        .WithMany("PatientsBenefits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Benefit", b =>
                {
                    b.Navigation("PatientsBenefits");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Carrier", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("InsuranceAPI.Infrastructure.Entities.Patient", b =>
                {
                    b.Navigation("PatientsBenefits");
                });
#pragma warning restore 612, 618
        }
    }
}
