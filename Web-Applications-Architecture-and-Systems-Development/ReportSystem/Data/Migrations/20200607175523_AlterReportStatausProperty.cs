using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportSystem.Data.Migrations
{
    public partial class AlterReportStatausProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReportStatus",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReportStatus",
                table: "Reports",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
