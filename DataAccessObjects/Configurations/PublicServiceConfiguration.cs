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
    public class PublicServiceConfiguration : IEntityTypeConfiguration<PublicService>
    {
        public void Configure(EntityTypeBuilder<PublicService> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.Facility)
                .WithMany(f => f.PublicServices) 
                .HasForeignKey(ps => ps.FacilityId) 
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new PublicService
                {
                    Id = 1,
                    Name = "Khám bệnh tổng quát",
                    Price = 300000,
                    Description = "Khám tổng quát để kiểm tra sức khỏe định kỳ.",
                    FacilityId = 1 // assuming Facility with Id = 1
                },
                new PublicService
                {
                    Id = 2,
                    Name = "Xét nghiệm máu",
                    Price = 150000,
                    Description = "Xét nghiệm máu để kiểm tra các chỉ số sức khỏe.",
                    FacilityId = 1 // assuming Facility with Id = 1
                },
                new PublicService
                {
                    Id = 3,
                    Name = "Khám bệnh lý tim mạch",
                    Price = 500000,
                    Description = "Khám các bệnh lý về tim mạch, huyết áp và các bệnh lý liên quan.",
                    FacilityId = 1
                },
                new PublicService
                {
                    Id = 4,
                    Name = "Điều trị bằng y học cổ truyền",
                    Price = 400000,
                    Description = "Sử dụng phương pháp y học cổ truyền để điều trị các bệnh lý như đau nhức, viêm nhiễm.",
                    FacilityId = 2 // assuming Facility with Id = 2
                },
                new PublicService
                {
                    Id = 5,
                    Name = "Châm cứu điều trị đau lưng",
                    Price = 350000,
                    Description = "Châm cứu để điều trị các cơn đau lưng mãn tính.",
                    FacilityId = 2 // assuming Facility with Id = 2
                },
                new PublicService
                {
                    Id = 6,
                    Name = "Xoa bóp bấm huyệt",
                    Price = 250000,
                    Description = "Xoa bóp và bấm huyệt giúp giảm căng thẳng và mệt mỏi.",
                    FacilityId = 2 // assuming Facility with Id = 2
                },
                new PublicService
                {
                    Id = 7,
                    Name = "Khám tai mũi họng",
                    Price = 200000,
                    Description = "Khám các bệnh lý về tai mũi họng như viêm họng, viêm amidan.",
                    FacilityId = 1
                },
                new PublicService
                {
                    Id = 8,
                    Name = "Khám mắt",
                    Price = 250000,
                    Description = "Khám mắt để kiểm tra sức khỏe mắt, phát hiện các bệnh lý như cận thị, loạn thị.",
                    FacilityId = 1
                },
                new PublicService
                {
                    Id = 9,
                    Name = "Điều trị bằng thuốc thảo dược",
                    Price = 300000,
                    Description = "Sử dụng thuốc thảo dược để điều trị các bệnh lý như cảm cúm, tiêu hóa.",
                    FacilityId = 2
                },
                new PublicService
                {
                    Id = 10,
                    Name = "Khám răng miệng",
                    Price = 250000,
                    Description = "Khám và kiểm tra tình trạng răng miệng, phát hiện sâu răng, viêm lợi.",
                    FacilityId = 3 // assuming Facility with Id = 3
                },
                new PublicService
                {
                    Id = 11,
                    Name = "Lấy cao răng",
                    Price = 150000,
                    Description = "Lấy cao răng, giúp làm sạch răng miệng và ngăn ngừa bệnh về nướu.",
                    FacilityId = 3
                },
                new PublicService
                {
                    Id = 12,
                    Name = "Cấy ghép răng implant",
                    Price = 1000000,
                    Description = "Cấy ghép răng implant cho những người mất răng.",
                    FacilityId = 3
                },
                new PublicService
                {
                    Id = 13,
                    Name = "Tẩy trắng răng",
                    Price = 500000,
                    Description = "Dịch vụ tẩy trắng răng giúp cải thiện màu sắc răng miệng.",
                    FacilityId = 3
                }
           );
        }
    }
}
