using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class seedfacility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Address", "Description", "District", "ImgUrl", "Name", "OperationDay", "Province", "Status", "TypeId", "Ward" },
                values: new object[,]
                {
                    { 1, "Số 1, Phố Lê Thánh Tông, Hoàn Kiếm, Hà Nội", "Bệnh viện công cung cấp dịch vụ y tế chuyên nghiệp với chi phí hợp lý.", "Hoàn Kiếm", "", "Bệnh viện Đa khoa Quốc tế Hà Nội", new DateOnly(2025, 3, 17), "Hà Nội", "Active", 1, "Hàng Bạc" },
                    { 2, "Số 25, Đường Lý Thường Kiệt, Quận 10, Hồ Chí Minh", "Bệnh viện tư chuyên cung cấp dịch vụ y tế chất lượng cao.", "Quận 10", "", "Bệnh viện Đa khoa Vạn Hạnh", new DateOnly(2025, 3, 17), "Hồ Chí Minh", "Active", 2, "Phú Trung" },
                    { 3, "Số 45, Đường Võ Văn Tần, Quận 3, Hồ Chí Minh", "Trung tâm y tế cung cấp dịch vụ chăm sóc sức khỏe cơ bản cho cộng đồng.", "Quận 3", "", "Trung tâm Y tế Quận 3", new DateOnly(2025, 3, 17), "Hồ Chí Minh", "Active", 3, "Phường 7" },
                    { 4, "Số 78, Phố Giải Phóng, Đống Đa, Hà Nội", "Bệnh viện công lớn chuyên khoa về nội, ngoại, và các chuyên khoa khác.", "Đống Đa", "", "Bệnh viện Bạch Mai", new DateOnly(2025, 3, 17), "Hà Nội", "Active", 1, "Phương Liên" },
                    { 5, "Số 458, Đường Minh Khai, Cầu Giấy, Hà Nội", "Bệnh viện tư quốc tế với các dịch vụ khám chữa bệnh tiên tiến và chuyên nghiệp.", "Cầu Giấy", "", "Bệnh viện Quốc tế Vinmec", new DateOnly(2025, 3, 17), "Hà Nội", "Active", 2, "Dịch Vọng" },
                    { 6, "Số 50, Đường Nguyễn Văn Linh, Quận 7, Hồ Chí Minh", "Trung tâm y tế cung cấp các dịch vụ chăm sóc sức khỏe cộng đồng và các dịch vụ phòng ngừa.", "Quận 7", "", "Trung tâm Y tế Quận 7", new DateOnly(2025, 3, 17), "Hồ Chí Minh", "Active", 3, "Phú Mỹ" }
                });

            migrationBuilder.UpdateData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Bệnh viện do nhà nước sở hữu và quản lý, cung cấp dịch vụ y tế cho người dân với chi phí thấp hơn.", "Bệnh viện công" });

            migrationBuilder.UpdateData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Bệnh viện thuộc sở hữu của các cá nhân hoặc tổ chức tư nhân, cung cấp dịch vụ y tế với chất lượng cao và chi phí có thể cao hơn.", "Bệnh viện tư" });

            migrationBuilder.UpdateData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Cơ sở cung cấp dịch vụ y tế cơ bản và phòng ngừa cho cộng đồng.", "Trung tâm y tế" });

            migrationBuilder.InsertData(
                table: "FacilityDepartments",
                columns: new[] { "Id", "DepartmentId", "FacilityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 5 },
                    { 10, 10, 5 },
                    { 11, 11, 6 },
                    { 12, 12, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FacilityDepartments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Cơ sở y tế chuyên điều trị các bệnh lý đa dạng.", "Bệnh viện" });

            migrationBuilder.UpdateData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Cơ sở y tế nhỏ, chủ yếu khám chữa bệnh ngoại trú.", "Phòng khám" });

            migrationBuilder.UpdateData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Cửa hàng cung cấp thuốc và các sản phẩm y tế.", "Nhà thuốc" });
        }
    }
}
