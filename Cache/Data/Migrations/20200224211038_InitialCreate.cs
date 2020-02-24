using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cache.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firearm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerImporter = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    CaliberGauge = table.Column<string>(nullable: true),
                    DateAcquired = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchaseLocation = table.Column<string>(nullable: false),
                    SoldTransferredTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firearm", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firearm");
        }
    }
}
