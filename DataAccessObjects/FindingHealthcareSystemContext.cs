﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entities;
using BusinessObjects.Commons;
using Microsoft.Extensions.Configuration;
using DataAccessObjects.Configurations;

namespace DataAccessObjects;

public partial class FindingHealthcareSystemContext : DbContext
{
    public FindingHealthcareSystemContext()
    {
    }

    public FindingHealthcareSystemContext(DbContextOptions<FindingHealthcareSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<FacilityDepartment> FacilityDepartments { get; set; }

    public virtual DbSet<FacilityType> FacilityTypes { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientUnderlyingDisease> PatientUnderlyingDiseases { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PrivateService> PrivateServices { get; set; }

    public virtual DbSet<Professional> Professionals { get; set; }

    public virtual DbSet<ProfessionalSpecialty> ProfessionalSpecialties { get; set; }

    public virtual DbSet<PublicService> PublicServices { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<UnderlyingDisease> UnderlyingDiseases { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.CreatedAt))
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.UpdatedAt))
                    .HasDefaultValueSql("GETUTCDATE()");
            }
        }

        //store enum as string
        modelBuilder.Entity<Appointment>()
        .Property(a => a.ServiceType)
        .HasConversion<string>();

        modelBuilder.Entity<Appointment>()
        .Property(a => a.ProviderType)
        .HasConversion<string>();

        modelBuilder.Entity<Appointment>()
            .Property(a => a.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Payment>()
            .Property(p => p.PaymentMethod)
            .HasConversion<string>();

        modelBuilder.Entity<Payment>()
            .Property(p => p.PaymentStatus)
            .HasConversion<string>();

        modelBuilder.Entity<Professional>()
            .Property(p => p.RequestStatus)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .Property(p => p.Status)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .Property(p => p.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Facility>()
           .Property(p => p.Status)
           .HasConversion<string>();

        modelBuilder.Entity<Payment>()
           .Property(p => p.PaymentStatus)
           .HasConversion<string>();

        modelBuilder.Entity<Review>()
        .Property(a => a.ProviderType)
        .HasConversion<string>();
            //config polymorphic relationship
            modelBuilder.Entity<Appointment>()
                .HasOne<PrivateService>()
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .HasConstraintName("FK_Appointment_PrivateService")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne<PublicService>()
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .HasConstraintName("FK_Appointment_PublicService")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne<Professional>()
                .WithMany()
                .HasForeignKey(a => a.ProviderId)
                .HasConstraintName("FK_Appointment_Professional")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne<Facility>()
                .WithMany()
                .HasForeignKey(a => a.ProviderId)
                .HasConstraintName("FK_Appointment_Facility")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne<Professional>()
                .WithMany()
                .HasForeignKey(a => a.ProviderId)
                .HasConstraintName("FK_Review_Professional")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne<Facility>()
                .WithMany()
                .HasForeignKey(a => a.ProviderId)
                .HasConstraintName("FK_Review_Facility")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            OnModelCreatingPartial(modelBuilder);
        
    }

    public override int SaveChanges()
        {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
        {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
        {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
        {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
        {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

