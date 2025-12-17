using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class secondCraete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gifts_Donors_DonorsIdDonor",
                table: "gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Orders_Orders_OrdersOrderId",
                table: "Gifts_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_Orders_OrdersOrderId",
                table: "Gifts_Orders");

            migrationBuilder.DropColumn(
                name: "OrdersOrderId",
                table: "Gifts_Orders");

            migrationBuilder.RenameColumn(
                name: "Amount_PrimPremium",
                table: "Packages",
                newName: "Amount_Premium");

            migrationBuilder.RenameColumn(
                name: "DonorsIdDonor",
                table: "gifts",
                newName: "DonorIdDonor");

            migrationBuilder.RenameIndex(
                name: "IX_gifts_DonorsIdDonor",
                table: "gifts",
                newName: "IX_gifts_DonorIdDonor");

            migrationBuilder.AddColumn<bool>(
                name: "IsStatusDraft",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDrawn",
                table: "gifts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Buyers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CurdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBayer = table.Column<int>(type: "int", nullable: false),
                    IdGift = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    PackageIdPackage = table.Column<int>(type: "int", nullable: true),
                    UserIdBayer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CurdId);
                    table.ForeignKey(
                        name: "FK_Card_Buyers_UserIdBayer",
                        column: x => x.UserIdBayer,
                        principalTable: "Buyers",
                        principalColumn: "IdBayer");
                    table.ForeignKey(
                        name: "FK_Card_Packages_PackageIdPackage",
                        column: x => x.PackageIdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Orders_OrderId",
                table: "Gifts_Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_PackageIdPackage",
                table: "Card",
                column: "PackageIdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_Card_UserIdBayer",
                table: "Card",
                column: "UserIdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_gifts_Donors_DonorIdDonor",
                table: "gifts",
                column: "DonorIdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Orders_Orders_OrderId",
                table: "Gifts_Orders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gifts_Donors_DonorIdDonor",
                table: "gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Orders_Orders_OrderId",
                table: "Gifts_Orders");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_Orders_OrderId",
                table: "Gifts_Orders");

            migrationBuilder.DropColumn(
                name: "IsStatusDraft",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "gifts");

            migrationBuilder.DropColumn(
                name: "IsDrawn",
                table: "gifts");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Buyers");

            migrationBuilder.RenameColumn(
                name: "Amount_Premium",
                table: "Packages",
                newName: "Amount_PrimPremium");

            migrationBuilder.RenameColumn(
                name: "DonorIdDonor",
                table: "gifts",
                newName: "DonorsIdDonor");

            migrationBuilder.RenameIndex(
                name: "IX_gifts_DonorIdDonor",
                table: "gifts",
                newName: "IX_gifts_DonorsIdDonor");

            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderId",
                table: "Gifts_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Orders_OrdersOrderId",
                table: "Gifts_Orders",
                column: "OrdersOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_gifts_Donors_DonorsIdDonor",
                table: "gifts",
                column: "DonorsIdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Orders_Orders_OrdersOrderId",
                table: "Gifts_Orders",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
