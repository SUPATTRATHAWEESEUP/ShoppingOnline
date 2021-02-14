using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStandardProject.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStockLogs",
                columns: table => new
                {
                    StockLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    AmountBefore = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    NewEdit = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    AmountAfter = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TypeAdd = table.Column<int>(nullable: false),
                    TextRemark = table.Column<string>(maxLength: 255, nullable: true),
                    Createdate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsActice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockLogs", x => x.StockLogId);
                    table.ForeignKey(
                        name: "FK_ProductStockLogs_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockLogs_ProductId",
                table: "ProductStockLogs",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStockLogs");
        }
    }
}
