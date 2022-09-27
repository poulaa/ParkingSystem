using Microsoft.EntityFrameworkCore.Migrations;

namespace parking_system.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_owner",
                columns: table => new
                {
                    car_owner_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    licen_number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_owner", x => x.car_owner_id);
                });

            migrationBuilder.CreateTable(
                name: "park_slot",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<string>(nullable: true),
                    spot = table.Column<string>(nullable: false),
                    licen_number = table.Column<int>(nullable: false),
                    car_owner_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_park_slot", x => x.id);
                    table.ForeignKey(
                        name: "FK_park_slot_car_owner_car_owner_id",
                        column: x => x.car_owner_id,
                        principalTable: "car_owner",
                        principalColumn: "car_owner_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_park_slot_car_owner_id",
                table: "park_slot",
                column: "car_owner_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "park_slot");

            migrationBuilder.DropTable(
                name: "car_owner");
        }
    }
}
