using Microsoft.EntityFrameworkCore.Migrations;

namespace Donea_Paul_App.Migrations
{
    public partial class TruckCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakerID",
                table: "Truck",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Maker",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maker", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TruckCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TruckCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckCategory_Truck_TruckID",
                        column: x => x.TruckID,
                        principalTable: "Truck",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_MakerID",
                table: "Truck",
                column: "MakerID");

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategory_CategoryID",
                table: "TruckCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategory_TruckID",
                table: "TruckCategory",
                column: "TruckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Truck_Maker_MakerID",
                table: "Truck",
                column: "MakerID",
                principalTable: "Maker",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Truck_Maker_MakerID",
                table: "Truck");

            migrationBuilder.DropTable(
                name: "Maker");

            migrationBuilder.DropTable(
                name: "TruckCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Truck_MakerID",
                table: "Truck");

            migrationBuilder.DropColumn(
                name: "MakerID",
                table: "Truck");
        }
    }
}
