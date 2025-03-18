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
    public class PrivateServiceConfiguration : IEntityTypeConfiguration<PrivateService>
    {
        public void Configure(EntityTypeBuilder<PrivateService> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.Professional)
                .WithMany(p => p.PrivateServices) 
                .HasForeignKey(ps => ps.ProfessionalId) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                    new PrivateService
                    {
                        Id = 1,
                        Name = "Khám bệnh tổng quát",
                        Price = 300000,
                        Description = "Khám tổng quát để kiểm tra sức khỏe định kỳ.",
                        ProfessionalId = 1
                    },
                    new PrivateService
                    {
                        Id = 2,
                        Name = "Khám sức khỏe phụ khoa",
                        Price = 350000,
                        Description = "Khám sức khỏe phụ khoa cho nữ giới.",
                        ProfessionalId = 1
                    },
                    new PrivateService
                    {
                        Id = 3,
                        Name = "Khám bệnh lý tim mạch",
                        Price = 500000,
                        Description = "Khám các bệnh lý về tim mạch, huyết áp và các bệnh lý liên quan.",
                        ProfessionalId = 1
                    },
                    new PrivateService
                    {
                        Id = 4,
                        Name = "Điều trị bằng y học cổ truyền",
                        Price = 500000,
                        Description = "Sử dụng y học cổ truyền để điều trị các bệnh lý như đau nhức, viêm nhiễm.",
                        ProfessionalId = 2
                    },
                    new PrivateService
                    {
                        Id = 5,
                        Name = "Châm cứu điều trị đau lưng",
                        Price = 400000,
                        Description = "Điều trị đau lưng bằng phương pháp châm cứu truyền thống.",
                        ProfessionalId = 2
                    },
                    new PrivateService
                    {
                        Id = 6,
                        Name = "Xoa bóp bấm huyệt",
                        Price = 350000,
                        Description = "Xoa bóp và bấm huyệt giúp giảm căng thẳng và mệt mỏi.",
                        ProfessionalId = 2
                    }         
             );
        }
    }
}
