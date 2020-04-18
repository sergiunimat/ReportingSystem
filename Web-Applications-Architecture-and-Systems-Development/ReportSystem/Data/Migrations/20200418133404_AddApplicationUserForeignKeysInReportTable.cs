using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportSystem.Data.Migrations
{
    public partial class AddApplicationUserForeignKeysInReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportInvestigatorId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportReporterId",
                table: "Reports",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportInvestigatorId",
                table: "Reports",
                column: "ReportInvestigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportReporterId",
                table: "Reports",
                column: "ReportReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReportInvestigatorId",
                table: "Reports",
                column: "ReportInvestigatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReportReporterId",
                table: "Reports",
                column: "ReportReporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReportInvestigatorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReportReporterId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportInvestigatorId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportReporterId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportInvestigatorId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportReporterId",
                table: "Reports");
        }
    }
}
