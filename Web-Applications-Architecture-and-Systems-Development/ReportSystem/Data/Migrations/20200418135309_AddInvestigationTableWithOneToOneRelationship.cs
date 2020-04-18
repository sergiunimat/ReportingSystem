using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportSystem.Data.Migrations
{
    public partial class AddInvestigationTableWithOneToOneRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investigations",
                columns: table => new
                {
                    InvestigationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigationStatus = table.Column<bool>(nullable: false),
                    ReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigations", x => x.InvestigationId);
                    table.ForeignKey(
                        name: "FK_Investigations_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investigations_ReportId",
                table: "Investigations",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investigations");
        }
    }
}
