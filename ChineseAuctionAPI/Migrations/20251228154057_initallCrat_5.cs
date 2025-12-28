using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initallCrat_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Orders_OrderId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_OrderId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "IsStatusDraft",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Gifts_Orders");

            migrationBuilder.RenameColumn(
                name: "AmountOrders",
                table: "Orders",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Gifts",
                newName: "price");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinnerUserId",
                table: "Gifts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GiftCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageOrders",
                columns: table => new
                {
                    IdPackageOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IdPackage = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtPurchase = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageOrders", x => x.IdPackageOrder);
                    table.ForeignKey(
                        name: "FK_PackageOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageOrders_Packages_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId",
                unique: true,
                filter: "[Status] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gifts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageOrders_IdPackage",
                table: "PackageOrders",
                column: "IdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_PackageOrders_OrderId",
                table: "PackageOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_GiftCategory_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "GiftCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_GiftCategory_CategoryId",
                table: "Gifts");

            migrationBuilder.DropTable(
                name: "GiftCategory");

            migrationBuilder.DropTable(
                name: "PackageOrders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "WinnerUserId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Orders",
                newName: "AmountOrders");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Gifts",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStatusDraft",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Gifts_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_OrderId",
                table: "Packages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Orders_OrderId",
                table: "Packages",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
