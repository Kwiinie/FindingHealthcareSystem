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
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasMany(f => f.FacilityDepartments)
                   .WithOne(fd => fd.Facility)
                   .HasForeignKey(fd => fd.FacilityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.PublicServices)
                   .WithOne(ps => ps.Facility)
                   .HasForeignKey(ps => ps.FacilityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Type)
                   .WithMany(ft => ft.Facilities)
                   .HasForeignKey(f => f.TypeId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                        new Facility
                        {
                            Id = 1,
                            TypeId = 1, 
                            Name = "Bệnh viện Đa khoa Quốc tế Hà Nội",
                            OperationDay = new DateOnly(2025, 3, 17),
                            Province = "Hà Nội",
                            District = "Hoàn Kiếm",
                            Ward = "Hàng Bạc",
                            Address = "Số 1, Phố Lê Thánh Tông, Hoàn Kiếm, Hà Nội",
                            Description = "Bệnh viện công cung cấp dịch vụ y tế chuyên nghiệp với chi phí hợp lý.",
                            Status = FacilityStatus.Active,
                        },
                        new Facility
                        {
                            Id = 2,
                            TypeId = 2, // Bệnh viện tư
                            Name = "Bệnh viện Đa khoa Vạn Hạnh",
                            OperationDay = new DateOnly(2025, 3, 17),
                            Province = "Hồ Chí Minh",
                            District = "Quận 10",
                            Ward = "Phú Trung",
                            Address = "Số 25, Đường Lý Thường Kiệt, Quận 10, Hồ Chí Minh",
                            Description = "Bệnh viện tư chuyên cung cấp dịch vụ y tế chất lượng cao.",
                            Status = FacilityStatus.Active,
                        },
                        new Facility
                        {
                            Id = 3,
                            TypeId = 3,
                            Name = "Trung tâm Y tế Quận 3",
                            OperationDay = new DateOnly(2025, 3, 17),
                            Province = "Hồ Chí Minh",
                            District = "Quận 3",
                            Ward = "Phường 7",
                            Address = "Số 45, Đường Võ Văn Tần, Quận 3, Hồ Chí Minh",
                            Description = "Trung tâm y tế cung cấp dịch vụ chăm sóc sức khỏe cơ bản cho cộng đồng.",
                            Status = FacilityStatus.Active,
                        },
                        new Facility
                        {
                            Id = 4,
                            TypeId = 1,
                            Name = "Bệnh viện Bạch Mai",
                            OperationDay = new DateOnly(2025, 3, 17),
                            Province = "Hà Nội",
                            District = "Đống Đa",
                            Ward = "Phương Liên",
                            Address = "Số 78, Phố Giải Phóng, Đống Đa, Hà Nội",
                            Description = "Bệnh viện công lớn chuyên khoa về nội, ngoại, và các chuyên khoa khác.",
                            Status = FacilityStatus.Active,
                        },
                        new Facility
                        {
                            Id = 5,
                            TypeId = 2, // Bệnh viện tư
                            Name = "Bệnh viện Quốc tế Vinmec",
                            OperationDay = new DateOnly(2025, 3, 17),
                            Province = "Hà Nội",
                            District = "Cầu Giấy",
                            Ward = "Dịch Vọng",
                            Address = "Số 458, Đường Minh Khai, Cầu Giấy, Hà Nội",
                            Description = "Bệnh viện tư quốc tế với các dịch vụ khám chữa bệnh tiên tiến và chuyên nghiệp.",
                            Status = FacilityStatus.Active,
                        },
                        new Facility
                        {
                            Id = 6,
                            TypeId = 3, // Trung tâm y tế
                            Name = "Trung tâm Y tế Quận 7",
                            OperationDay = new DateOnly(2025, 3, 17),
                            Province = "Hồ Chí Minh",
                            District = "Quận 7",
                            Ward = "Phú Mỹ",
                            Address = "Số 50, Đường Nguyễn Văn Linh, Quận 7, Hồ Chí Minh",
                            Description = "Trung tâm y tế cung cấp các dịch vụ chăm sóc sức khỏe cộng đồng và các dịch vụ phòng ngừa.",
                            Status = FacilityStatus.Active,
                        }
            );
        }
    }
}
