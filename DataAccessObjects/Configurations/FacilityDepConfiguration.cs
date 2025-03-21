using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    public class FacilityDepConfiguration : IEntityTypeConfiguration<FacilityDepartment>
    {
        public void Configure(EntityTypeBuilder<FacilityDepartment> builder)
        {
            builder.HasKey(fd => fd.Id);

            builder.HasOne(fd => fd.Facility)
                .WithMany(f => f.FacilityDepartments) 
                .HasForeignKey(fd => fd.FacilityId)  
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(fd => fd.Department)
                .WithMany(d => d.FacilityDepartments) 
                .HasForeignKey(fd => fd.DepartmentId) 
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                            new FacilityDepartment
                            {
                                Id = 1,
                                FacilityId = 1,
                                DepartmentId = 1 
                            },
                            new FacilityDepartment
                            {
                                Id = 2,
                                FacilityId = 1, // Bệnh viện Đa khoa Quốc tế Hà Nội
                                DepartmentId = 2
                            },
                            new FacilityDepartment
                            {
                                Id = 3,
                                FacilityId = 2, // Bệnh viện Đa khoa Vạn Hạnh
                                DepartmentId = 3
                            },
                            new FacilityDepartment
                            {
                                Id = 4,
                                FacilityId = 2, // Bệnh viện Đa khoa Vạn Hạnh
                                DepartmentId = 4
                            },
                            new FacilityDepartment
                            {
                                Id = 5,
                                FacilityId = 3, // Trung tâm Y tế Quận 3
                                DepartmentId = 5
                            },
                            new FacilityDepartment
                            {
                                Id = 6,
                                FacilityId = 3, // Trung tâm Y tế Quận 3
                                DepartmentId = 6 
                            },
                            new FacilityDepartment
                            {
                                Id = 7,
                                FacilityId = 4,
                                DepartmentId = 7
                            },
                            new FacilityDepartment
                            {
                                Id = 8,
                                FacilityId = 4, // Bệnh viện Bạch Mai
                                DepartmentId = 8
                            },
                            new FacilityDepartment
                            {
                                Id = 9,
                                FacilityId = 5, // Bệnh viện Quốc tế Vinmec
                                DepartmentId = 9 // Khoa Tai Mũi Họng
                            },
                            new FacilityDepartment
                            {
                                Id = 10,
                                FacilityId = 5, // Bệnh viện Quốc tế Vinmec
                                DepartmentId = 10 // Khoa Da Liễu
                            },
                            new FacilityDepartment
                            {
                                Id = 11,
                                FacilityId = 6, // Trung tâm Y tế Quận 7
                                DepartmentId = 11 // Khoa Cấp cứu
                            },
                            new FacilityDepartment
                            {
                                Id = 12,
                                FacilityId = 6, // Trung tâm Y tế Quận 7
                                DepartmentId = 12 // Khoa Hồi sức tích cực
                            }
            );
        }
    }
}
