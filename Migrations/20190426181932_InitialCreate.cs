using Microsoft.EntityFrameworkCore.Migrations;

namespace DruidShapeshifting.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Druid",
                columns: table => new
                {
                    DruidId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Race = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Druid", x => x.DruidId);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Challenge = table.Column<string>(maxLength: 3, nullable: false),
                    HitPoints = table.Column<string>(maxLength: 15, nullable: false),
                    Armor = table.Column<int>(nullable: false),
                    DruidId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.CreatureId);
                    table.ForeignKey(
                        name: "FK_Creature_Druid_DruidId",
                        column: x => x.DruidId,
                        principalTable: "Druid",
                        principalColumn: "DruidId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creature_DruidId",
                table: "Creature",
                column: "DruidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Druid");
        }
    }
}
