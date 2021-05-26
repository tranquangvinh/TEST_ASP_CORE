using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actuals",
                columns: table => new
                {
                    State = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualPopulation = table.Column<string>(nullable: true),
                    ActualHouseholds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actuals", x => x.State);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    State = table.Column<int>(nullable: false),
                    Districts = table.Column<string>(nullable: false),
                    EstimatesPopulation = table.Column<string>(nullable: true),
                    EstimatesHouseholds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => new { x.State, x.Districts });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actuals");

            migrationBuilder.DropTable(
                name: "Estimates");
        }
    }
}
