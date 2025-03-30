using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Enums;

namespace DataAccessObjects.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Payment)
                .WithMany()
                .HasForeignKey(a => a.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.MedicalRecords)
               .WithOne(mr => mr.Appointment)
               .HasForeignKey(mr => mr.AppointmentId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Appointment
                {
                    Id = 1,
                    PatientId = 1,
                    ProviderId = 1,
                    ProviderType = ProviderType.Professional,
                    ServiceId = 1,
                    ServiceType = ServiceType.Private,
                    Status = AppointmentStatus.AwaitingPayment,
                    PaymentId = null,
                    Description = "Khám bệnh tổng quát cho bệnh nhân",
                    Date = new DateTime(2025, 3, 31, 10, 0, 0),
                },
                new Appointment
                {
                    Id = 2,
                    PatientId = 2,
                    ProviderId = 1,
                    ProviderType = ProviderType.Professional,
                    ServiceId = 4,
                    ServiceType = ServiceType.Private,
                    Status = AppointmentStatus.AwaitingPayment,
                    PaymentId = null,
                    Description = "Điều trị bằng y học cổ truyền cho bệnh nhân",
                    Date = new DateTime(2025, 3, 31, 14, 00, 0),
                }
           );
        }
    }
}
