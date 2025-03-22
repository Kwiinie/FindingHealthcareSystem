using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class seedingappointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "Description", "PatientId", "PaymentId", "ProviderId", "ProviderType", "ServiceId", "ServiceType", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), "Khám bệnh tổng quát cho bệnh nhân", 1, null, 1, "Professional", 1, "Private", "AwaitingPayment" },
                    { 2, new DateTime(2025, 3, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), "Điều trị bằng y học cổ truyền cho bệnh nhân", 2, null, 1, "Professional", 4, "Private", "AwaitingPayment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
