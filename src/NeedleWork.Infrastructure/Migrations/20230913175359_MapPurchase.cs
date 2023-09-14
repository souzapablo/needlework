using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeedleWork.Infrastructure.Migrations;

/// <inheritdoc />
public partial class MapPurchase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Purchases",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<long>(type: "bigint", nullable: false),
                PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Total = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Purchases", x => x.Id);
                table.ForeignKey(
                    name: "FK_Purchases_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PurchaseItems",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProductId = table.Column<long>(type: "bigint", nullable: false),
                Quantity = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                PurchaseId = table.Column<long>(type: "bigint", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_PurchaseItems_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PurchaseItems_Purchases_PurchaseId",
                    column: x => x.PurchaseId,
                    principalTable: "Purchases",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_PurchaseItems_ProductId",
            table: "PurchaseItems",
            column: "ProductId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_PurchaseItems_PurchaseId",
            table: "PurchaseItems",
            column: "PurchaseId");

        migrationBuilder.CreateIndex(
            name: "IX_Purchases_UserId",
            table: "Purchases",
            column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "PurchaseItems");

        migrationBuilder.DropTable(
            name: "Purchases");
    }
}
