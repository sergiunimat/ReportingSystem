using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportSystem.Data.Migrations
{
    public partial class AddReportLongitudeAndLatitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportAddress",
                table: "Reports");

            migrationBuilder.AddColumn<double>(
                name: "ReportLatitude",
                table: "Reports",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ReportLongitude",
                table: "Reports",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportLatitude",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportLongitude",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "ReportAddress",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
