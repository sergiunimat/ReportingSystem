using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportSystem.Data.Migrations
{
    public partial class AlterInvestigationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations");

            migrationBuilder.DropIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Investigations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestigationDescription",
                table: "Investigations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestigatorId",
                table: "Investigations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations",
                column: "ReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations");

            migrationBuilder.DropIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations");

            migrationBuilder.DropColumn(
                name: "InvestigationDescription",
                table: "Investigations");

            migrationBuilder.DropColumn(
                name: "InvestigatorId",
                table: "Investigations");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Investigations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_Reports_ReportId",
                table: "Investigations",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
