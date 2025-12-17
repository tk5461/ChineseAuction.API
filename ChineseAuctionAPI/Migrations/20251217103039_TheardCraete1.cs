using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class TheardCraete1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Packages_PackageIdPackage",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Users_UserIdBayer",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_gifts_Donors_DonorIdDonor",
                table: "gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Orders_gifts_giftsIdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gifts",
                table: "gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "gifts",
                newName: "Gifts");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_gifts_DonorIdDonor",
                table: "Gifts",
                newName: "IX_Gifts_DonorIdDonor");

            migrationBuilder.RenameIndex(
                name: "IX_Card_UserIdBayer",
                table: "Cards",
                newName: "IX_Cards_UserIdBayer");

            migrationBuilder.RenameIndex(
                name: "IX_Card_PackageIdPackage",
                table: "Cards",
                newName: "IX_Cards_PackageIdPackage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts",
                column: "IdGift");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "CurdId");

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    IdWin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBayer = table.Column<int>(type: "int", nullable: false),
                    BuyerIdBayer = table.Column<int>(type: "int", nullable: false),
                    IdGift = table.Column<int>(type: "int", nullable: false),
                    giftsIdGift = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.IdWin);
                    table.ForeignKey(
                        name: "FK_Winners_Gifts_giftsIdGift",
                        column: x => x.giftsIdGift,
                        principalTable: "Gifts",
                        principalColumn: "IdGift",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Winners_Users_BuyerIdBayer",
                        column: x => x.BuyerIdBayer,
                        principalTable: "Users",
                        principalColumn: "IdBayer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Winners_BuyerIdBayer",
                table: "Winners",
                column: "BuyerIdBayer");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_giftsIdGift",
                table: "Winners",
                column: "giftsIdGift");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Packages_PackageIdPackage",
                table: "Cards",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserIdBayer",
                table: "Cards",
                column: "UserIdBayer",
                principalTable: "Users",
                principalColumn: "IdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Orders_Gifts_giftsIdGift",
                table: "Gifts_Orders",
                column: "giftsIdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Packages_PackageIdPackage",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserIdBayer",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonorIdDonor",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Orders_Gifts_giftsIdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Gifts",
                newName: "gifts");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "gifts",
                newName: "IX_gifts_DonorIdDonor");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_UserIdBayer",
                table: "Card",
                newName: "IX_Card_UserIdBayer");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_PackageIdPackage",
                table: "Card",
                newName: "IX_Card_PackageIdPackage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gifts",
                table: "gifts",
                column: "IdGift");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "CurdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Packages_PackageIdPackage",
                table: "Card",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Users_UserIdBayer",
                table: "Card",
                column: "UserIdBayer",
                principalTable: "Users",
                principalColumn: "IdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_gifts_Donors_DonorIdDonor",
                table: "gifts",
                column: "DonorIdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Orders_gifts_giftsIdGift",
                table: "Gifts_Orders",
                column: "giftsIdGift",
                principalTable: "gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
