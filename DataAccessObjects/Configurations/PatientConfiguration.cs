﻿using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace DataAccessObjects.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.User)
           .WithOne(u => u.Patient)
           .HasForeignKey<Patient>(p => p.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Patient
                {
                    Id = 1,
                    UserId = 2,  
                    Note = "Bệnh nhân có tiền sử bệnh tim mạch",
                },
            new Patient
            {
                Id = 2,
                UserId = 3,
                Note = "Bệnh nhân bị tiểu đường type 2 và huyết áp cao",
            }
                );
        }
    }
}
