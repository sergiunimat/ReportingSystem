using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportSystem.Data.Migrations
{
    public partial class AddReportExtraFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReportStatus",
                table: "Reports",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "Reports");
        }
    }
}
