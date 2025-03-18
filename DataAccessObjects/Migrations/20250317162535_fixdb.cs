using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class fixdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Professionals",
                newName: "Ward");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Facilities",
                newName: "Ward");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ward",
                value: "Phường Cửa Đông");

            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ward",
                value: "Phường Bến Nghé");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Facilities");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "Professionals",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "Facilities",
                newName: "City");

            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: "Hà Nội");

            migrationBuilder.UpdateData(
                table: "Professionals",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "Hồ Chí Minh");
        }
    }
}
