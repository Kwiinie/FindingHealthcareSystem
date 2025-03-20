using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class fixWorkinghours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingHours",
                value: "8:00 - 17:00");

            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingHours",
                value: "9:00 - 18:00");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingHours",
                value: "Thứ 2 - Thứ 6, 8:00 - 17:00");

            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingHours",
                value: "Thứ 2 - Thứ 7, 9:00 - 18:00");
        }
    }
}
