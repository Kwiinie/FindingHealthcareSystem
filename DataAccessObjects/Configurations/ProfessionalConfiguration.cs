using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithOne(u => u.Professional)
                .HasForeignKey<Professional>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Expertise)
                .WithMany()
                .HasForeignKey(p => p.ExpertiseId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.PrivateServices)
                .WithOne(ps => ps.Professional)
                .HasForeignKey(ps => ps.ProfessionalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ProfessionalSpecialties)
           .WithOne(ps => ps.Professional) 
           .HasForeignKey(ps => ps.ProfessionalId) 
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Professional
                {
                    Id = 1,
                    UserId = 4,
                    ExpertiseId = 1,
                    Province = "Thành phố Hà Nội",
                    District = "Quận Ba Đình",
                    Ward = "Phường Cửa Đông",
                    Address = "Số 10, Đường X",
                    Degree = "Bác sĩ đa khoa",
                    Experience = "Có 10 năm kinh nghiệm trong lĩnh vực khám chữa bệnh",
                    WorkingHours = "Thứ 2 - Thứ 6, 8:00 - 17:00",
                    RequestStatus = ProfessionalRequestStatus.Approved
                },
            new Professional
            {
                Id = 2,
                UserId = 5,
                ExpertiseId = 2,
                Province = "Thành phố Hồ Chí Minh",
                District = "Quận 1",
                Ward = "Phường Bến Nghé",
                Address = "Số 15, Đường Y",
                Degree = "Bác sĩ y học cổ truyền",
                Experience = "Có 5 năm kinh nghiệm trong điều trị các bệnh lý bằng y học cổ truyền",
                WorkingHours = "Thứ 2 - Thứ 7, 9:00 - 18:00",
                RequestStatus = ProfessionalRequestStatus.Pending
            }
                );

        }
    }
}
